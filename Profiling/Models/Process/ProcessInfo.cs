using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ProcessManager.Profiling.Models.Process
{
    internal class ProcessInfo : INotifyPropertyChanged
    {
        //
        // ---------------------------------- PROPERTIES ----------------------------------
        //

        public string Name { get; set; } = "";
        public string ParentName { get; set; } = "";
        public string User { get; set; } = "";
        public string ImageName { get; set; } = "";
        public string Priority { get; set; } = "";
        public string Version { get; set; } = "";
        public string IntegrityLevel { get; set; } = "";
        public string ArchitectureType { get; set; } = "";
        public string CommandLine { get; set; } = "";
        public string Description { get; set; } = "";
        public uint PID { get; set; }
        public uint PPID { get; set; }
        public ulong PEB { get; set; }

        // ------------------------ PROCESS_TIMES_INFO ------------------------ 

        private DateTime _creationTime;
        private DateTime _kernelTime;
        private DateTime _exitTime;
        private DateTime _userTime;
        private DateTime _totalTime;
        public DateTime CreationTime
        {
            get => _creationTime;
            set
            {
                if (_creationTime != value)
                {
                    _creationTime = value;
                    OnPropertyChanged(nameof(CreationTime));
                }
            }
        }
        public DateTime KernelTime
        {
            get => _kernelTime;
            set
            {
                if (_kernelTime != value)
                {
                    _kernelTime = value;
                    OnPropertyChanged(nameof(KernelTime));
                }
            }
        }
        public DateTime ExitTime
        {
            get => _exitTime;
            set
            {
                if (_exitTime != value)
                {
                    _exitTime = value;
                    OnPropertyChanged(nameof(ExitTime));
                }
            }
        }
        public DateTime UserTime
        {
            get => _userTime;
            set
            {
                if (_userTime != value)
                {
                    _userTime = value;
                    OnPropertyChanged(nameof(UserTime));
                }
            }
        }
        public DateTime TotalTime
        {
            get => _totalTime;
            set
            {
                if (_totalTime != value)
                {
                    _totalTime = value;
                    OnPropertyChanged(nameof(TotalTime));
                }
            }
        }

        // ------------------------ PROCESS_HANDLES_INFO ------------------------ 

        private uint _handleCount;
        private uint _handlePeakCount;
        public uint HandleCount
        {
            get
            {
                return _handleCount;
            }
            set
            {
                if (_handleCount != value)
                {
                    _handleCount = value;
                    OnPropertyChanged(nameof(HandleCount));
                }
            }
        }
        public uint HandlePeakCount
        {
            get
            {
                return _handlePeakCount;
            }
            set
            {
                if (_handlePeakCount != value)
                {
                    _handlePeakCount = value;
                    OnPropertyChanged(nameof(HandlePeakCount));
                }
            }
        }

        // ------------------------ MISC ------------------------ 

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
        // ---------------------------------- CONSTRUCTORS ----------------------------------
        //

        public ProcessInfo() { }
        public ProcessInfo(ProcessInfoStruct infoStruct)
        {
            Name = Profiler.ToString(infoStruct.name) ?? "";
            ParentName = Profiler.ToString(infoStruct.parentProcessName) ?? "";
            User = Profiler.ToString(infoStruct.user) ?? "";
            ImageName = Profiler.ToString(infoStruct.imageName) ?? "";
            Priority = Profiler.ToString(infoStruct.priority) ?? "";
            Version = Profiler.ToString(infoStruct.fileVersion) ?? "";
            IntegrityLevel = Profiler.ToString(infoStruct.integrityLevel) ?? "";
            ArchitectureType = Profiler.ToString(infoStruct.architectureType) ?? "";
            CommandLine = Profiler.ToString(infoStruct.cmd) ?? "";
            Description = Profiler.ToString(infoStruct.description) ?? "";

            PID = infoStruct.pid;
            PPID = infoStruct.ppid;
            PEB = infoStruct.peb;

            _creationTime = Profiler.ToDateTime(infoStruct.timesInfo.creationTime) ?? new DateTime();
            _exitTime = Profiler.ToDateTime(infoStruct.timesInfo.exitTime, true) ?? new DateTime();
            _userTime = Profiler.ToDateTime(infoStruct.timesInfo.userTime, true) ?? new DateTime();
            _kernelTime = Profiler.ToDateTime(infoStruct.timesInfo.kernelTime, true) ?? new DateTime();
            _totalTime = Profiler.ToDateTime(infoStruct.timesInfo.totalTime, true) ?? new DateTime();

            _handleCount = infoStruct.handlesInfo.count;
            _handlePeakCount = infoStruct.handlesInfo.peakCount;
        }

        //
        // ---------------------------------- METHODS ----------------------------------
        //

        public void Read(ulong flags, ProcessInfoStruct infoStruct)
        {
            if ((flags & (ulong)ProcessInfoFlags.ProcessName) != 0)
            {
                Name = Profiler.ToString(infoStruct.name) ?? "N/A";
            }

            if ((flags & (ulong)ProcessInfoFlags.ProcessParentName) != 0)
            {
                ParentName = Profiler.ToString(infoStruct.parentProcessName) ?? "N/A";
            }

            if ((flags & (ulong)ProcessInfoFlags.ProcessImageName) != 0)
            {
                ImageName = Profiler.ToString(infoStruct.imageName) ?? "N/A";
            }

            if ((flags & (ulong)ProcessInfoFlags.ProcessUser) != 0)
            {
                User = Profiler.ToString(infoStruct.user) ?? "N/A";
            }

            if ((flags & (ulong)ProcessInfoFlags.ProcessPriority) != 0)
            {
                Priority = Profiler.ToString(infoStruct.priority) ?? "N/A";
            }

            if ((flags & (ulong)ProcessInfoFlags.ProcessFileVersion) != 0)
            {
                Version = Profiler.ToString(infoStruct.fileVersion) ?? "N/A";
            }

            if ((flags & (ulong)ProcessInfoFlags.ProcessArchitectureType) != 0)
            {
                ArchitectureType = Profiler.ToString(infoStruct.architectureType) ?? "N/A";
            }

            if ((flags & (ulong)ProcessInfoFlags.ProcessIntegrityLevel) != 0)
            {
                IntegrityLevel = Profiler.ToString(infoStruct.integrityLevel) ?? "N/A";
            }

            if ((flags & (ulong)ProcessInfoFlags.ProcessCommandLine) != 0)
            {
                CommandLine = Profiler.ToString(infoStruct.cmd) ?? "N/A";
            }

            if ((flags & (ulong)ProcessInfoFlags.ProcessDescription) != 0)
            {
                Description = Profiler.ToString(infoStruct.description) ?? "N/A";
            }

            if ((flags & (ulong)ProcessInfoFlags.ProcessPPID) != 0)
            {
                PPID = infoStruct.ppid;
            }

            if ((flags & (ulong)ProcessInfoFlags.ProcessPEB) != 0)
            {
                PEB = infoStruct.peb;
            }

            if ((flags & (ulong)ProcessInfoFlags.ProcessTimes) != 0)
            {
                _creationTime = Profiler.ToDateTime(infoStruct.timesInfo.creationTime) ?? new DateTime();
                _exitTime = Profiler.ToDateTime(infoStruct.timesInfo.exitTime, true) ?? new DateTime();
                _userTime = Profiler.ToDateTime(infoStruct.timesInfo.userTime, true) ?? new DateTime();
                _kernelTime = Profiler.ToDateTime(infoStruct.timesInfo.kernelTime, true) ?? new DateTime();
                _totalTime = Profiler.ToDateTime(infoStruct.timesInfo.totalTime, true) ?? new DateTime();
            }

            if ((flags & (ulong)ProcessInfoFlags.ProcessHandlesInfo) != 0)
            {
                _handleCount = infoStruct.handlesInfo.count;
                _handlePeakCount = infoStruct.handlesInfo.peakCount;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
