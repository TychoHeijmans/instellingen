using System;
using System.Management;
using System.Runtime.InteropServices;

namespace Instellingen
{
    public struct PHYSICAL_MONITOR
    {
        public IntPtr hPhysicalMonitor;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szPhysicalMonitorDescription;
    }
    class MonitorInstellingen
    {
        [DllImport("user32.dll", EntryPoint = "MonitorFromWindow")]
        public static extern IntPtr MonitorFromWindow([In] IntPtr hwnd, uint dwFlags);
        private const uint MONITOR_DEFAULTTONEAREST = 2;

        [DllImport("dxva2.dll", EntryPoint = "GetNumberOfPhysicalMonitorsFromHMONITOR")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetNumberOfPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, ref uint pdwNumberOfPhysicalMonitors);

        [DllImport("dxva2.dll", EntryPoint = "GetPhysicalMonitorsFromHMONITOR")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, uint dwPhysicalMonitorArraySize, [Out] PHYSICAL_MONITOR[] pPhysicalMonitorArray);

        [DllImport("dxva2.dll", EntryPoint = "GetMonitorBrightness")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMonitorBrightness(IntPtr handle, ref uint minimumBrightness, ref uint currentBrightness, ref uint maxBrightness);

        [DllImport("dxva2.dll", EntryPoint = "SetMonitorBrightness")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetMonitorBrightness(IntPtr handle, uint newBrightness);

        private uint brightnessCurrentValue = 0;
        private uint brightnessMinValue = 0;
        private uint brightnessMaxValue = 0;
        private IntPtr firstMonitorHandle;


        public MonitorInstellingen(IntPtr windowHandle)
        {
            uint _physicalMonitorsCount = 0;

            IntPtr ptr = MonitorFromWindow(windowHandle, MONITOR_DEFAULTTONEAREST);

            if (!GetNumberOfPhysicalMonitorsFromHMONITOR(ptr, ref _physicalMonitorsCount))
            {
                throw new Exception("Cannot get monitor count!");
            }

            PHYSICAL_MONITOR[] _physicalMonitorArray = new PHYSICAL_MONITOR[_physicalMonitorsCount];
            if (!GetPhysicalMonitorsFromHMONITOR(ptr, _physicalMonitorsCount, _physicalMonitorArray))
            {
                throw new Exception("Cannot get physical monitor handle!");
            }
            
            firstMonitorHandle = _physicalMonitorArray[0].hPhysicalMonitor;

            getBrightnessPercentage();
        //MonitorInstellingen()
        }

        public int getBrightnessPercentage()
        {
            if (!GetMonitorBrightness(firstMonitorHandle, ref brightnessMinValue, ref brightnessCurrentValue, ref brightnessMaxValue))
            {
                int internalBrightness = getInternalBrightness();
                if (internalBrightness == -1)
                {
                    throw new Exception("Cannot get monitor brightness!");
                }
                brightnessCurrentValue = (uint)internalBrightness;
                brightnessMinValue = 0;
                brightnessMaxValue = 100;
            }
            return (int)Math.Round(100.0 * (brightnessCurrentValue - brightnessMinValue) / (brightnessMaxValue - brightnessMinValue));
        }
        public void setBrightness(int percentage)
        {
            brightnessCurrentValue = (uint)Math.Round((brightnessMaxValue - brightnessMinValue) * percentage / 100.0  + brightnessMinValue);
            if (!SetMonitorBrightness(firstMonitorHandle, brightnessCurrentValue)){
                setInternalBrightness(percentage);
            }
        }

        public int getInternalBrightness()
        {
            using var mclass = new ManagementClass("WmiMonitorBrightness")
            {
                Scope = new ManagementScope(@"\\.\root\wmi")
            };
            using var instances = mclass.GetInstances();
            foreach (ManagementObject instance in instances)
            {
                return (byte)instance.GetPropertyValue("CurrentBrightness");
            }
            return -1;
        }

        public static void setInternalBrightness(int brightness)
        {
            using var mclass = new ManagementClass("WmiMonitorBrightnessMethods")
            {
                Scope = new ManagementScope(@"\\.\root\wmi")
            };
            using var instances = mclass.GetInstances();
            var args = new object[] { 1, brightness };
            foreach (ManagementObject instance in instances)
            {
                instance.InvokeMethod("WmiSetBrightness", args);
            }
        }

        //class
    }
    //namespace
}
