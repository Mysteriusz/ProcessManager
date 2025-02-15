using ProcessManager.Profiling.Models.Cpu.Models;
using ProcessManager.Profiling.Models.Process.Models;
using System.ComponentModel;

namespace ProcessManager.Profiling.Models.Cpu
{
    public class CpuCacheInfo : INotifyPropertyChanged
    {
        private UInt32 _maxCores;
        private UInt32 _maxThreads;
        private Boolean _associative;
        private Boolean _selfInitializing;
        private UInt32 _level;
        private UInt32 _type;

        private UInt32 _ways;
        private UInt32 _lineCount;
        private UInt32 _lineSize;

        private UInt32 _setCount;

        private Boolean _complexIndexing;
        private Boolean _inclusive;
        private Boolean _wbinvd;

        private UInt32 _size;

        public UInt32 MaxCores
        {
            get => _maxCores;
            set
            {
                if (_maxCores != value)
                {
                    _maxCores = value;
                    OnPropertyChanged(nameof(MaxCores));
                }
            }
        }
        public UInt32 MaxThreads
        {
            get => _maxThreads;
            set
            {
                if (_maxThreads != value)
                {
                    _maxThreads = value;
                    OnPropertyChanged(nameof(MaxThreads));
                }
            }
        }
        public Boolean Associative
        {
            get => _associative;
            set
            {
                if (_associative != value)
                {
                    _associative = value;
                    OnPropertyChanged(nameof(Associative));
                }
            }
        }
        public Boolean SelfInitializing
        {
            get => _selfInitializing;
            set
            {
                if (_selfInitializing != value)
                {
                    _selfInitializing = value;
                    OnPropertyChanged(nameof(SelfInitializing));
                }
            }
        }
        public UInt32 Level
        {
            get => _level;
            set
            {
                if (_level != value)
                {
                    _level = value;
                    OnPropertyChanged(nameof(Level));
                }
            }
        }
        public UInt32 Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }
        public UInt32 Ways
        {
            get => _ways;
            set
            {
                if (_ways != value)
                {
                    _ways = value;
                    OnPropertyChanged(nameof(Ways));
                }
            }
        }
        public UInt32 LineCount
        {
            get => _lineCount;
            set
            {
                if (_lineCount != value)
                {
                    _lineCount = value;
                    OnPropertyChanged(nameof(LineCount));
                }
            }
        }
        public UInt32 LineSize
        {
            get => _lineSize;
            set
            {
                if (_lineSize != value)
                {
                    _lineSize = value;
                    OnPropertyChanged(nameof(LineSize));
                }
            }
        }
        public UInt32 SetCount
        {
            get => _setCount;
            set
            {
                if (_setCount != value)
                {
                    _setCount = value;
                    OnPropertyChanged(nameof(SetCount));
                }
            }
        }
        public Boolean ComplexIndexing
        {
            get => _complexIndexing;
            set
            {
                if (_complexIndexing != value)
                {
                    _complexIndexing = value;
                    OnPropertyChanged(nameof(ComplexIndexing));
                }
            }
        }
        public Boolean Inclusive
        {
            get => _inclusive;
            set
            {
                if (_inclusive != value)
                {
                    _inclusive = value;
                    OnPropertyChanged(nameof(Inclusive));
                }
            }
        }
        public Boolean Wbinvd
        {
            get => _wbinvd;
            set
            {
                if (_wbinvd != value)
                {
                    _wbinvd = value;
                    OnPropertyChanged(nameof(Wbinvd));
                }
            }
        }
        public UInt32 Size
        {
            get => _size;
            set
            {
                if (_size != value)
                {
                    _size = value;
                    OnPropertyChanged(nameof(Size));
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
        public void Load(ulong flags, CpuCacheInfoStruct infoStruct)
        {
            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_MAX_CORES) != 0)
            {
                MaxCores = infoStruct.maxCores;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_MAX_THREADS) != 0)
            {
                MaxThreads = infoStruct.maxThreads;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_ASSOCIATIVE) != 0)
            {
                Associative = infoStruct.associative;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_SELF_INITIALIZING) != 0)
            {
                SelfInitializing = infoStruct.selfInitializing;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_LEVEL) != 0)
            {
                Level = infoStruct.level;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_TYPE) != 0)
            {
                Type = infoStruct.type;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_WAYS) != 0)
            {
                Ways = infoStruct.ways;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_LINE_COUNT) != 0)
            {
                LineCount = infoStruct.lineCount;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_LINE_SIZE) != 0)
            {
                LineSize = infoStruct.lineSize;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_SET_COUNT) != 0)
            {
                SetCount = infoStruct.setCount;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_COMPLEX_INDEXING) != 0)
            {
                ComplexIndexing = infoStruct.complexIndexing;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_INCLUSIVE) != 0)
            {
                Inclusive = infoStruct.inclusive;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_WBINVD) != 0)
            {
                Wbinvd = infoStruct.wbinvd;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_SIZE) != 0)
            {
                Size = infoStruct.size;
            }
        }
        public void Unload(ulong flags)
        {
            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_MAX_CORES) != 0)
            {
                _maxCores = 0;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_MAX_THREADS) != 0)
            {
                _maxThreads = 0;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_ASSOCIATIVE) != 0)
            {
                _associative = false;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_SELF_INITIALIZING) != 0)
            {
                _selfInitializing = false;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_LEVEL) != 0)
            {
                _level = 0;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_TYPE) != 0)
            {
                _type = 0;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_WAYS) != 0)
            {
                _ways = 0;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_LINE_COUNT) != 0)
            {
                _lineCount = 0;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_LINE_SIZE) != 0)
            {
                _lineSize = 0;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_SET_COUNT) != 0)
            {
                _setCount = 0;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_COMPLEX_INDEXING) != 0)
            {
                _complexIndexing = false;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_INCLUSIVE) != 0)
            {
                _inclusive = false;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_WBINVD) != 0)
            {
                _wbinvd = false;
            }

            if ((flags & (ulong)CpuCacheInfoFlags.CPU_HIF_SIZE) != 0)
            {
                _size = 0;
            }
        }
    }
}
