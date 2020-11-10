using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Instellingen
{
    class GeluidsInstellingen
    {
        #region Master Volume Manipulation
        public int getVolume()
        {
            IAudioEndpointVolume masterVol = null;
            try
            {
                masterVol = GetMasterVolumeObject();
                if (masterVol == null)
                    return -1;

                float volumeLevel;
                masterVol.GetMasterVolumeLevelScalar(out volumeLevel);
                return (int)Math.Round((volumeLevel * 100));
            }
            finally
            {
                if (masterVol != null)
                    Marshal.ReleaseComObject(masterVol);
            }
        }
        public void setVolume(int soundPercentage)
        {

            IAudioEndpointVolume masterVol = null;
            try
            {
                masterVol = GetMasterVolumeObject();
                if (masterVol == null)
                    return;

                masterVol.SetMasterVolumeLevelScalar(soundPercentage / 100.0f, Guid.Empty);
            }
            finally
            {
                if (masterVol != null)
                    Marshal.ReleaseComObject(masterVol);
            }
        }
        private static IAudioEndpointVolume GetMasterVolumeObject()
        {
            IMMDeviceEnumerator deviceEnumerator = null;
            IMMDevice speakers = null;
            try
            {
                deviceEnumerator = (IMMDeviceEnumerator)(new MMDeviceEnumerator());
                deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, out speakers);

                Guid IID_IAudioEndpointVolume = typeof(IAudioEndpointVolume).GUID;
                object o;
                speakers.Activate(ref IID_IAudioEndpointVolume, 0, IntPtr.Zero, out o);
                IAudioEndpointVolume masterVol = (IAudioEndpointVolume)o;

                return masterVol;
            }
            finally
            {
                if (speakers != null) Marshal.ReleaseComObject(speakers);
                if (deviceEnumerator != null) Marshal.ReleaseComObject(deviceEnumerator);
            }
        }
        #endregion

    //class
    }

    #region Abstracted COM interfaces from Windows CoreAudio API

    [ComImport]
    [Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")]
    internal class MMDeviceEnumerator
    {
    }

    internal enum EDataFlow
    {
        eRender,
        eCapture,
        eAll,
        EDataFlow_enum_count
    }

    internal enum ERole
    {
        eConsole,
        eMultimedia,
        eCommunications,
        ERole_enum_count
    }

    [Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IMMDeviceEnumerator
    {
        int NotImpl1();

        [PreserveSig]
        int GetDefaultAudioEndpoint(EDataFlow dataFlow, ERole role, out IMMDevice ppDevice);
    }

    [Guid("D666063F-1587-4E43-81F1-B948E807363F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IMMDevice
    {
        [PreserveSig]
        int Activate(ref Guid iid, int dwClsCtx, IntPtr pActivationParams, [MarshalAs(UnmanagedType.IUnknown)] out object ppInterface);
    }

    [Guid("5CDF2C82-841E-4546-9722-0CF74078229A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAudioEndpointVolume
    {
        [PreserveSig]
        int NotImpl1();

        [PreserveSig]
        int NotImpl2();

        [PreserveSig]
        int GetChannelCount(
            [Out][MarshalAs(UnmanagedType.U4)] out UInt32 channelCount);

        [PreserveSig]
        int SetMasterVolumeLevel(
            [In][MarshalAs(UnmanagedType.R4)] float level,
            [In][MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

        [PreserveSig]
        int SetMasterVolumeLevelScalar(
            [In][MarshalAs(UnmanagedType.R4)] float level,
            [In][MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

        [PreserveSig]
        int GetMasterVolumeLevel(
            [Out][MarshalAs(UnmanagedType.R4)] out float level);

        [PreserveSig]
        int GetMasterVolumeLevelScalar(
            [Out][MarshalAs(UnmanagedType.R4)] out float level);

    }

    #endregion

}
