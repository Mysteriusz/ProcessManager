using System.Runtime.InteropServices;

namespace ProcessManager.Profiling
{
    internal class CpuProfiler
    {
        //
        // ---------------------------------- STRING ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetCpuName();
        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetCpuVendor();
        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetCpuArchitecture();

        //
        // ---------------------------------- UINT32 ----------------------------------
        //
        
        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetCpuModel();
        
        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetCpuFamily();
        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetCpuStepping();
        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetCpuThreadCount();
        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetCpuHandleCount();

        //
        // ---------------------------------- DOUBLE ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetCpuUsage();
        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetCpuBaseFrequency();
        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetCpuMaxFrequency();

        //
        // ---------------------------------- BOOLEAN ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr IsCpuVirtualization();
        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr IsCpuHyperThreading();

        //
        // ---------------------------------- CPU_MODEL_INFO_STRUCT ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetCpuModelInfo(ulong mif);

        //
        // ---------------------------------- CPU_SYSTEM_INFO_STRUCT ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetCpuSystemInfo(ulong sif);

        //
        // ---------------------------------- CPU_TIMES_INFO_STRUCT ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetCpuTimes(ulong tif);

        //
        // ---------------------------------- CPU_CACHE_INFO_STRUCT ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetCpuAllLevelsCacheInfo(ulong hif, out uint size);

        //
        // ---------------------------------- CPU_INFO_STRUCT ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetCpuInfo(ulong cif, ulong sif, ulong mif, ulong tif, ulong hif);

        //
        // ---------------------------------- VOID ----------------------------------
        //

        [DllImport(AppDefinition.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FreeCpuInfo(IntPtr info);
    }
}
