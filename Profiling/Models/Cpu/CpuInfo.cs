using ProcessManager.Profiling.Models.Sys;
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
        private CpuCacheInfo[] _cacheInfos = [];

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
        public CpuCacheInfo[] CacheInfos
        {
            get => _cacheInfos;
            set
            {
                if (_cacheInfos != value)
                {
                    _cacheInfos = value;
                    OnPropertyChanged(nameof(CacheInfos));
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


    }
}
