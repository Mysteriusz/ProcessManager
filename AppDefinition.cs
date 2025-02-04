using ProcessManager.Profiling;
using System.Diagnostics;
using System.Windows;

namespace ProcessManager
{
    /// <summary>
    /// Static definition of currently run application.
    /// </summary>
    public static class AppDefinition
    {
        //
        // ---------------------------------- PROPERTIES ----------------------------------
        //

        /// <summary>
        /// Application name.
        /// </summary>
        public static string Name { get; } = "Process Manager";

        /// <summary>
        /// Application version.
        /// </summary>
        public static string Version { get; } = "1.0";

        /// <summary>
        /// Current application as <see cref="Application"/> class.
        /// </summary>
        public static Application ApplicationObject { get; } = new Application();

        //
        // ---------------------------------- METHODS ----------------------------------
        //

        /// <summary>
        /// Application entry point.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Start(new MainWindow());
        }

        /// <summary>
        /// Runs the application with provided main window.
        /// </summary>
        /// <param name="initialWindow">Window to start with.</param>
        public static void Start(Window initialWindow)
        {
            Profiler.EnableDebugPrivilages();
            ApplicationObject.Run(initialWindow);
        }
        
        /// <summary>
        /// Stops the application with provided exit code.
        /// </summary>
        /// <param name="exitCode">Exit code.</param>
        public static void Stop(int exitCode = 0)
        {
            ApplicationObject.Shutdown(exitCode);
        }
    }
}
