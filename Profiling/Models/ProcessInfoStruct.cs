using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models
{
    [StructLayout(LayoutKind.Sequential)]
    struct ProcessInfoStruct
    {
        public string name;
        public string user;
        public string imageName;
        public string priority;

        public uint pid;
    }
}
