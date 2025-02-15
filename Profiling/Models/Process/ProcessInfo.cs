using System.Windows.Interop;
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
        private UInt64 _peb = 0;
        private UInt32 _pid = 0;
        private UInt32 _ppid = 0;

        // ------------------------ GENERAL ------------------------ 
 
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
        public UInt64 PEB
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
        public UInt32 PID
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
        public UInt32 PPID
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

        // ------------------------ PROCESS_HANDLE_INFO ------------------------ 

        private UInt32 _handleCount;
        private UInt32 _handlePeakCount;
        private UInt32 _handleGdiCount;
        private UInt32 _handleUserCount;
        private ProcessHandleInfo[] _handles = [];

        public UInt32 HandleCount
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
        public UInt32 HandlePeakCount
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
        public UInt32 GdiHandleCount
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
        public UInt32 UserHandleCount
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
        public ProcessHandleInfo[] Handles
        {
            get
            {
                return _handles;
            }
            set
            {
                if (_handles != value)
                {
                    _handles = value;
                    OnPropertyChanged(nameof(Handles));
                }
            }
        }

        // ------------------------ PROCESS_MODULE_INFO ------------------------ 

        private UInt32 _moduleCount;
        private ProcessModuleInfo[] _modules = [];

        public UInt32 ModuleCount
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

        // ------------------------ PROCESS_THREAD_INFO ------------------------ 

        private UInt32 _threadCount;
        private ProcessThreadInfo[] _threads = [];

        public UInt32 ThreadCount
        {
            get => _threadCount;
            set
            {
                if (_threadCount != value)
                {
                    _threadCount = value;
                    OnPropertyChanged(nameof(ThreadCount));
                }
            }
        }
        public ProcessThreadInfo[] Threads
        {
            get => _threads;
            set
            {
                if (_threads != value)
                {
                    _threads = value;
                    OnPropertyChanged(nameof(Threads));
                }
            }
        }

        // ------------------------ PROCESS_MEMORY_INFO ------------------------ 

        private UInt32 _privateBytes;
        private UInt32 _peakPrivateBytes;
        private UInt32 _virtualBytes;
        private UInt32 _peakVirtualBytes;
        private UInt32 _pageFaults;
        private UInt32 _workingBytes;
        private UInt32 _peakWorkingBytes;
        private UInt64 _pagePriority;

        public UInt32 PrivateBytes
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
        public UInt32 PeakPrivateBytes
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
        public UInt32 VirtualBytes
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
        public UInt32 PeakVirtualBytes
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
        public UInt32 PageFaults
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
        public UInt32 WorkingBytes
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
        public UInt32 PeakWorkingBytes
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
        public UInt64 PagePriority
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

        private UInt64 _reads;
        private UInt64 _readBytes;
        private UInt64 _writes;
        private UInt64 _writeBytes;
        private UInt64 _other;
        private UInt64 _otherBytes;
        private UInt32 _ioPriority;

        public UInt64 Reads
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
        public UInt64 ReadBytes
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
        public UInt64 Writes
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
        public UInt64 WriteBytes
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
        public UInt64 Other
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
        public UInt64 OtherBytes
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
        public UInt32 IOPriority
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

        // ------------------------ PROCESS_CPU_INFO ------------------------ 

        private Double _cpuUsage;
        private UInt64 _cycleCount;
        
        public Double CpuUsage
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
        public UInt64 CycleCount
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

            _handleCount = infoStruct.handleCount;
            _handlePeakCount = infoStruct.handlePeakCount;
        }

        //
        // ---------------------------------- EVENTS ----------------------------------
        //

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //
        // ---------------------------------- METHODS ----------------------------------
        //

        public void Load(ProcessInfoStruct infoStruct, UInt64 processFlags = 0, UInt64 moduleFlags = 0, UInt64 handleFlags = 0, UInt64 threadFlags = 0)
        {
            PID = infoStruct.pid;

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessName) != 0)
            {
                Name = Profiler.ToString(infoStruct.name) ?? "N/A";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessParentName) != 0)
            {
                ParentName = Profiler.ToString(infoStruct.parentProcessName) ?? "N/A";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessImageName) != 0)
            {
                ImageName = Profiler.ToString(infoStruct.imageName) ?? "N/A";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessUser) != 0)
            {
                User = Profiler.ToString(infoStruct.user) ?? "N/A";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessPriority) != 0)
            {
                Priority = Profiler.ToString(infoStruct.priority) ?? "N/A";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessFileVersion) != 0)
            {
                Version = Profiler.ToString(infoStruct.fileVersion) ?? "N/A";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessArchitectureType) != 0)
            {
                ArchitectureType = Profiler.ToString(infoStruct.architectureType) ?? "N/A";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessIntegrityLevel) != 0)
            {
                IntegrityLevel = Profiler.ToString(infoStruct.integrityLevel) ?? "N/A";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessCommandLine) != 0)
            {
                CommandLine = Profiler.ToString(infoStruct.cmd) ?? "N/A";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessDescription) != 0)
            {
                Description = Profiler.ToString(infoStruct.description) ?? "N/A";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessPPID) != 0)
            {
                PPID = infoStruct.ppid;
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessPEB) != 0)
            {
                PEB = infoStruct.peb;
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessTimes) != 0)
            {
                CreationTime = Profiler.ToDateTime(infoStruct.timesInfo.creationTime) ?? new DateTime();
                ExitTime = Profiler.ToDateTime(infoStruct.timesInfo.exitTime, true) ?? new DateTime();
                UserTime = Profiler.ToDateTime(infoStruct.timesInfo.userTime, true) ?? new DateTime();
                KernelTime = Profiler.ToDateTime(infoStruct.timesInfo.kernelTime, true) ?? new DateTime();
                TotalTime = Profiler.ToDateTime(infoStruct.timesInfo.totalTime, true) ?? new DateTime();
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessCpuInfo) != 0)
            {
                CycleCount = infoStruct.cpuInfo.cycles;
                CpuUsage = infoStruct.cpuInfo.usage;
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessMemoryInfo) != 0)
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

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessIOInfo) != 0)
            {
                Reads = infoStruct.ioInfo.reads;
                ReadBytes = infoStruct.ioInfo.readBytes;
                Writes = infoStruct.ioInfo.writes;
                WriteBytes = infoStruct.ioInfo.writeBytes;
                Other = infoStruct.ioInfo.other;
                OtherBytes = infoStruct.ioInfo.otherBytes;
                IOPriority = infoStruct.ioInfo.ioPriority;
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessHandlesInfo) != 0)
            {
                HandleCount = infoStruct.handleCount;
                HandlePeakCount = infoStruct.handlePeakCount;
                GdiHandleCount = infoStruct.gdiHandleCount;
                UserHandleCount = infoStruct.userHandleCount;

                Handles = ConvertToHandles(Profiler.ToArray<ProcessHandleInfoStruct>(infoStruct.handles, infoStruct.handleCount), handleFlags)!;
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessModulesInfo) != 0)
            {
                ModuleCount = infoStruct.moduleCount;
                Modules = ConvertToModules(Profiler.ToArray<ProcessModuleInfoStruct>(infoStruct.modules, infoStruct.moduleCount), moduleFlags)!;
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessThreadsInfo) != 0)
            {
                ThreadCount = infoStruct.threadCount;
                Threads = ConvertToThreads(Profiler.ToArray<ProcessThreadInfoStruct>(infoStruct.threads, infoStruct.threadCount), threadFlags)!;
            }
        }
        public void Unload(UInt64 processFlags = 0, UInt64 moduleFlags = 0, UInt64 handleFlags = 0, UInt64 threadFlags = 0)
        {
            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessName) != 0)
            {
                _name = "";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessParentName) != 0)
            {
                _parentName = "";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessImageName) != 0)
            {
                _imageName = "";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessUser) != 0)
            {
                _user = "";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessPriority) != 0)
            {
                _priority = "";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessFileVersion) != 0)
            {
                _version = "";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessArchitectureType) != 0)
            {
                ArchitectureType = "";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessIntegrityLevel) != 0)
            {
                _integrityLevel = "";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessCommandLine) != 0)
            {
                _commandLine = "";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessDescription) != 0)
            {
                _description = "";
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessPPID) != 0)
            {
                _ppid = 0;
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessPEB) != 0)
            {
                _peb = 0;
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessTimes) != 0)
            {
                _creationTime = default;
                _exitTime = default;
                _userTime = default;
                _kernelTime = default;
                _totalTime = default;
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessCpuInfo) != 0)
            {
                _cycleCount = 0;
                _cpuUsage = 0;
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessMemoryInfo) != 0)
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

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessIOInfo) != 0)
            {
                _reads = 0;
                _readBytes = 0;
                _writes = 0;
                _writeBytes = 0;
                _other = 0;
                _otherBytes = 0;
                _ioPriority = 0;
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessHandlesInfo) != 0)
            {
                foreach (var han in _handles)
                    han.Unload(handleFlags);

                _handles = [];
                _handleCount = 0;
                _handlePeakCount = 0;
                _handleGdiCount = 0;
                _handleUserCount = 0;
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessModulesInfo) != 0)
            {
                foreach (var mod in _modules)
                    mod.Unload(moduleFlags);
                
                _moduleCount = 0;
                _modules = [];
            }

            if ((processFlags & (UInt64)ProcessInfoFlags.ProcessThreadsInfo) != 0)
            {
                foreach (var th in _threads)
                    th.Unload(threadFlags);

                _threadCount = 0;
                _threads = [];
            }
        }

        public ProcessModuleInfo[] ConvertToModules(ProcessModuleInfoStruct[] moduleInfoStructs, UInt64 flags)
        {
            var modules = new ProcessModuleInfo[moduleInfoStructs.Length];

            for (int i = 0; i < moduleInfoStructs.Length; i++)
            {
                var moduleInfo = new ProcessModuleInfo();
                moduleInfo.Load(flags, moduleInfoStructs[i]);
                modules[i] = moduleInfo;
            }

            return modules;
        }
        public ProcessHandleInfo[] ConvertToHandles(ProcessHandleInfoStruct[] handleInfoStructs, UInt64 flags)
        {
            var handles = new ProcessHandleInfo[handleInfoStructs.Length];

            for (int i = 0; i < handleInfoStructs.Length; i++)
            {
                var handleInfo = new ProcessHandleInfo();
                handleInfo.Load(flags, handleInfoStructs[i]);
                handles[i] = handleInfo;
            }

            return handles;
        }
        public ProcessThreadInfo[] ConvertToThreads(ProcessThreadInfoStruct[] threadInfoStructs, UInt64 flags)
        {
            var threads = new ProcessThreadInfo[threadInfoStructs.Length];

            for (int i = 0; i < threadInfoStructs.Length; i++)
            {
                var threadInfo = new ProcessThreadInfo();
                threadInfo.Load(flags, threadInfoStructs[i]);
                threads[i] = threadInfo;
            }

            return threads;
        }
    }
}
