using System.Runtime.InteropServices;

namespace ProcessManager.Profiling
{
    internal class GpuProfiler
    {
        //
        // ---------------------------------- STRING ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetGpuName();
        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetGpuVendor();
        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetGpuDriverName();
        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetGpuDXVersion();

        //
        // ---------------------------------- ULONG ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetGpuDriverVersion();

        //
        // ---------------------------------- DOUBLE ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetGpuVRamSize();
        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetGpuVRamUsage();

        //
        // ---------------------------------- UINT ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetGpuID();
        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetGpuRevision();

        //
        // ---------------------------------- GPU_INFO_STRUCT  ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetGpuInfo(ulong gif, ulong mif, ulong uif, ulong pif, ulong rif);

        //
        // ---------------------------------- GPU_PHYSICAL_INFO_STRUCT ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetGpuPhysicalInfo(ulong pif);

        //
        // ---------------------------------- GPU_MODEL_INFO_STRUCT ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetGpuIGetGpuModelInfonfo(ulong mif);

        //
        // ---------------------------------- GPU_UTILIZATION_INFO_STRUCT ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetGpuUtilizationInfo(ulong uif);

        //
        // ---------------------------------- GPU_RESOLUTION_INFO_STRUCT ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetGpuMaxResolutionInfo(ulong rif);
        [DllImport(AppDefinition.DllPath)]
        public static extern IntPtr GetGpuMinResolutionInfo(ulong rif);

        //
        // ---------------------------------- METHODS ----------------------------------
        //

        [DllImport(AppDefinition.DllPath)]
        public static extern void FreeGpuInfo(IntPtr ptr);
    }
}
