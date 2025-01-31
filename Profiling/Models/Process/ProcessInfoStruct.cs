using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process
{
    [StructLayout(LayoutKind.Sequential)]
    struct ProcessInfoStruct
    {
        public nint name;
        public nint user;
        public nint imageName;
        public nint priority;

        public uint pid;
    }
}
