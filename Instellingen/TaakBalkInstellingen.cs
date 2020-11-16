using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Instellingen
{
    class TaakBalkInstellingen
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int cx, int cy, bool repaint);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
       

        [DllImport("shell32.dll")]
        public static extern int SHAppBarMessage(int dwMessage, ref APPBARDATA pData);


        public enum AppBarMessages
        {
            New = 0x00,
            Remove = 0x01,
            QueryPos = 0x02,
            SetPos = 0x03,
            GetState = 0x04,
            GetTaskBarPos = 0x05,
            Activate = 0x06,
            GetAutoHideBar = 0x07,
            SetAutoHideBar = 0x08,
            WindowPosChanged = 0x09,
            SetState = 0x0a
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct APPBARDATA
        {
            public int cbSize; // initialize this field using: Marshal.SizeOf(typeof(APPBARDATA));
            public IntPtr hWnd;
            public uint uCallbackMessage;
            public int uEdge;
            public RECT rc;
            public int lParam;
        }

        public const int LEFT = 0;
        public const int TOP = 1;
        public const int RIGHT = 2;
        public const int BOTTOM = 3;

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public static RECT FromXYWH(int x, int y, int width, int height)
            {
                return new RECT(x, y, x + width, y + height);
            }
        }
        //set window (FindWindow("System_TrayWnd", null) )

        internal static void DockAppBar(int edge, System.Drawing.Size idealSize)
        {
            APPBARDATA msgData = new APPBARDATA();
            msgData.cbSize = Marshal.SizeOf(msgData);
            msgData.hWnd = FindWindow("Shell_TrayWnd", null);
            msgData.uEdge = edge;

            if (edge == LEFT || edge == RIGHT)
            {
                msgData.rc.top = 0;
                msgData.rc.bottom = SystemInformation.PrimaryMonitorSize.Height;
                if (edge == LEFT)
                {
                    msgData.rc.right = idealSize.Width;
                }
                else
                {
                    msgData.rc.right = SystemInformation.PrimaryMonitorSize.Width;
                    msgData.rc.left = msgData.rc.right - idealSize.Width;
                }

            }
            else
            {
                msgData.rc.left = 0;
                msgData.rc.right = SystemInformation.PrimaryMonitorSize.Width;
                if (edge == TOP)
                {
                    msgData.rc.bottom = idealSize.Height;
                }
                else
                {
                    msgData.rc.bottom = SystemInformation.PrimaryMonitorSize.Height;
                    msgData.rc.top = msgData.rc.bottom - idealSize.Height;
                }
            }


            // Query the system for an approved size and position.
            SHAppBarMessage((int)AppBarMessages.QueryPos, ref msgData);

            // Adjust the rectangle, depending on the edge to which the
            // appbar is anchored.
            switch (edge)
            {
                case LEFT:
                    msgData.rc.right = msgData.rc.left + idealSize.Width;
                    break;
                case RIGHT:
                    msgData.rc.left = msgData.rc.right - idealSize.Width;
                    break;
                case TOP:
                    msgData.rc.bottom = msgData.rc.top + idealSize.Height;
                    break;
                case BOTTOM:
                    msgData.rc.top = msgData.rc.bottom - idealSize.Height;
                    break;
            }

            // Pass the final bounding rectangle to the system.
            SHAppBarMessage((int)AppBarMessages.SetPos, ref msgData);

            // Move and size the appbar so that it conforms to the
            // bounding rectangle passed to the system.
            MoveWindow(msgData.hWnd, msgData.rc.left, msgData.rc.top, msgData.rc.right - msgData.rc.left, msgData.rc.bottom - msgData.rc.top, true);
        }

        public enum AppBarStates
        {
            AlwaysOnTop = 0x00,
            AutoHide = 0x01

        }

        public void SetTaskbarState(AppBarStates option)
        {
            APPBARDATA msgData = new APPBARDATA();
            msgData.cbSize = Marshal.SizeOf(msgData);
            msgData.hWnd = FindWindow("Shell_TrayWnd", null);
            msgData.lParam = (int)option;
            SHAppBarMessage((int)AppBarMessages.SetState, ref msgData);
        }
        public AppBarStates GetTaskbarState()
        {
            APPBARDATA msgData = new APPBARDATA();
            msgData.cbSize = Marshal.SizeOf(msgData);
            msgData.hWnd = FindWindow("Shell_TrayWnd", null);
            return (AppBarStates)SHAppBarMessage((int)AppBarMessages.GetState, ref msgData);
        }
        public void setAutoHide(bool autoHide)
        {

            Debug.WriteLine("autoHide: " + autoHide);

            if (autoHide)
            {
                Debug.WriteLine("GetTaskbarState(): " + GetTaskbarState());
                Debug.WriteLine(" GetTaskbarState() | AppBarStates.AutoHide: " + (GetTaskbarState() | AppBarStates.AutoHide));
                SetTaskbarState(GetTaskbarState() | AppBarStates.AutoHide);
                Debug.WriteLine("GetTaskbarState(): " + GetTaskbarState());
            }
            else
            {
                SetTaskbarState(GetTaskbarState() & ~AppBarStates.AutoHide);
            }
            Debug.WriteLine("GetTaskbarState(): " + GetTaskbarState());
        }
        public bool isAutoHide()
        {
            return (GetTaskbarState() & AppBarStates.AutoHide).Equals(AppBarStates.AutoHide);
        }
        
        public void setPositie(String pos)
        {

            System.Drawing.Size size = new System.Drawing.Size(1600,50);
            switch (pos)
            {
                case "up":
                    Console.WriteLine("up");
                    DockAppBar(TOP, size);
                    break;
                case "right":
                    Console.WriteLine("right");
                    DockAppBar(RIGHT, size);
                    break;
                case "down":
                    Console.WriteLine("down");
                    DockAppBar(BOTTOM, size);
                    break;
                case "left":
                    Console.WriteLine("left");
                    DockAppBar(LEFT, size);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;

            }
        }

        public int GetTaskBarLocation()
        {
            int taskBarLocation = BOTTOM;
            bool taskBarOnTopOrBottom = (Screen.PrimaryScreen.WorkingArea.Width == Screen.PrimaryScreen.Bounds.Width);
            if (taskBarOnTopOrBottom)
            {
                if (Screen.PrimaryScreen.WorkingArea.Top > 0) taskBarLocation = TOP;
            }
            else
            {
                if (Screen.PrimaryScreen.WorkingArea.Left > 0)
                {
                    taskBarLocation = LEFT;
                }
                else
                {
                    taskBarLocation = RIGHT;
                }
            }
            return taskBarLocation;
        }

    }
}