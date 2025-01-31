namespace ProcessManager.Profiling.Models.Cpu
{
    internal class ProcessCpuInfo
    {
        public ulong LastCpu { get; set; }
        public ulong LastUserCpu { get; set; }
        public ulong LastSystemCpu { get; set; }
        public int CpuNumber { get; set; }

        public double UsagePercent { get; set; }
    }
}
