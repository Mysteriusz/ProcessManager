using ProcessManager.Profiling.Models.Process.Models;
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

        // ------------------------ PROCESS_INFO_STRUCT ------------------------ 

        private string _name = "N/A";
        private string _parentName = "N/A";
        private string _user = "N/A";
        private string _imageName = "N/A";
        private string _version = "N/A";
        private string _integrityLevel = "N/A";
        private string _architectureType = "N/A";
        private string _commandLine = "N/A";
        private string _description = "N/A";
        private UInt64 _peb = 0;
        private UInt64 _affinity = 0;
        private UInt32 _pid = 0;
        private UInt32 _ppid = 0;
        private UInt32 _priority = 0;

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
        public UInt64 Affinity
        {
            get => _affinity;
            set
            {
                if (_affinity != value)
                {
                    _affinity = value;
                    OnPropertyChanged(nameof(Affinity));
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
        public UInt32 Priority
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
            Priority = infoStruct.priority;
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

        public void Load(ProcessInfoStruct infoStruct, ulong pif, ulong mif, ulong hif, ulong rif, ulong tif, ulong eif, ulong cif, ulong oif)
        {
            PID = infoStruct.pid;

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_NAME) != 0)
            {
                Name = Profiler.ToString(infoStruct.name) ?? "N/A";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_PARENT_NAME) != 0)
            {
                ParentName = Profiler.ToString(infoStruct.parentProcessName) ?? "N/A";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_IMAGE_NAME) != 0)
            {
                ImageName = Profiler.ToString(infoStruct.imageName) ?? "N/A";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_USER) != 0)
            {
                User = Profiler.ToString(infoStruct.user) ?? "N/A";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_PRIORITY) != 0)
            {
                Priority = infoStruct.priority;
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_FILE_VERSION) != 0)
            {
                Version = Profiler.ToString(infoStruct.fileVersion) ?? "N/A";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_ARCHITECTURE_TYPE) != 0)
            {
                ArchitectureType = Profiler.ToString(infoStruct.architectureType) ?? "N/A";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_INTEGRITY_LEVEL) != 0)
            {
                IntegrityLevel = Profiler.ToString(infoStruct.integrityLevel) ?? "N/A";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_COMMAND_LINE) != 0)
            {
                CommandLine = Profiler.ToString(infoStruct.cmd) ?? "N/A";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_DESCRIPTION) != 0)
            {
                Description = Profiler.ToString(infoStruct.description) ?? "N/A";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_PPID) != 0)
            {
                PPID = infoStruct.ppid;
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_PEB) != 0)
            {
                PEB = infoStruct.peb;
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_TIMES) != 0)
            {
                if ((tif & (UInt64)ProcessTimesInfoFlags.PROCESS_TIF_CREATION_TIME) != 0)
                    CreationTime = Profiler.ToDateTime(infoStruct.timesInfo.creationTime) ?? new DateTime();
                if ((tif & (UInt64)ProcessTimesInfoFlags.PROCESS_TIF_EXIT_TIME) != 0)
                    ExitTime = Profiler.ToDateTime(infoStruct.timesInfo.exitTime, true) ?? new DateTime();
                if ((tif & (UInt64)ProcessTimesInfoFlags.PROCESS_TIF_USER_TIME) != 0)
                    UserTime = Profiler.ToDateTime(infoStruct.timesInfo.userTime, true) ?? new DateTime();
                if ((tif & (UInt64)ProcessTimesInfoFlags.PROCESS_TIF_KERNEL_TIME) != 0)
                    KernelTime = Profiler.ToDateTime(infoStruct.timesInfo.kernelTime, true) ?? new DateTime();
                if ((tif & (UInt64)ProcessTimesInfoFlags.PROCESS_TIF_TOTAL_TIME) != 0)
                    TotalTime = Profiler.ToDateTime(infoStruct.timesInfo.totalTime, true) ?? new DateTime();
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_CPU_INFO) != 0)
            {
                if ((cif & (UInt64)ProcessCpuInfoFlags.PROCESS_CIF_CYCLES) != 0)
                    CycleCount = infoStruct.cpuInfo.cycles;
                if ((cif & (UInt64)ProcessCpuInfoFlags.PROCESS_CIF_USAGE) != 0)
                    CpuUsage = infoStruct.cpuInfo.usage;
                if ((cif & (UInt64)ProcessCpuInfoFlags.PROCESS_CIF_AFFINITY) != 0)
                    Affinity = infoStruct.cpuInfo.affinity;
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_MEMORY_INFO) != 0)
            {
                if ((eif & (UInt64)ProcessMemoryInfoFlags.PROCESS_EIF_PRIVATE_BYTES) != 0)
                    PrivateBytes = infoStruct.memoryInfo.privateBytes;
                if ((eif & (UInt64)ProcessMemoryInfoFlags.PROCESS_EIF_PEAK_PRIVATE_BYTES) != 0)
                    PeakPrivateBytes = infoStruct.memoryInfo.peakPrivateBytes;
                if ((eif & (UInt64)ProcessMemoryInfoFlags.PROCESS_EIF_VIRTUAL_BYTES) != 0)
                    VirtualBytes = infoStruct.memoryInfo.virtualBytes;
                if ((eif & (UInt64)ProcessMemoryInfoFlags.PROCESS_EIF_PEAK_VIRTUAL_BYTES) != 0)
                    PeakVirtualBytes = infoStruct.memoryInfo.peakVirtualBytes;
                if ((eif & (UInt64)ProcessMemoryInfoFlags.PROCESS_EIF_WORKING_BYTES) != 0)
                    WorkingBytes = infoStruct.memoryInfo.workingBytes;
                if ((eif & (UInt64)ProcessMemoryInfoFlags.PROCESS_EIF_PEAK_WORKING_BYTES) != 0)
                    PeakWorkingBytes = infoStruct.memoryInfo.peakWorkingBytes;
                if ((eif & (UInt64)ProcessMemoryInfoFlags.PROCESS_EIF_PAGE_PRIORITY) != 0)
                    PagePriority = infoStruct.memoryInfo.priority;
                if ((eif & (UInt64)ProcessMemoryInfoFlags.PROCESS_EIF_PAGE_FAULTS) != 0)
                    PageFaults = infoStruct.memoryInfo.pageFaults;
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_IO_INFO) != 0)
            {
                if ((oif & (UInt64)ProcessIOInfoFlags.PROCESS_OIF_READS) != 0)
                    Reads = infoStruct.ioInfo.reads;
                if ((oif & (UInt64)ProcessIOInfoFlags.PROCESS_OIF_READ_BYTES) != 0)
                    ReadBytes = infoStruct.ioInfo.readBytes;
                if ((oif & (UInt64)ProcessIOInfoFlags.PROCESS_OIF_WRITES) != 0)
                    Writes = infoStruct.ioInfo.writes;
                if ((oif & (UInt64)ProcessIOInfoFlags.PROCESS_OIF_WRITE_BYTES) != 0)
                    WriteBytes = infoStruct.ioInfo.writeBytes;
                if ((oif & (UInt64)ProcessIOInfoFlags.PROCESS_OIF_OTHER) != 0)
                    Other = infoStruct.ioInfo.other;
                if ((oif & (UInt64)ProcessIOInfoFlags.PROCESS_OIF_OTHER_BYTES) != 0)
                    OtherBytes = infoStruct.ioInfo.otherBytes;
                if ((oif & (UInt64)ProcessIOInfoFlags.PROCESS_OIF_IO_PRIORITY) != 0)
                    IOPriority = infoStruct.ioInfo.ioPriority;
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_HANDLES_INFO) != 0)
            {
                HandleCount = infoStruct.handleCount;
                HandlePeakCount = infoStruct.handlePeakCount;
                GdiHandleCount = infoStruct.gdiHandleCount;
                UserHandleCount = infoStruct.userHandleCount;

                Handles = ConvertToHandles(Profiler.ToArray<ProcessHandleInfoStruct>(infoStruct.handles, infoStruct.handleCount), hif)!;
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_MODULES_INFO) != 0)
            {
                ModuleCount = infoStruct.moduleCount;
                Modules = ConvertToModules(Profiler.ToArray<ProcessModuleInfoStruct>(infoStruct.modules, infoStruct.moduleCount), mif)!;
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_THREADS_INFO) != 0)
            {
                ThreadCount = infoStruct.threadCount;
                Threads = ConvertToThreads(Profiler.ToArray<ProcessThreadInfoStruct>(infoStruct.threads, infoStruct.threadCount), rif)!;
            }
        }
        public void Unload(ulong pif, ulong mif, ulong hif, ulong rif, ulong tif, ulong eif, ulong cif, ulong oif)
        {
            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_NAME) != 0)
            {
                _name = "";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_PARENT_NAME) != 0)
            {
                _parentName = "";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_IMAGE_NAME) != 0)
            {
                _imageName = "";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_USER) != 0)
            {
                _user = "";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_PRIORITY) != 0)
            {
                _priority = 0;
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_FILE_VERSION) != 0)
            {
                _version = "";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_ARCHITECTURE_TYPE) != 0)
            {
                _architectureType = "";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_INTEGRITY_LEVEL) != 0)
            {
                _integrityLevel = "";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_COMMAND_LINE) != 0)
            {
                _commandLine = "";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_DESCRIPTION) != 0)
            {
                _description = "";
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_PPID) != 0)
            {
                _ppid = 0;
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_PEB) != 0)
            {
                _peb = 0;
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_TIMES) != 0)
            {
                if ((tif & (UInt64)ProcessTimesInfoFlags.PROCESS_TIF_CREATION_TIME) != 0)
                    _creationTime = default;
                if ((tif & (UInt64)ProcessTimesInfoFlags.PROCESS_TIF_EXIT_TIME) != 0)
                    _exitTime = default;
                if ((tif & (UInt64)ProcessTimesInfoFlags.PROCESS_TIF_USER_TIME) != 0)
                    _userTime = default;
                if ((tif & (UInt64)ProcessTimesInfoFlags.PROCESS_TIF_KERNEL_TIME) != 0)
                    _kernelTime = default;
                if ((tif & (UInt64)ProcessTimesInfoFlags.PROCESS_TIF_TOTAL_TIME) != 0)
                    _totalTime = default;
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_CPU_INFO) != 0)
            {
                if ((cif & (UInt64)ProcessCpuInfoFlags.PROCESS_CIF_CYCLES) != 0)
                    _cycleCount = 0;
                if ((cif & (UInt64)ProcessCpuInfoFlags.PROCESS_CIF_USAGE) != 0)
                    _cpuUsage = 0;
                if ((cif & (UInt64)ProcessCpuInfoFlags.PROCESS_CIF_AFFINITY) != 0)
                    _affinity = 0;
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_MEMORY_INFO) != 0)
            {
                if ((eif & (UInt64)ProcessMemoryInfoFlags.PROCESS_EIF_PRIVATE_BYTES) != 0)
                    _privateBytes = 0;
                if ((eif & (UInt64)ProcessMemoryInfoFlags.PROCESS_EIF_PEAK_PRIVATE_BYTES) != 0)
                    _peakPrivateBytes = 0;
                if ((eif & (UInt64)ProcessMemoryInfoFlags.PROCESS_EIF_VIRTUAL_BYTES) != 0)
                    _virtualBytes = 0;
                if ((eif & (UInt64)ProcessMemoryInfoFlags.PROCESS_EIF_PEAK_VIRTUAL_BYTES) != 0)
                    _peakVirtualBytes = 0;
                if ((eif & (UInt64)ProcessMemoryInfoFlags.PROCESS_EIF_WORKING_BYTES) != 0)
                    _workingBytes = 0;
                if ((eif & (UInt64)ProcessMemoryInfoFlags.PROCESS_EIF_PEAK_WORKING_BYTES) != 0)
                    _peakWorkingBytes = 0;
                if ((eif & (UInt64)ProcessMemoryInfoFlags.PROCESS_EIF_PAGE_PRIORITY) != 0)
                    _pagePriority = 0;
                if ((eif & (UInt64)ProcessMemoryInfoFlags.PROCESS_EIF_PAGE_FAULTS) != 0)
                    _pageFaults = 0;
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_IO_INFO) != 0)
            {
                if ((oif & (UInt64)ProcessIOInfoFlags.PROCESS_OIF_READS) != 0)
                    _reads = 0;
                if ((oif & (UInt64)ProcessIOInfoFlags.PROCESS_OIF_READ_BYTES) != 0)
                    _readBytes = 0;
                if ((oif & (UInt64)ProcessIOInfoFlags.PROCESS_OIF_WRITES) != 0)
                    _writes = 0;
                if ((oif & (UInt64)ProcessIOInfoFlags.PROCESS_OIF_WRITE_BYTES) != 0)
                    _writeBytes = 0;
                if ((oif & (UInt64)ProcessIOInfoFlags.PROCESS_OIF_OTHER) != 0)
                    _other = 0;
                if ((oif & (UInt64)ProcessIOInfoFlags.PROCESS_OIF_OTHER_BYTES) != 0)
                    _otherBytes = 0;
                if ((oif & (UInt64)ProcessIOInfoFlags.PROCESS_OIF_IO_PRIORITY) != 0)
                    _ioPriority = 0;
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_HANDLES_INFO) != 0)
            {
                foreach (var han in _handles)
                    han.Unload(hif);

                _handles = [];
                _handleCount = 0;
                _handlePeakCount = 0;
                _handleGdiCount = 0;
                _handleUserCount = 0;
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_MODULES_INFO) != 0)
            {
                foreach (var mod in _modules)
                    mod.Unload(mif);

                _moduleCount = 0;
                _modules = [];
            }

            if ((pif & (UInt64)ProcessInfoFlags.PROCESS_PIF_THREADS_INFO) != 0)
            {
                foreach (var th in _threads)
                    th.Unload(rif);

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
