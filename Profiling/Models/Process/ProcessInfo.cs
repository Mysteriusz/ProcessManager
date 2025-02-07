﻿using System.Windows.Interop;
using System.ComponentModel;
using System.Windows.Media;
using System.Drawing;
using System.IO;

namespace ProcessManager.Profiling.Models.Process
{
    public class ProcessInfo : INotifyPropertyChanged
    {
        //
        // ---------------------------------- PROPERTIES ----------------------------------
        //

        private string _name = "N/A";
        private string _parentName = "N/A";
        private string _user = "N/A";
        private string _imageName = "N/A";
        private string _priority = "N/A";
        private string _version = "N/A";
        private string _integrityLevel = "N/A";
        private string _architectureType = "N/A";
        private string _commandLine = "N/A";
        private string _description = "N/A";
        private ulong _peb = 0;
        private uint _pid = 0;
        private uint _ppid = 0;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string ParentName
        {
            get => _parentName;
            set
            {
                if (_parentName != value)
                {
                    _parentName = value;
                    OnPropertyChanged(nameof(ParentName));
                }
            }
        }
        public string User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }
        public string ImageName
        {
            get => _imageName;
            set
            {
                if (_imageName != value)
                {
                    _imageName = value;
                    OnPropertyChanged(nameof(ImageName));
                }
            }
        }
        public string Priority
        {
            get => _priority;
            set
            {
                if (_priority != value)
                {
                    _priority = value;
                    OnPropertyChanged(nameof(Priority));
                }
            }
        }
        public string Version
        {
            get => _version;
            set
            {
                if (_version != value)
                {
                    _version = value;
                    OnPropertyChanged(nameof(Version));
                }
            }
        }
        public string IntegrityLevel
        {
            get => _integrityLevel;
            set
            {
                if (_integrityLevel != value)
                {
                    _integrityLevel = value;
                    OnPropertyChanged(nameof(IntegrityLevel));
                }
            }
        }
        public string ArchitectureType
        {
            get => _architectureType;
            set
            {
                if (_architectureType != value)
                {
                    _architectureType = value;
                    OnPropertyChanged(nameof(ArchitectureType));
                }
            }
        }
        public string CommandLine
        {
            get => _commandLine;
            set
            {
                if (_commandLine != value)
                {
                    _commandLine = value;
                    OnPropertyChanged(nameof(CommandLine));
                }
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        public ulong PEB
        {
            get => _peb;
            set
            {
                if (_peb != value)
                {
                    _peb = value;
                    OnPropertyChanged(nameof(PEB));
                }
            }
        }
        public uint PID
        {
            get => _pid;
            set
            {
                if (_pid != value)
                {
                    _pid = value;
                    OnPropertyChanged(nameof(PID));
                }
            }
        }
        public uint PPID
        {
            get => _ppid;
            set
            {
                if (_ppid != value)
                {
                    _ppid = value;
                    OnPropertyChanged(nameof(PPID));
                }
            }
        }

        public Icon? Icon
        {
            get
            {
                return File.Exists(ImageName) ? Icon.ExtractAssociatedIcon(ImageName) : SystemIcons.Application;
            }
        }
        public ImageSource IconSource
        {
            get
            { 
                return Icon != null ? Imaging.CreateBitmapSourceFromHBitmap(Icon.ToBitmap().GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, null) :
                    Imaging.CreateBitmapSourceFromHBitmap(SystemIcons.WinLogo.ToBitmap().GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, null);
            }
        }

        // ------------------------ CYCLE COUNT ------------------------ 

        private ulong _cycleCount;
        public ulong CycleCount
        {
            get
            {
                return _cycleCount;
            }
            set
            {
                if (_cycleCount != value)
                {
                    _cycleCount = value;
                    OnPropertyChanged(nameof(CycleCount));
                }
            }
        }

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
        private uint _handleGdiCount;
        private uint _handleUserCount;
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
        public uint GdiHandleCount
        {
            get
            {
                return _handleGdiCount;
            }
            set
            {
                if (_handleGdiCount != value)
                {
                    _handleGdiCount = value;
                    OnPropertyChanged(nameof(GdiHandleCount));
                }
            }
        }
        public uint UserHandleCount
        {
            get
            {
                return _handleUserCount;
            }
            set
            {
                if (_handleUserCount != value)
                {
                    _handleUserCount = value;
                    OnPropertyChanged(nameof(UserHandleCount));
                }
            }
        }

        // ------------------------ PROCESS_MEMORY_INFO ------------------------ 

        private uint _privateBytes;
        private uint _peakPrivateBytes;
        private uint _virtualBytes;
        private uint _peakVirtualBytes;
        private uint _pageFaults;
        private uint _workingBytes;
        private uint _peakWorkingBytes;
        private ulong _pagePriority;

        public uint PrivateBytes
        {
            get { return _privateBytes; }
            set
            {
                if (_privateBytes != value)
                {
                    _privateBytes = value;
                    OnPropertyChanged(nameof(PrivateBytes));
                }
            }
        }
        public uint PeakPrivateBytes
        {
            get { return _peakPrivateBytes; }
            set
            {
                if (_peakPrivateBytes != value)
                {
                    _peakPrivateBytes = value;
                    OnPropertyChanged(nameof(PeakPrivateBytes));
                }
            }
        }
        public uint VirtualBytes
        {
            get { return _virtualBytes; }
            set
            {
                if (_virtualBytes != value)
                {
                    _virtualBytes = value;
                    OnPropertyChanged(nameof(VirtualBytes));
                }
            }
        }
        public uint PeakVirtualBytes
        {
            get { return _peakVirtualBytes; }
            set
            {
                if (_peakVirtualBytes != value)
                {
                    _peakVirtualBytes = value;
                    OnPropertyChanged(nameof(PeakVirtualBytes));
                }
            }
        }
        public uint PageFaults
        {
            get { return _pageFaults; }
            set
            {
                if (_pageFaults != value)
                {
                    _pageFaults = value;
                    OnPropertyChanged(nameof(PageFaults));
                }
            }
        }
        public uint WorkingBytes
        {
            get { return _workingBytes; }
            set
            {
                if (_workingBytes != value)
                {
                    _workingBytes = value;
                    OnPropertyChanged(nameof(WorkingBytes));
                }
            }
        }
        public uint PeakWorkingBytes
        {
            get { return _peakWorkingBytes; }
            set
            {
                if (_peakWorkingBytes != value)
                {
                    _peakWorkingBytes = value;
                    OnPropertyChanged(nameof(PeakWorkingBytes));
                }
            }
        }
        public ulong PagePriority
        {
            get { return _pagePriority; }
            set
            {
                if (_pagePriority != value)
                {
                    _pagePriority = value;
                    OnPropertyChanged(nameof(PagePriority));
                }
            }
        }

        // ------------------------ PROCESS_IO_INFO ------------------------ 

        private ulong _reads;
        private ulong _readBytes;
        private ulong _writes;
        private ulong _writeBytes;
        private ulong _other;
        private ulong _otherBytes;
        private uint _ioPriority;

        public ulong Reads
        {
            get => _reads;
            set
            {
                if (_reads != value)
                {
                    _reads = value;
                    OnPropertyChanged(nameof(Reads));
                }
            }
        }
        public ulong ReadBytes
        {
            get => _readBytes;
            set
            {
                if (_readBytes != value)
                {
                    _readBytes = value;
                    OnPropertyChanged(nameof(ReadBytes));
                }
            }
        }
        public ulong Writes
        {
            get => _writes;
            set
            {
                if (_writes != value)
                {
                    _writes = value;
                    OnPropertyChanged(nameof(Writes));
                }
            }
        }
        public ulong WriteBytes
        {
            get => _writeBytes;
            set
            {
                if (_writeBytes != value)
                {
                    _writeBytes = value;
                    OnPropertyChanged(nameof(WriteBytes));
                }
            }
        }
        public ulong Other
        {
            get => _other;
            set
            {
                if (_other != value)
                {
                    _other = value;
                    OnPropertyChanged(nameof(Other));
                }
            }
        }
        public ulong OtherBytes
        {
            get => _otherBytes;
            set
            {
                if (_otherBytes != value)
                {
                    _otherBytes = value;
                    OnPropertyChanged(nameof(OtherBytes));
                }
            }
        }
        public uint IOPriority
        {
            get => _ioPriority;
            set
            {
                if (_ioPriority != value)
                {
                    _ioPriority = value;
                    OnPropertyChanged(nameof(IOPriority));
                }
            }
        }

        // ------------------------ PROCESS_MODULES_INFO ------------------------ 

        private ProcessModuleInfo[] _modules = [];
        private uint _moduleCount;

        public ProcessModuleInfo[] Modules
        {
            get => _modules;
            set
            {
                if (_modules != value)
                {
                    _modules = value;
                    OnPropertyChanged(nameof(Modules));
                }
            }
        }
        public uint ModuleCount
        {
            get => _moduleCount;
            set
            {
                if (_moduleCount != value)
                {
                    _moduleCount = value;
                    OnPropertyChanged(nameof(ModuleCount));
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

        public void Read(ulong processFlags, ulong moduleFlags, ProcessInfoStruct infoStruct)
        {
            if ((processFlags & (ulong)ProcessInfoFlags.ProcessName) != 0)
            {
                Name = Profiler.ToString(infoStruct.name) ?? "N/A";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessParentName) != 0)
            {
                ParentName = Profiler.ToString(infoStruct.parentProcessName) ?? "N/A";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessImageName) != 0)
            {
                ImageName = Profiler.ToString(infoStruct.imageName) ?? "N/A";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessUser) != 0)
            {
                User = Profiler.ToString(infoStruct.user) ?? "N/A";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessPriority) != 0)
            {
                Priority = Profiler.ToString(infoStruct.priority) ?? "N/A";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessFileVersion) != 0)
            {
                Version = Profiler.ToString(infoStruct.fileVersion) ?? "N/A";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessArchitectureType) != 0)
            {
                ArchitectureType = Profiler.ToString(infoStruct.architectureType) ?? "N/A";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessIntegrityLevel) != 0)
            {
                IntegrityLevel = Profiler.ToString(infoStruct.integrityLevel) ?? "N/A";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessCommandLine) != 0)
            {
                CommandLine = Profiler.ToString(infoStruct.cmd) ?? "N/A";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessDescription) != 0)
            {
                Description = Profiler.ToString(infoStruct.description) ?? "N/A";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessPPID) != 0)
            {
                PPID = infoStruct.ppid;
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessPEB) != 0)
            {
                PEB = infoStruct.peb;
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessTimes) != 0)
            {
                CreationTime = Profiler.ToDateTime(infoStruct.timesInfo.creationTime) ?? new DateTime();
                ExitTime = Profiler.ToDateTime(infoStruct.timesInfo.exitTime, true) ?? new DateTime();
                UserTime = Profiler.ToDateTime(infoStruct.timesInfo.userTime, true) ?? new DateTime();
                KernelTime = Profiler.ToDateTime(infoStruct.timesInfo.kernelTime, true) ?? new DateTime();
                TotalTime = Profiler.ToDateTime(infoStruct.timesInfo.totalTime, true) ?? new DateTime();
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessHandlesInfo) != 0)
            {
                HandleCount = infoStruct.handlesInfo.count;
                HandlePeakCount = infoStruct.handlesInfo.peakCount;
                GdiHandleCount = infoStruct.handlesInfo.gdiCount;
                UserHandleCount = infoStruct.handlesInfo.userCount;
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessCycleCount) != 0)
            {
                CycleCount = infoStruct.cycles;
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessMemoryInfo) != 0)
            {
                PrivateBytes = infoStruct.memoryInfo.privateBytes;
                PeakPrivateBytes = infoStruct.memoryInfo.peakPrivateBytes;
                VirtualBytes = infoStruct.memoryInfo.virtualBytes;
                PeakVirtualBytes = infoStruct.memoryInfo.peakVirtualBytes;
                WorkingBytes = infoStruct.memoryInfo.workingBytes;
                PeakWorkingBytes = infoStruct.memoryInfo.peakWorkingBytes;
                PagePriority = infoStruct.memoryInfo.priority;
                PageFaults = infoStruct.memoryInfo.pageFaults;
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessIOInfo) != 0)
            {
                Reads = infoStruct.ioInfo.reads;
                ReadBytes = infoStruct.ioInfo.readBytes;
                Writes = infoStruct.ioInfo.writes;
                WriteBytes = infoStruct.ioInfo.writeBytes;
                Other = infoStruct.ioInfo.other;
                OtherBytes = infoStruct.ioInfo.otherBytes;
                IOPriority = infoStruct.ioInfo.ioPriority;
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessModulesInfo) != 0)
            {
                ModuleCount = infoStruct.moduleCount;
                Modules = ConvertToModules(Profiler.ToArray<ProcessModuleInfoStruct>(infoStruct.modules, infoStruct.moduleCount), moduleFlags)!;
            }
        }
        public void Unload(ulong processFlags, ulong moduleFlags)
        {
            if ((processFlags & (ulong)ProcessInfoFlags.ProcessName) != 0)
            {
                _name = "";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessParentName) != 0)
            {
                _parentName = "";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessImageName) != 0)
            {
                _imageName = "";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessUser) != 0)
            {
                _user = "";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessPriority) != 0)
            {
                _priority = "";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessFileVersion) != 0)
            {
                _version = "";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessArchitectureType) != 0)
            {
                ArchitectureType = "";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessIntegrityLevel) != 0)
            {
                _integrityLevel = "";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessCommandLine) != 0)
            {
                _commandLine = "";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessDescription) != 0)
            {
                _description = "";
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessPPID) != 0)
            {
                _ppid = 0;
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessPEB) != 0)
            {
                _peb = 0;
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessTimes) != 0)
            {
                _creationTime = default;
                _exitTime = default;
                _userTime = default;
                _kernelTime = default;
                _totalTime = default;
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessHandlesInfo) != 0)
            {
                _handleCount = 0;
                _handlePeakCount = 0;
                _handleGdiCount = 0;
                _handleUserCount = 0;
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessCycleCount) != 0)
            {
                _cycleCount = 0;
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessMemoryInfo) != 0)
            {
                _privateBytes = 0;
                _peakPrivateBytes = 0;
                _virtualBytes = 0;
                _peakVirtualBytes = 0;
                _workingBytes = 0;
                _peakWorkingBytes = 0;
                _pagePriority = 0;
                _pageFaults = 0;
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessIOInfo) != 0)
            {
                _reads = 0;
                _readBytes = 0;
                _writes = 0;
                _writeBytes = 0;
                _other = 0;
                _otherBytes = 0;
                _ioPriority = 0;
            }

            if ((processFlags & (ulong)ProcessInfoFlags.ProcessModulesInfo) != 0)
            {
                foreach (var mod in _modules)
                    mod.Unload(moduleFlags);
                
                _moduleCount = 0;
                _modules = [];
            }
        }

        public ProcessModuleInfo[] ConvertToModules(ProcessModuleInfoStruct[] moduleInfoStructs, ulong flags)
        {
            var modules = new ProcessModuleInfo[moduleInfoStructs.Length];

            for (int i = 0; i < moduleInfoStructs.Length; i++)
            {
                var moduleInfo = new ProcessModuleInfo();
                moduleInfo.Read(flags, moduleInfoStructs[i]);  // Fill module info using Read method
                modules[i] = moduleInfo;
            }

            return modules;
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
