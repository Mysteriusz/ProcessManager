using ProcessManager.Profiling.Models.Ram.Models;
using System.ComponentModel;

namespace ProcessManager.Profiling.Models.Ram
{
    public class RamBlockInfo : INotifyPropertyChanged
    {
        private String _deviceLocator = "N/A";
        private String _bankLocator = "N/A";
        private String _vendor = "N/A";
        private UInt16 _arrHandle;
        private UInt16 _errInfoHandle;
        private UInt16 _totalWidth;
        private UInt16 _dataWidth;
        private UInt16 _typeDetail;
        private UInt16 _size;
        private UInt16 _speed;
        private UInt16 _minVoltage;
        private UInt16 _maxVoltage;
        private UInt16 _configVoltage;
        private Byte _formFactor;
        private Byte _deviceSet;
        private Byte _memoryType;
        private UInt32 _extendedSize;

        public String DeviceLocator
        {
            get { return _deviceLocator; }
            set
            {
                if (_deviceLocator != value)
                {
                    _deviceLocator = value;
                    OnPropertyChanged(nameof(DeviceLocator));
                }
            }
        }
        public String BankLocator
        {
            get { return _bankLocator; }
            set
            {
                if (_bankLocator != value)
                {
                    _bankLocator = value;
                    OnPropertyChanged(nameof(BankLocator));
                }
            }
        }
        public String Vendor
        {
            get { return _vendor; }
            set
            {
                if (_vendor != value)
                {
                    _vendor = value;
                    OnPropertyChanged(nameof(Vendor));
                }
            }
        }
        public UInt16 ArrHandle
        {
            get { return _arrHandle; }
            set
            {
                if (_arrHandle != value)
                {
                    _arrHandle = value;
                    OnPropertyChanged(nameof(ArrHandle));
                }
            }
        }
        public UInt16 ErrInfoHandle
        {
            get { return _errInfoHandle; }
            set
            {
                if (_errInfoHandle != value)
                {
                    _errInfoHandle = value;
                    OnPropertyChanged(nameof(ErrInfoHandle));
                }
            }
        }
        public UInt16 TotalWidth
        {
            get { return _totalWidth; }
            set
            {
                if (_totalWidth != value)
                {
                    _totalWidth = value;
                    OnPropertyChanged(nameof(TotalWidth));
                }
            }
        }
        public UInt16 DataWidth
        {
            get { return _dataWidth; }
            set
            {
                if (_dataWidth != value)
                {
                    _dataWidth = value;
                    OnPropertyChanged(nameof(DataWidth));
                }
            }
        }
        public UInt16 TypeDetail
        {
            get { return _typeDetail; }
            set
            {
                if (_typeDetail != value)
                {
                    _typeDetail = value;
                    OnPropertyChanged(nameof(TypeDetail));
                }
            }
        }
        public UInt16 Size
        {
            get { return _size; }
            set
            {
                if (_size != value)
                {
                    _size = value;
                    OnPropertyChanged(nameof(Size));
                }
            }
        }
        public UInt16 Speed
        {
            get { return _speed; }
            set
            {
                if (_speed != value)
                {
                    _speed = value;
                    OnPropertyChanged(nameof(Speed));
                }
            }
        }
        public UInt16 MinVoltage
        {
            get { return _minVoltage; }
            set
            {
                if (_minVoltage != value)
                {
                    _minVoltage = value;
                    OnPropertyChanged(nameof(MinVoltage));
                }
            }
        }
        public UInt16 MaxVoltage
        {
            get { return _maxVoltage; }
            set
            {
                if (_maxVoltage != value)
                {
                    _maxVoltage = value;
                    OnPropertyChanged(nameof(MaxVoltage));
                }
            }
        }
        public UInt16 ConfigVoltage
        {
            get { return _configVoltage; }
            set
            {
                if (_configVoltage != value)
                {
                    _configVoltage = value;
                    OnPropertyChanged(nameof(ConfigVoltage));
                }
            }
        }
        public Byte FormFactor
        {
            get { return _formFactor; }
            set
            {
                if (_formFactor != value)
                {
                    _formFactor = value;
                    OnPropertyChanged(nameof(FormFactor));
                }
            }
        }
        public Byte DeviceSet
        {
            get { return _deviceSet; }
            set
            {
                if (_deviceSet != value)
                {
                    _deviceSet = value;
                    OnPropertyChanged(nameof(DeviceSet));
                }
            }
        }
        public Byte MemoryType
        {
            get { return _memoryType; }
            set
            {
                if (_memoryType != value)
                {
                    _memoryType = value;
                    OnPropertyChanged(nameof(MemoryType));
                }
            }
        }
        public UInt32 ExtendedSize
        {
            get { return _extendedSize; }
            set
            {
                if (_extendedSize != value)
                {
                    _extendedSize = value;
                    OnPropertyChanged(nameof(ExtendedSize));
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

        public void Load(RamBlockInfoStruct infoStruct, ulong bif)
        {
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_DEVICE_LOCATOR) != 0)
            {
                DeviceLocator = Profiler.ToString(infoStruct.deviceLocator) ?? "N/A";
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_BANK_LOCATOR) != 0)
            {
                BankLocator = Profiler.ToString(infoStruct.bankLocator) ?? "N/A";
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_VENDOR) != 0)
            {
                Vendor = Profiler.ToString(infoStruct.vendor) ?? "N/A";
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_ARR_HANDLE) != 0)
            {
                ArrHandle = infoStruct.arrHandle;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_ERR_INFO_HANDLE) != 0)
            {
                ErrInfoHandle = infoStruct.errInfoHandle;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_TOTAL_WIDTH) != 0)
            {
                TotalWidth = infoStruct.totalWidth;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_DATA_WIDTH) != 0)
            {
                DataWidth = infoStruct.dataWidth;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_TYPE_DETAIL) != 0)
            {
                TypeDetail = infoStruct.typeDetail;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_SIZE) != 0)
            {
                Size = infoStruct.size;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_SPEED) != 0)
            {
                Speed = infoStruct.speed;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_MIN_VOLTAGE) != 0)
            {
                MinVoltage = infoStruct.minVoltage;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_MAX_VOLTAGE) != 0)
            {
                MaxVoltage = infoStruct.maxVoltage;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_CONFIG_VOLTAGE) != 0)
            {
                ConfigVoltage = infoStruct.configVoltage;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_FORM_FACTOR) != 0)
            {
                FormFactor = infoStruct.formFactor;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_DEVICE_SET) != 0)
            {
                DeviceSet = infoStruct.deviceSet;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_MEMORY_TYPE) != 0)
            {
                MemoryType = infoStruct.memoryType;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_EXTENDED_SIZE) != 0)
            {
                ExtendedSize = infoStruct.extendedSize;
            }
        }
        public void Unload(ulong bif)
        {
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_DEVICE_LOCATOR) != 0)
            {
                _deviceLocator = "";
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_BANK_LOCATOR) != 0)
            {
                _bankLocator = "";
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_VENDOR) != 0)
            {
                _vendor = "";
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_ARR_HANDLE) != 0)
            {
                _arrHandle = 0;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_ERR_INFO_HANDLE) != 0)
            {
                _errInfoHandle = 0;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_TOTAL_WIDTH) != 0)
            {
                _totalWidth = 0;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_DATA_WIDTH) != 0)
            {
                _dataWidth = 0;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_TYPE_DETAIL) != 0)
            {
                _typeDetail = 0;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_SIZE) != 0)
            {
                _size = 0;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_SPEED) != 0)
            {
                _speed = 0;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_MIN_VOLTAGE) != 0)
            {
                _minVoltage = 0;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_MAX_VOLTAGE) != 0)
            {
                _maxVoltage = 0;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_CONFIG_VOLTAGE) != 0)
            {
                _configVoltage = 0;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_FORM_FACTOR) != 0)
            {
                _formFactor = 0;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_DEVICE_SET) != 0)
            {
                _deviceSet = 0;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_MEMORY_TYPE) != 0)
            {
                _memoryType = 0;
            }
            if ((bif & (ulong)RamBlockInfoFlags.RAM_BIF_EXTENDED_SIZE) != 0)
            {
                _extendedSize = 0;
            }
        }
    }
}
