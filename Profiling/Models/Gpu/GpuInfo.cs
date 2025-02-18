using ProcessManager.Profiling.Models.Gpu.Models;
using System.ComponentModel;

namespace ProcessManager.Profiling.Models.Gpu
{
    public class GpuInfo : INotifyPropertyChanged
    {
        //
        // ---------------------------------- PROPERTIES ----------------------------------
        //

        // ---------------------------------- GPU_INFO_STRUCT ----------------------------------

        private string _dxSupport = "N/A";
        private Double _vRamSize;
        private Double _vRamUsage;

        public string DxSupport
        {
            get => _dxSupport;
            set
            {
                if (_dxSupport != value)
                {
                    _dxSupport = value;
                    OnPropertyChanged(nameof(DxSupport));
                }
            }
        }
        public double VRamSize
        {
            get => _vRamSize;
            set
            {
                if (_vRamSize != value)
                {
                    _vRamSize = value;
                    OnPropertyChanged(nameof(VRamSize));
                }
            }
        }
        public double VRamUsage
        {
            get => _vRamUsage;
            set
            {
                if (_vRamUsage != value)
                {
                    _vRamUsage = value;
                    OnPropertyChanged(nameof(VRamUsage));
                }
            }
        }

        // ---------------------------------- GPU_UTILIZATION_INFO_STRUCT ----------------------------------

        private Double _utilization;
        private Double _videoEncode;
        private Double _videoDecode;
        private Double _copy;

        public double Utilization
        {
            get => _utilization;
            set
            {
                if (_utilization != value)
                {
                    _utilization = value;
                    OnPropertyChanged(nameof(Utilization));
                }
            }
        }
        public double VideoEncode
        {
            get => _videoEncode;
            set
            {
                if (_videoEncode != value)
                {
                    _videoEncode = value;
                    OnPropertyChanged(nameof(VideoEncode));
                }
            }
        }
        public double VideoDecode
        {
            get => _videoDecode;
            set
            {
                if (_videoDecode != value)
                {
                    _videoDecode = value;
                    OnPropertyChanged(nameof(VideoDecode));
                }
            }
        }
        public double Copy
        {
            get => _copy;
            set
            {
                if (_copy != value)
                {
                    _copy = value;
                    OnPropertyChanged(nameof(Copy));
                }
            }
        }

        // ---------------------------------- GPU_PHYSICAL_INFO_STRUCT ----------------------------------

        private string _busId = "N/A";
        private string _legacyBusId = "N/A";
        private UInt32 _bus;
        private UInt32 _domain;
        private UInt32 _deviceId;
        private UInt32 _pciDeviceId;
        private UInt32 _subSysDeviceId;

        public string BusId
        {
            get => _busId;
            set
            {
                if (_busId != value)
                {
                    _busId = value;
                    OnPropertyChanged(nameof(BusId));
                }
            }
        }
        public string LegacyBusId
        {
            get => _legacyBusId;
            set
            {
                if (_legacyBusId != value)
                {
                    _legacyBusId = value;
                    OnPropertyChanged(nameof(LegacyBusId));
                }
            }
        }
        public uint Bus
        {
            get => _bus;
            set
            {
                if (_bus != value)
                {
                    _bus = value;
                    OnPropertyChanged(nameof(Bus));
                }
            }
        }
        public uint Domain
        {
            get => _domain;
            set
            {
                if (_domain != value)
                {
                    _domain = value;
                    OnPropertyChanged(nameof(Domain));
                }
            }
        }
        public uint DeviceId
        {
            get => _deviceId;
            set
            {
                if (_deviceId != value)
                {
                    _deviceId = value;
                    OnPropertyChanged(nameof(DeviceId));
                }
            }
        }
        public uint PciDeviceId
        {
            get => _pciDeviceId;
            set
            {
                if (_pciDeviceId != value)
                {
                    _pciDeviceId = value;
                    OnPropertyChanged(nameof(PciDeviceId));
                }
            }
        }
        public uint SubSysDeviceId
        {
            get => _subSysDeviceId;
            set
            {
                if (_subSysDeviceId != value)
                {
                    _subSysDeviceId = value;
                    OnPropertyChanged(nameof(SubSysDeviceId));
                }
            }
        }

        // ---------------------------------- GPU_MIN_RESOLUTION_INFO_STRUCT ----------------------------------

        private UInt32 _minWidth;
        private UInt32 _minHeight;

        public uint MinWidth
        {
            get => _minWidth;
            set
            {
                if (_minWidth != value)
                {
                    _minWidth = value;
                    OnPropertyChanged(nameof(MinWidth));
                }
            }
        }
        public uint MinHeight
        {
            get => _minHeight;
            set
            {
                if (_minHeight != value)
                {
                    _minHeight = value;
                    OnPropertyChanged(nameof(MinHeight));
                }
            }
        }

        // ---------------------------------- GPU_MAX_RESOLUTION_INFO_STRUCT ----------------------------------

        private UInt32 _maxWidth;
        private UInt32 _maxHeight;

        public uint MaxWidth
        {
            get => _maxWidth;
            set
            {
                if (_maxWidth != value)
                {
                    _maxWidth = value;
                    OnPropertyChanged(nameof(MaxWidth));
                }
            }
        }
        public uint MaxHeight
        {
            get => _maxHeight;
            set
            {
                if (_maxHeight != value)
                {
                    _maxHeight = value;
                    OnPropertyChanged(nameof(MaxHeight));
                }
            }
        }

        // ---------------------------------- GPU_MODEL_INFO_STRUCT ----------------------------------

        private string _name = "N/A";
        private string _vendor = "N/A";
        private string _driverName = "N/A";
        private UInt64 _driverVersion;
        private UInt32 _id;
        private UInt32 _revision;

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
        public string Vendor
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
        public string DriverName
        {
            get => _driverName;
            set
            {
                if (_driverName != value)
                {
                    _driverName = value;
                    OnPropertyChanged(nameof(DriverName));
                }
            }
        }
        public ulong DriverVersion
        {
            get => _driverVersion;
            set
            {
                if (_driverVersion != value)
                {
                    _driverVersion = value;
                    OnPropertyChanged(nameof(DriverVersion));
                }
            }
        }
        public uint Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        public uint Revision
        {
            get => _revision;
            set
            {
                if (_revision != value)
                {
                    _revision = value;
                    OnPropertyChanged(nameof(Revision));
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

        public void Load(GpuInfoStruct infoStruct, ulong gif, ulong mif, ulong uif, ulong pif, ulong rif)
        {
            if ((gif & (ulong)GpuInfoFlags.GPU_GIF_DX_SUPPORT) != 0)
            {
                DxSupport = Profiler.ToString(infoStruct.dxSupport);
            }
            if ((gif & (ulong)GpuInfoFlags.GPU_GIF_VRAM_USAGE) != 0)
            {
                VRamUsage = infoStruct.vRamUsage;
            }
            if ((gif & (ulong)GpuInfoFlags.GPU_GIF_VRAM_SIZE) != 0)
            {
                VRamSize = infoStruct.vRamSize;
            }
            if ((gif & (ulong)GpuInfoFlags.GPU_GIF_UTILIZATION_INFO) != 0)
            {
                if ((uif & (ulong)GpuUtilizationInfoFlags.GPU_UIF_UTILIZATION) != 0)
                    Utilization = infoStruct.utilInfo.utilization;
                if ((uif & (ulong)GpuUtilizationInfoFlags.GPU_UIF_VIDEO_ENCODE) != 0)
                    VideoEncode = infoStruct.utilInfo.videoEncode;
                if ((uif & (ulong)GpuUtilizationInfoFlags.GPU_UIF_VIDEO_DECODE) != 0)
                    VideoDecode = infoStruct.utilInfo.videoDecode;
                if ((uif & (ulong)GpuUtilizationInfoFlags.GPU_UIF_COPY) != 0)
                    Copy = infoStruct.utilInfo.copy;
            }
            if ((gif & (ulong)GpuInfoFlags.GPU_GIF_MAX_RES_INFO) != 0)
            {
                if ((rif & (ulong)GpuResolutionInfoFlags.GPU_RIF_WIDTH) != 0)
                    MaxWidth = infoStruct.maxResInfo.width;
                if ((rif & (ulong)GpuResolutionInfoFlags.GPU_RIF_HEIGHT) != 0)
                    MaxHeight = infoStruct.maxResInfo.height;
            }
            if ((gif & (ulong)GpuInfoFlags.GPU_GIF_MIN_RES_INFO) != 0)
            {
                if ((rif & (ulong)GpuResolutionInfoFlags.GPU_RIF_WIDTH) != 0)
                    MinWidth = infoStruct.minResInfo.width;
                if ((rif & (ulong)GpuResolutionInfoFlags.GPU_RIF_HEIGHT) != 0)
                    MinHeight = infoStruct.minResInfo.height;
            }
            if ((gif & (ulong)GpuInfoFlags.GPU_GIF_MODEL_INFO) != 0)
            {
                if ((mif & (ulong)GpuModelInfoFlags.GPU_MIF_NAME) != 0)
                    Name = Profiler.ToString(infoStruct.modelInfo.name);
                if ((mif & (ulong)GpuModelInfoFlags.GPU_MIF_VENDOR) != 0)
                    Vendor = Profiler.ToString(infoStruct.modelInfo.vendor);
                if ((mif & (ulong)GpuModelInfoFlags.GPU_MIF_DRIVER_NAME) != 0)
                    DriverName = Profiler.ToString(infoStruct.modelInfo.driverName);
                if ((mif & (ulong)GpuModelInfoFlags.GPU_MIF_DRIVER_VERSION) != 0)
                    DriverVersion = infoStruct.modelInfo.driverVersion; 
                if ((mif & (ulong)GpuModelInfoFlags.GPU_MIF_ID) != 0)
                    Id = infoStruct.modelInfo.id; 
                if ((mif & (ulong)GpuModelInfoFlags.GPU_MIF_REVISION) != 0)
                    Revision = infoStruct.modelInfo.revision; 
            }
            if ((gif & (ulong)GpuInfoFlags.GPU_GIF_PHYSICAL_INFO) != 0)
            {
                if ((mif & (ulong)GpuPhysicalInfoFlags.GPU_PIF_BUS_ID) != 0)
                    BusId = Profiler.ToString(infoStruct.physInfo.busId);
                if ((mif & (ulong)GpuPhysicalInfoFlags.GPU_PIF_LEGACY_BUS_ID) != 0)
                    LegacyBusId = Profiler.ToString(infoStruct.physInfo.legacyBusId);
                if ((mif & (ulong)GpuPhysicalInfoFlags.GPU_PIF_BUS) != 0)
                    Bus = infoStruct.physInfo.bus;
                if ((mif & (ulong)GpuPhysicalInfoFlags.GPU_PIF_DOMAIN) != 0)
                    Domain = infoStruct.physInfo.domain;
                if ((mif & (ulong)GpuPhysicalInfoFlags.GPU_PIF_PCI_DEVICE_ID) != 0)
                    DeviceId = infoStruct.physInfo.deviceId;
                if ((mif & (ulong)GpuPhysicalInfoFlags.GPU_PIF_SUBSYS_DEVICE_ID) != 0)
                    SubSysDeviceId = infoStruct.physInfo.subSysDeviceId;
            }
        }
        public void Unload(ulong gif, ulong mif, ulong uif, ulong pif, ulong rif)
        {
            if ((gif & (ulong)GpuInfoFlags.GPU_GIF_DX_SUPPORT) != 0)
            {
                _dxSupport = "N/A";
            }
            if ((gif & (ulong)GpuInfoFlags.GPU_GIF_VRAM_USAGE) != 0)
            {
                _vRamUsage = 0;
            }
            if ((gif & (ulong)GpuInfoFlags.GPU_GIF_VRAM_SIZE) != 0)
            {
                _vRamSize = 0;
            }
            if ((gif & (ulong)GpuInfoFlags.GPU_GIF_UTILIZATION_INFO) != 0)
            {
                if ((uif & (ulong)GpuUtilizationInfoFlags.GPU_UIF_UTILIZATION) != 0)
                    _utilization = 0;
                if ((uif & (ulong)GpuUtilizationInfoFlags.GPU_UIF_VIDEO_ENCODE) != 0)
                    _videoEncode = 0;
                if ((uif & (ulong)GpuUtilizationInfoFlags.GPU_UIF_VIDEO_DECODE) != 0)
                    _videoDecode = 0;
                if ((uif & (ulong)GpuUtilizationInfoFlags.GPU_UIF_COPY) != 0)
                    _copy = 0;
            }
            if ((gif & (ulong)GpuInfoFlags.GPU_GIF_MAX_RES_INFO) != 0)
            {
                if ((rif & (ulong)GpuResolutionInfoFlags.GPU_RIF_WIDTH) != 0)
                    _maxWidth = 0;
                if ((rif & (ulong)GpuResolutionInfoFlags.GPU_RIF_HEIGHT) != 0)
                    _maxHeight = 0;
            }
            if ((gif & (ulong)GpuInfoFlags.GPU_GIF_MIN_RES_INFO) != 0)
            {
                if ((rif & (ulong)GpuResolutionInfoFlags.GPU_RIF_WIDTH) != 0)
                    _minWidth = 0;
                if ((rif & (ulong)GpuResolutionInfoFlags.GPU_RIF_HEIGHT) != 0)
                    _minHeight = 0;
            }
            if ((gif & (ulong)GpuInfoFlags.GPU_GIF_MODEL_INFO) != 0)
            {
                if ((mif & (ulong)GpuModelInfoFlags.GPU_MIF_NAME) != 0)
                    _name = "N/A";
                if ((mif & (ulong)GpuModelInfoFlags.GPU_MIF_VENDOR) != 0)
                    _vendor = "N/A";
                if ((mif & (ulong)GpuModelInfoFlags.GPU_MIF_DRIVER_NAME) != 0)
                    _driverName = "N/A";
                if ((mif & (ulong)GpuModelInfoFlags.GPU_MIF_DRIVER_VERSION) != 0)
                    _driverVersion = 0;
                if ((mif & (ulong)GpuModelInfoFlags.GPU_MIF_ID) != 0)
                    _id = 0;
                if ((mif & (ulong)GpuModelInfoFlags.GPU_MIF_REVISION) != 0)
                    _revision = 0;
            }
            if ((gif & (ulong)GpuInfoFlags.GPU_GIF_PHYSICAL_INFO) != 0)
            {
                if ((pif & (ulong)GpuPhysicalInfoFlags.GPU_PIF_BUS_ID) != 0)
                    _busId = "N/A";
                if ((pif & (ulong)GpuPhysicalInfoFlags.GPU_PIF_LEGACY_BUS_ID) != 0)
                    _legacyBusId = "N/A";
                if ((pif & (ulong)GpuPhysicalInfoFlags.GPU_PIF_BUS) != 0)
                    _bus = 0;
                if ((pif & (ulong)GpuPhysicalInfoFlags.GPU_PIF_DOMAIN) != 0)
                    _domain = 0;
                if ((pif & (ulong)GpuPhysicalInfoFlags.GPU_PIF_PCI_DEVICE_ID) != 0)
                    _deviceId = 0;
                if ((pif & (ulong)GpuPhysicalInfoFlags.GPU_PIF_SUBSYS_DEVICE_ID) != 0)
                    _subSysDeviceId = 0;
            }
        }
    }
}
