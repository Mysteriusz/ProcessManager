using ProcessManager.Profiling.Models.Process;
using ProcessManager.Profiling.Models.Process.Models;

namespace ProcessManager.Pages.ProcessProperties.Models
{
    /// <summary>
    /// Base structure for process properties page
    /// </summary>
    public interface IProcessPropertiesPage
    {
        /// <summary>
        /// <see cref="ProcessInfoFlags"/> of the page.
        /// </summary>
        public ulong ProcessInfoUpdateFlags { get; set; }

        /// <summary>
        /// <see cref="ProcessThreadInfoFlags"/> of the page.
        /// </summary>
        public ulong ThreadInfoUpdateFlags { get; set; }

        /// <summary>
        /// <see cref="ProcessIOInfoFlags"/> of the page.
        /// </summary>
        public ulong IOInfoUpdateFlags { get; set; }

        /// <summary>
        /// <see cref="ProcessMemoryInfoFlags"/> of the page.
        /// </summary>
        public ulong MemoryInfoUpdateFlags { get; set; }

        /// <summary>
        /// <see cref="ProcessTimesInfoFlags"/> of the page.
        /// </summary>
        public ulong TimesInfoUpdateFlags { get; set; }

        /// <summary>
        /// <see cref="ProcessCpuInfoFlags"/> of the page.
        /// </summary>
        public ulong CpuInfoUpdateFlags { get; set; }

        /// <summary>
        /// <see cref="ProcessHandleInfoFlags"/> of the page.
        /// </summary>
        public ulong HandleInfoUpdateFlags { get; set; }

        /// <summary>
        /// <see cref="ProcessModuleInfoFlags"/> of the page.
        /// </summary>
        public ulong ModuleInfoUpdateFlags { get; set; }

        /// <summary>
        /// Delay in miliseconds of between each update.
        /// </summary>
        public int UpdateDelay { get; set; }

        /// <summary>
        /// Page thread cancellation token.
        /// </summary>
        public CancellationTokenSource? UpdateCancellation { get; set; }

        /// <summary>
        /// Process Info of the page.
        /// </summary>
        public ProcessInfo? ProcessInfo { get; set; }

        /// <summary>
        /// Event when page is loaded.
        /// </summary>
        public void Page_Loaded(object sender, System.Windows.RoutedEventArgs e);

        /// <summary>
        /// Event when page is unloaded.
        /// </summary>
        public void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e);
    }
}
