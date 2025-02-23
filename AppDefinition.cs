using ProcessManager.Profiling;
using System.Windows;
using System.Windows.Media;

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

        public static SolidColorBrush DefaultColor { get; } = new SolidColorBrush(Color.FromArgb(0xFF, 0x1A, 0x1A, 0x1A));
        public static SolidColorBrush MouseOverColor { get; } = new SolidColorBrush(Color.FromArgb(0xFF, 0x33, 0x33, 0x33));
        public static SolidColorBrush SelectColor { get; } = new SolidColorBrush(Color.FromArgb(0xFF, 0x47, 0x47, 0x47));
        public static SolidColorBrush MouseOverSelectColor { get; } = new SolidColorBrush(Color.FromArgb(0xFF, 0x2A, 0x2A, 0x2A));
        public static SolidColorBrush DarkTextColor { get; } = new SolidColorBrush(Color.FromArgb(0xFF, 0x66, 0x66, 0x66));
        public static SolidColorBrush LightTextColor { get; } = new SolidColorBrush(Color.FromArgb(0xFF, 0xC7, 0xC7, 0xC7));
        public static SolidColorBrush DataGraphColor { get; } = new SolidColorBrush(Colors.Yellow);

        /// <summary>
        /// Path to the ProcessManagerLib DLL
        /// </summary>
        public const string DllPath = "C:\\Users\\wixxx\\source\\repos\\ProcessManager\\x64\\Debug\\ProcessManagerLib.dll";

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
