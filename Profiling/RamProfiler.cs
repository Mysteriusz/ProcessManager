using System.Runtime.InteropServices;

namespace ProcessManager.Profiling
{
    internal static class RamProfiler
    {
        //
        // ---------------------------------- RAM_BLOCK_INFO_STRUCT ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetRamInfo(ulong rif, ulong uif, ulong bif);
        
        //
        // ---------------------------------- RAM_INFO_STRUCT ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetAllRamBlockInfo(ulong bif, out uint size);
        
        //
        // ---------------------------------- RAM_UTILIZATION_INFO_STRUCT ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetRamUtilizationInfo(ulong uif);

        //
        // ---------------------------------- METHODS ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr FreeRamInfo(IntPtr ptr);
    }
}
