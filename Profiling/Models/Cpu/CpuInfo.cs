using ProcessManager.Profiling.Models.Cpu.Models;
using System.ComponentModel;

namespace ProcessManager.Profiling.Models.Cpu
{
    public class CpuInfo : INotifyPropertyChanged
    {
        //
        // ---------------------------------- PROPERTIES ----------------------------------
        //

        // ------------------------ CPU_INFO_STRUCT ------------------------ 
        
        private Double _usage = 0;
        private Double _baseFreq = 0;
        private Double _maxFreq = 0;
        private UInt32 _threads = 0;
        private UInt32 _handles = 0;
        private Boolean _virtualization = false;
        private Boolean _hyperThreading = false;

        public Double Usage
        {
            get => _usage;
            set
            {
                if (_usage != value)
                {
                    _usage = value;
                    OnPropertyChanged(nameof(Usage));
                }
            }
        }
        public Double BaseFreq
        {
            get => _baseFreq;
            set
            {
                if (_baseFreq != value)
                {
                    _baseFreq = value;
                    OnPropertyChanged(nameof(BaseFreq));
                }
            }
        }
        public Double MaxFreq
        {
            get => _maxFreq;
            set
            {
                if (_maxFreq != value)
                {
                    _maxFreq = value;
                    OnPropertyChanged(nameof(MaxFreq));
                }
            }
        }
        public UInt32 Threads
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
        public UInt32 Handles
        {
            get => _handles;
            set
            {
                if (_handles != value)
                {
                    _handles = value;
                    OnPropertyChanged(nameof(Handles));
                }
            }
        }
        public Boolean Virtualization
        {
            get => _virtualization;
            set
            {
                if (_virtualization != value)
                {
                    _virtualization = value;
                    OnPropertyChanged(nameof(Virtualization));
                }
            }
        }
        public Boolean HyperThreading
        {
            get => _hyperThreading;
            set
            {
                if (_hyperThreading != value)
                {
                    _hyperThreading = value;
                    OnPropertyChanged(nameof(HyperThreading));
                }
            }
        }
        
        // ------------------------ CPU_SYSTEM_INFO_STRUCT ------------------------ 

        private UInt32 _sockets = 0;
        private UInt32 _cores = 0;
        private UInt32 _logicalProcessors = 0;
        private UInt32 _numaCount = 0;

        public UInt32 Sockets
        {
            get => _sockets;
            set
            {
                if (_sockets != value)
                {
                    _sockets = value;
                    OnPropertyChanged(nameof(Sockets));
                }
            }
        }
        public UInt32 Cores
        {
            get => _cores;
            set
            {
                if (_cores != value)
                {
                    _cores = value;
                    OnPropertyChanged(nameof(Cores));
                }
            }
        }
        public UInt32 LogicalProcessors
        {
            get => _logicalProcessors;
            set
            {
                if (_logicalProcessors != value)
                {
                    _logicalProcessors = value;
                    OnPropertyChanged(nameof(LogicalProcessors));
                }
            }
        }
        public UInt32 NumaCount
        {
            get => _numaCount;
            set
            {
                if (_numaCount != value)
                {
                    _numaCount = value;
                    OnPropertyChanged(nameof(NumaCount));
                }
            }
        }

        // ------------------------ CPU_MODEL_INFO_STRUCT ------------------------ 

        private String _name = "N/A";
        private String _vendor = "N/A";
        private String _architecture = "N/A";
        private UInt32 _model = 0;
        private UInt32 _family = 0;
        private UInt32 _stepping = 0;

        public String Name
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
        public String Vendor
        {
            get => _vendor;
            set
            {
                if (_vendor != value)
                {
                    _vendor = value;
                    OnPropertyChanged(nameof(Vendor));
                }
            }
        }
        public String Architecture
        {
            get => _architecture;
            set
            {
                if (_architecture != value)
                {
                    _architecture = value;
                    OnPropertyChanged(nameof(Architecture));
                }
            }
        }
        public UInt32 Model
        {
            get => _model;
            set
            {
                if (_model != value)
                {
                    _model = value;
                    OnPropertyChanged(nameof(Model));
                }
            }
        }
        public UInt32 Family
        {
            get => _family;
            set
            {
                if (_family != value)
                {
                    _family = value;
                    OnPropertyChanged(nameof(Family));
                }
            }
        }
        public UInt32 Stepping
        {
            get => _stepping;
            set
            {
                if (_stepping != value)
                {
                    _stepping = value;
                    OnPropertyChanged(nameof(Stepping));
                }
            }
        }

        // ------------------------ CPU_TIMES_INFO_STRUCT ------------------------ 

        private DateTime _workTime;
        private DateTime _kernelTime;
        private DateTime _idleTime;
        private DateTime _dpcTime;
        private DateTime _interruptTime;
        private DateTime _userTime;

        public DateTime WorkTime
        {
            get => _workTime;
            set
            {
                if (_workTime != value)
                {
                    _workTime = value;
                    OnPropertyChanged(nameof(WorkTime));
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
        public DateTime IdleTime
        {
            get => _idleTime;
            set
            {
                if (_idleTime != value)
                {
                    _idleTime = value;
                    OnPropertyChanged(nameof(IdleTime));
                }
            }
        }
        public DateTime DpcTime
        {
            get => _dpcTime;
            set
            {
                if (_dpcTime != value)
                {
                    _dpcTime = value;
                    OnPropertyChanged(nameof(DpcTime));
                }
            }
        }
        public DateTime InterruptTime
        {
            get => _interruptTime;
            set
            {
                if (_interruptTime != value)
                {
                    _interruptTime = value;
                    OnPropertyChanged(nameof(InterruptTime));
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

        // ------------------------ CPU_CACHE_INFO_STRUCT ------------------------ 

        private UInt32 _cacheCount = 0;
        private CpuCacheInfo[] _caches = [];

        public UInt32 CacheCount
        {
            get => _cacheCount;
            set
            {
                if (_cacheCount != value)
                {
                    _cacheCount = value;
                    OnPropertyChanged(nameof(CacheCount));
                }
            }
        }
        public CpuCacheInfo[] Caches
        {
            get => _caches;
            set
            {
                if (_caches != value)
                {
                    _caches = value;
                    OnPropertyChanged(nameof(Caches));
                }
            }
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

        public void Load(CpuInfoStruct infoStruct, ulong cif, ulong sif, ulong mif, ulong tif, ulong hif)
        {
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_USAGE) != 0)
            {
                Usage = infoStruct.usage;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_BASE_FREQ) != 0)
            {
                BaseFreq = infoStruct.baseFreq;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_MAX_FREQ) != 0)
            {
                MaxFreq = infoStruct.maxFreq;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_THREADS) != 0)
            {
                Threads = infoStruct.threads;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_HANDLES) != 0)
            {
                Handles = infoStruct.handles;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_VIRTUALIZATION) != 0)
            {
                Virtualization = infoStruct.virtualization;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_HYPER_THREADING) != 0)
            {
                HyperThreading = infoStruct.hyperThreading;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_SYS_INFO) != 0)
            {
                if ((sif & (UInt64)CpuSystemInfoFlags.CPU_SIF_SOCKETS) != 0)
                    Sockets = infoStruct.sysInfo.sockets;
                if ((sif & (UInt64)CpuSystemInfoFlags.CPU_SIF_CORES) != 0)
                    Cores = infoStruct.sysInfo.cores;
                if ((sif & (UInt64)CpuSystemInfoFlags.CPU_SIF_THREADS) != 0)
                    LogicalProcessors = infoStruct.sysInfo.threads;
                if ((sif & (UInt64)CpuSystemInfoFlags.CPU_SIF_NUMA_COUNT) != 0)
                    NumaCount = infoStruct.sysInfo.numaCount;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_MODEL_INFO) != 0)
            {
                if ((mif & (UInt64)CpuModelInfoFlags.CPU_MIF_NAME) != 0)
                    Name = Profiler.ToString(infoStruct.modelInfo.name) ?? "N/A";
                if ((mif & (UInt64)CpuModelInfoFlags.CPU_MIF_VENDOR) != 0)
                    Vendor = Profiler.ToString(infoStruct.modelInfo.vendor) ?? "N/A";
                if ((mif & (UInt64)CpuModelInfoFlags.CPU_MIF_ARCHITECTURE) != 0)
                    Architecture = Profiler.ToString(infoStruct.modelInfo.architecture) ?? "N/A";
                if ((mif & (UInt64)CpuModelInfoFlags.CPU_MIF_MODEL) != 0)
                    Model = infoStruct.modelInfo.model;
                if ((mif & (UInt64)CpuModelInfoFlags.CPU_MIF_FAMILY) != 0)
                    Family = infoStruct.modelInfo.family;
                if ((mif & (UInt64)CpuModelInfoFlags.CPU_MIF_STEPPING) != 0)
                    Stepping = infoStruct.modelInfo.stepping;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_TIMES_INFO) != 0)
            {
                if ((tif & (UInt64)CpuTimesInfoFlags.CPU_TIF_WORK_TIME) != 0)
                    WorkTime = Profiler.ToDateTime(infoStruct.timesInfo.workTime) ?? new DateTime();
                if ((tif & (UInt64)CpuTimesInfoFlags.CPU_TIF_KERNEL_TIME) != 0)
                    KernelTime = Profiler.ToDateTime(infoStruct.timesInfo.kernelTime) ?? new DateTime();
                if ((tif & (UInt64)CpuTimesInfoFlags.CPU_TIF_IDLE_TIME) != 0)
                    IdleTime = Profiler.ToDateTime(infoStruct.timesInfo.idleTime) ?? new DateTime();
                if ((tif & (UInt64)CpuTimesInfoFlags.CPU_TIF_DPC_TIME) != 0)
                    DpcTime = Profiler.ToDateTime(infoStruct.timesInfo.dpcTime) ?? new DateTime();
                if ((tif & (UInt64)CpuTimesInfoFlags.CPU_TIF_INTERRUPT_TIME) != 0)
                    InterruptTime = Profiler.ToDateTime(infoStruct.timesInfo.interruptTime) ?? new DateTime();
                if ((tif & (UInt64)CpuTimesInfoFlags.CPU_TIF_USER_TIME) != 0)
                    UserTime = Profiler.ToDateTime(infoStruct.timesInfo.userTime) ?? new DateTime();
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_CACHE_INFO) != 0)
            {
                CacheCount = infoStruct.cacheCount;
                Caches = ConvertToCache(Profiler.ToArray<CpuCacheInfoStruct>(infoStruct.cacheInfo, infoStruct.cacheCount), hif)!;
            }
        }
        public void Unload(ulong cif, ulong sif, ulong mif, ulong tif, ulong hif)
        {
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_USAGE) != 0)
            {
                Usage = 0;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_BASE_FREQ) != 0)
            {
                BaseFreq = 0;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_MAX_FREQ) != 0)
            {
                MaxFreq = 0;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_THREADS) != 0)
            {
                Threads = 0;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_HANDLES) != 0)
            {
                Handles = 0;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_VIRTUALIZATION) != 0)
            {
                Virtualization = false;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_HYPER_THREADING) != 0)
            {
                HyperThreading = false;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_SYS_INFO) != 0)
            {
                if ((sif & (UInt64)CpuSystemInfoFlags.CPU_SIF_SOCKETS) != 0)
                    Sockets = 0;
                if ((sif & (UInt64)CpuSystemInfoFlags.CPU_SIF_CORES) != 0)
                    Cores = 0;
                if ((sif & (UInt64)CpuSystemInfoFlags.CPU_SIF_THREADS) != 0)
                    LogicalProcessors = 0;
                if ((sif & (UInt64)CpuSystemInfoFlags.CPU_SIF_NUMA_COUNT) != 0)
                    NumaCount = 0;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_MODEL_INFO) != 0)
            {
                if ((mif & (UInt64)CpuModelInfoFlags.CPU_MIF_NAME) != 0)
                    Name = "N/A";
                if ((mif & (UInt64)CpuModelInfoFlags.CPU_MIF_VENDOR) != 0)
                    Vendor = "N/A";
                if ((mif & (UInt64)CpuModelInfoFlags.CPU_MIF_ARCHITECTURE) != 0)
                    Architecture = "N/A";
                if ((mif & (UInt64)CpuModelInfoFlags.CPU_MIF_MODEL) != 0)
                    Model = 0;
                if ((mif & (UInt64)CpuModelInfoFlags.CPU_MIF_FAMILY) != 0)
                    Family = 0;
                if ((mif & (UInt64)CpuModelInfoFlags.CPU_MIF_STEPPING) != 0)
                    Stepping = 0;
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_TIMES_INFO) != 0)
            {
                if ((tif & (UInt64)CpuTimesInfoFlags.CPU_TIF_WORK_TIME) != 0)
                    WorkTime = new DateTime();
                if ((tif & (UInt64)CpuTimesInfoFlags.CPU_TIF_KERNEL_TIME) != 0)
                    KernelTime = new DateTime();
                if ((tif & (UInt64)CpuTimesInfoFlags.CPU_TIF_IDLE_TIME) != 0)
                    IdleTime = new DateTime();
                if ((tif & (UInt64)CpuTimesInfoFlags.CPU_TIF_DPC_TIME) != 0)
                    DpcTime = new DateTime();
                if ((tif & (UInt64)CpuTimesInfoFlags.CPU_TIF_INTERRUPT_TIME) != 0)
                    InterruptTime = new DateTime();
                if ((tif & (UInt64)CpuTimesInfoFlags.CPU_TIF_USER_TIME) != 0)
                    UserTime = new DateTime();
            }
            if ((cif & (UInt64)CpuInfoFlags.CPU_CIF_CACHE_INFO) != 0)
            {
                foreach (var cache in Caches)
                    cache.Unload(hif);
            }
        }

        public CpuCacheInfo[] ConvertToCache(CpuCacheInfoStruct[] cacheInfoStruct, ulong flags)
        {
            var caches = new CpuCacheInfo[cacheInfoStruct.Length];

            for (int i = 0; i < cacheInfoStruct.Length; i++)
            {
                var cacheInfo = new CpuCacheInfo();
                cacheInfo.Load(flags, cacheInfoStruct[i]);
                caches[i] = cacheInfo;
            }

            return caches;
        }
    }
}
