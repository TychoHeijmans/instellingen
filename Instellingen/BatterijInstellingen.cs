

using System.Runtime.InteropServices;

namespace Instellingen
{
    class BatterijInstellingen
    {

        public struct GLOBAL_POWER_POLICY
        {
     
        }

        public struct POWER_POLICY
        {

        }

        [DllImport("powrprof.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCurrentPowerPolicies([Out] GLOBAL_POWER_POLICY pGlobalPowerPolicy, [Out] POWER_POLICY pPowerPolicy);

        public void changeBatterySettingsState()
        {

         
        }

        public bool isBatterySaver()
        {

            return true;
        }


    }
}
