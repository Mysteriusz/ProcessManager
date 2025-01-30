using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models
{
    [StructLayout(LayoutKind.Sequential)]
    struct ProcessInfoStruct
    {
        public IntPtr name;
        public IntPtr user;
        public IntPtr imageName;
        public IntPtr priority;

        public uint pid;
    }
}
