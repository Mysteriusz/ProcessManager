using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Cpu.Models
{
    [Flags]
    public enum CpuModelInfoFlags : ulong
    {
        CPU_MIF_NAME = 0x00000001,
        CPU_MIF_VENDOR = 0x00000002,
        CPU_MIF_ARCHITECTURE = 0x00000004,
        CPU_MIF_MODEL = 0x00000008,
        CPU_MIF_FAMILY = 0x00000010,
        CPU_MIF_STEPPING = 0x00000020,
        CPU_MIF_ALL = 0xffffffff
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CpuModelInfoStruct
    {
        public IntPtr name;
        public IntPtr vendor;
        public IntPtr architecture;

        public UInt32 model;
        public UInt32 family;
        public UInt32 stepping;
    }
}
