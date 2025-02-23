using System.Runtime.InteropServices;

namespace ProcessManager.Actions
{
    public static class ProcessActions
    {
        [DllImport(AppDefinition.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void StartProcess(string path, string commandLine);
        [DllImport(AppDefinition.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void KillProcess(uint pid);
        [DllImport(AppDefinition.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SuspendProcess(uint pid);
        [DllImport(AppDefinition.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ResumeProcess(uint pid);
        [DllImport(AppDefinition.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void InjectModule(string path, string modulePath);
        [DllImport(AppDefinition.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetAffinity(uint pid, uint affinity);
        [DllImport(AppDefinition.DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetPriority(uint pid, uint priority);
    }
}
