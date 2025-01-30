using System.ComponentModel;

namespace ProcessManager.Profiling.Models
{
    internal class ProcessInfo : INotifyPropertyChanged
    {
        //
        // ---------------------------------- PROPERTIES ----------------------------------
        //

        public string Name { get; set; } = "";
        public string ImageName { get; set; } = "";
        public string User { get; set; } = "";
        public string Priority { get; set; } = "";
        public uint PID { get; set; }

        private double _cpuUsage;
        private double _memUsage;
        private double _ioUsage;
        public double CpuUsage
        {
            get
            {
                return _cpuUsage;
            }
            set
            {
                if (_cpuUsage != value)
                {
                    _cpuUsage = value;
                    OnPropertyChanged(nameof(CpuUsage));
                }
            }
        }
        public double MemoryUsage
        {
            get
            {
                return _memUsage;
            }
            set
            {
                if (_memUsage != value)
                {
                    _memUsage = value;
                    OnPropertyChanged(nameof(MemoryUsage));
                }
            }
        }
        public double DiskUsage
        {
            get
            {
                return _ioUsage;
            }
            set
            {
                if (_ioUsage != value)
                {
                    _ioUsage = value;
                    OnPropertyChanged(nameof(DiskUsage));
                }
            }
        }

        //
        // ---------------------------------- METHODS ----------------------------------
        //

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
