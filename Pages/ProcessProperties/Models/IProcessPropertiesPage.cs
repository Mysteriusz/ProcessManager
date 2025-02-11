using ProcessManager.Profiling.Models.Process;

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
        /// <see cref="ThreadInfoFlags"/> of the page.
        /// </summary>
        public ulong ThreadInfoUpdateFlags { get; set; }

        /// <summary>
        /// <see cref="HandleInfoFlags"/> of the page.
        /// </summary>
        public ulong HandleInfoUpdateFlags { get; set; }

        /// <summary>
        /// <see cref="ModuleInfoFlags"/> of the page.
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
