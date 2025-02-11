using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process
{
    [Flags]
    public enum ModuleInfoFlags : ulong
    {
        ModuleName = 0x00000001,
        ModulePath = 0x00000002,
        ModuleDescription = 0x00000004,
        ModuleAddress = 0x00000008,
        ModuleSize = 0x00000010
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessModuleInfoStruct
    {
        public IntPtr name;
        public IntPtr path;
        public IntPtr description;
        public UInt64 address;
        public UInt64 size;
    }
}
