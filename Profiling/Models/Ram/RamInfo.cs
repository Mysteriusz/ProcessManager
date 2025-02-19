using ProcessManager.Profiling.Models.Cpu;
using ProcessManager.Profiling.Models.Cpu.Models;
using ProcessManager.Profiling.Models.Ram.Models;
using System.ComponentModel;
using System.Diagnostics;

namespace ProcessManager.Profiling.Models.Ram
{
    public class RamInfo : INotifyPropertyChanged
    {
        //
        // ---------------------------------- PROPERTIES ----------------------------------
        //

        // ---------------------------------- RAM_INFO_STRUCT ----------------------------------
        
        private Byte _location;
        private Byte _use;
        private Byte _memCorrectionError;
        private UInt16 _memErrorInfoHandle;
        private UInt16 _deviceCount;
        private UInt32 _maxCapacity;
        private UInt64 _extMaxCapacity;
        
        public Byte Location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    OnPropertyChanged(nameof(Location));
                }
            }
        }
        public Byte Use
        {
            get { return _use; }
            set
            {
                if (_use != value)
                {
                    _use = value;
                    OnPropertyChanged(nameof(Use));
                }
            }
        }
        public Byte MemCorrectionError
        {
            get { return _memCorrectionError; }
            set
            {
                if (_memCorrectionError != value)
                {
                    _memCorrectionError = value;
                    OnPropertyChanged(nameof(MemCorrectionError));
                }
            }
        }
        public UInt16 MemErrorInfoHandle
        {
            get { return _memErrorInfoHandle; }
            set
            {
                if (_memErrorInfoHandle != value)
                {
                    _memErrorInfoHandle = value;
                    OnPropertyChanged(nameof(MemErrorInfoHandle));
                }
            }
        }
        public UInt16 DeviceCount
        {
            get { return _deviceCount; }
            set
            {
                if (_deviceCount != value)
                {
                    _deviceCount = value;
                    OnPropertyChanged(nameof(DeviceCount));
                }
            }
        }
        public UInt32 MaxCapacity
        {
            get { return _maxCapacity; }
            set
            {
                if (_maxCapacity != value)
                {
                    _maxCapacity = value;
                    OnPropertyChanged(nameof(MaxCapacity));
                }
            }
        }
        public UInt64 ExtMaxCapacity
        {
            get { return _extMaxCapacity; }
            set
            {
                if (_extMaxCapacity != value)
                {
                    _extMaxCapacity = value;
                    OnPropertyChanged(nameof(ExtMaxCapacity));
                }
            }
        }

        // ---------------------------------- RAM_UTILIZATION_INFO_STRUCT ----------------------------------

        private UInt64 _totalPhysicalMemory;
        private UInt64 _totalVirtualMemory;
        private UInt64 _totalPageMemory;
        private UInt64 _availablePhysicalMemory;
        private UInt64 _availableVirtualMemory;
        private UInt64 _availablePageMemory;
        private UInt32 _memoryLoad;

        public UInt64 TotalPhysicalMemory
        {
            get { return _totalPhysicalMemory; }
            set
            {
                if (_totalPhysicalMemory != value)
                {
                    _totalPhysicalMemory = value;
                    OnPropertyChanged(nameof(TotalPhysicalMemory));
                }
            }
        }
        public UInt64 TotalVirtualMemory
        {
            get { return _totalVirtualMemory; }
            set
            {
                if (_totalVirtualMemory != value)
                {
                    _totalVirtualMemory = value;
                    OnPropertyChanged(nameof(TotalVirtualMemory));
                }
            }
        }
        public UInt64 TotalPageMemory
        {
            get { return _totalPageMemory; }
            set
            {
                if (_totalPageMemory != value)
                {
                    _totalPageMemory = value;
                    OnPropertyChanged(nameof(TotalPageMemory));
                }
            }
        }
        public UInt64 AvailablePhysicalMemory
        {
            get { return _availablePhysicalMemory; }
            set
            {
                if (_availablePhysicalMemory != value)
                {
                    _availablePhysicalMemory = value;
                    OnPropertyChanged(nameof(AvailablePhysicalMemory));
                }
            }
        }
        public UInt64 AvailableVirtualMemory
        {
            get { return _availableVirtualMemory; }
            set
            {
                if (_availableVirtualMemory != value)
                {
                    _availableVirtualMemory = value;
                    OnPropertyChanged(nameof(AvailableVirtualMemory));
                }
            }
        }
        public UInt64 AvailablePageMemory
        {
            get { return _availablePageMemory; }
            set
            {
                if (_availablePageMemory != value)
                {
                    _availablePageMemory = value;
                    OnPropertyChanged(nameof(AvailablePageMemory));
                }
            }
        }
        public UInt32 MemoryLoad
        {
            get { return _memoryLoad; }
            set
            {
                if (_memoryLoad != value)
                {
                    _memoryLoad = value;
                    OnPropertyChanged(nameof(MemoryLoad));
                }
            }
        }

        // ---------------------------------- RAM_BLOCK_INFO_STRUCT ----------------------------------

        private UInt32 _blockCount;
        private RamBlockInfo[] _blocks = [];

        public UInt32 BlockCount
        {
            get { return _blockCount; }
            set
            {
                if (_blockCount != value)
                {
                    _blockCount = value;
                    OnPropertyChanged(nameof(BlockCount));
                }
            }
        }
        public RamBlockInfo[] Blocks
        {
            get { return _blocks; }
            set
            {
                if (_blocks != value)
                {
                    _blocks = value;
                    OnPropertyChanged(nameof(Blocks));
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

        public void Load(RamInfoStruct infoStruct, ulong rif, ulong uif, ulong bif)
        {
            if ((rif & (ulong)RamInfoFlags.RAM_RIF_LOCATION) != 0)
            {
                Location = infoStruct.location;
                Debug.WriteLine(Location);
            }

            if ((rif & (ulong)RamInfoFlags.RAM_RIF_USE) != 0)
            {
                Use = infoStruct.use;
            }

            if ((rif & (ulong)RamInfoFlags.RAM_RIF_MEM_CORRECTION_ERROR) != 0)
            {
                MemCorrectionError = infoStruct.memCorrectionError;
            }

            if ((rif & (ulong)RamInfoFlags.RAM_RIF_MEM_ERROR_INFO_HANDLE) != 0)
            {
                MemErrorInfoHandle = infoStruct.memErrorInfoHandle;
            }

            if ((rif & (ulong)RamInfoFlags.RAM_RIF_DEVICE_COUNT) != 0)
            {
                DeviceCount = infoStruct.deviceCount;
            }

            if ((rif & (ulong)RamInfoFlags.RAM_RIF_MAX_CAPACITY) != 0)
            {
                MaxCapacity = infoStruct.maxCapacity;
            }

            if ((rif & (ulong)RamInfoFlags.RAM_RIF_EXT_MAX_CAPACITY) != 0)
            {
                ExtMaxCapacity = infoStruct.extMaxCapacity;
            }

            if ((rif & (ulong)RamInfoFlags.RAM_RIF_BLOCK_INFOS) != 0)
            {
                BlockCount = infoStruct.blockCount;
                Blocks = ConvertToBlocks(Profiler.ToArray<RamBlockInfoStruct>(infoStruct.blocks, infoStruct.blockCount), bif)!;
            }

            if ((rif & (ulong)RamInfoFlags.RAM_RIF_UTILIZATION_INFO) != 0)
            {
                if ((uif & (ulong)RamUtilizationInfoFlags.RAM_UIF_TOTAL_PHYSICAL_MEMORY) != 0)
                    TotalPhysicalMemory = infoStruct.utilizationInfo.totalPhysicalMemory;
                if ((uif & (ulong)RamUtilizationInfoFlags.RAM_UIF_TOTAL_VIRTUAL_MEMORY) != 0)
                    TotalVirtualMemory = infoStruct.utilizationInfo.totalVirtualMemory;
                if ((uif & (ulong)RamUtilizationInfoFlags.RAM_UIF_TOTAL_PAGE_MEMORY) != 0)
                    TotalPageMemory = infoStruct.utilizationInfo.totalPageMemory;
                if ((uif & (ulong)RamUtilizationInfoFlags.RAM_UIF_AVAILABLE_PHYSICAL_MEM) != 0)
                    AvailablePhysicalMemory = infoStruct.utilizationInfo.availablePhysicalMemory;
                if ((uif & (ulong)RamUtilizationInfoFlags.RAM_UIF_AVAILABLE_VIRTUAL_MEM) != 0)
                    AvailableVirtualMemory = infoStruct.utilizationInfo.availableVirtualMemory;
                if ((uif & (ulong)RamUtilizationInfoFlags.RAM_UIF_AVAILABLE_PAGE_MEM) != 0)
                    AvailablePageMemory = infoStruct.utilizationInfo.availablePageMemory;
                if ((uif & (ulong)RamUtilizationInfoFlags.RAM_UIF_MEMORY_LOAD) != 0)
                    MemoryLoad = infoStruct.utilizationInfo.memoryLoad;
            }
        }
        public void Unload(ulong rif, ulong uif, ulong bif)
        {
            if ((rif & (ulong)RamInfoFlags.RAM_RIF_LOCATION) != 0)
            {
                _location = 0;
            }

            if ((rif & (ulong)RamInfoFlags.RAM_RIF_USE) != 0)
            {
                _use = 0;
            }

            if ((rif & (ulong)RamInfoFlags.RAM_RIF_MEM_CORRECTION_ERROR) != 0)
            {
                _memCorrectionError = 0;
            }

            if ((rif & (ulong)RamInfoFlags.RAM_RIF_MEM_ERROR_INFO_HANDLE) != 0)
            {
                _memErrorInfoHandle = 0;
            }

            if ((rif & (ulong)RamInfoFlags.RAM_RIF_DEVICE_COUNT) != 0)
            {
                _deviceCount = 0;
            }

            if ((rif & (ulong)RamInfoFlags.RAM_RIF_MAX_CAPACITY) != 0)
            {
                _maxCapacity = 0;
            }

            if ((rif & (ulong)RamInfoFlags.RAM_RIF_EXT_MAX_CAPACITY) != 0)
            {
                _extMaxCapacity = 0;
            }

            if ((rif & (ulong)RamInfoFlags.RAM_RIF_BLOCK_INFOS) != 0)
            {
                foreach (var block in Blocks)
                    block.Unload(bif);
            }

            if ((rif & (ulong)RamInfoFlags.RAM_RIF_UTILIZATION_INFO) != 0)
            {
                if ((uif & (ulong)RamUtilizationInfoFlags.RAM_UIF_TOTAL_PHYSICAL_MEMORY) == 0)
                    _totalPhysicalMemory = 0;
                if ((uif & (ulong)RamUtilizationInfoFlags.RAM_UIF_TOTAL_VIRTUAL_MEMORY) == 0)
                    _totalVirtualMemory = 0;
                if ((uif & (ulong)RamUtilizationInfoFlags.RAM_UIF_TOTAL_PAGE_MEMORY) == 0)
                    _totalPageMemory = 0;
                if ((uif & (ulong)RamUtilizationInfoFlags.RAM_UIF_AVAILABLE_PHYSICAL_MEM) == 0)
                    _availablePhysicalMemory = 0;
                if ((uif & (ulong)RamUtilizationInfoFlags.RAM_UIF_AVAILABLE_VIRTUAL_MEM) == 0)
                    _availableVirtualMemory = 0;
                if ((uif & (ulong)RamUtilizationInfoFlags.RAM_UIF_AVAILABLE_PAGE_MEM) == 0)
                    _availablePageMemory = 0;
                if ((uif & (ulong)RamUtilizationInfoFlags.RAM_UIF_MEMORY_LOAD) == 0)
                    _memoryLoad = 0;

            }
        }


        public RamBlockInfo[] ConvertToBlocks(RamBlockInfoStruct[] blockInfoStructs, UInt64 flags)
        {
            var blocks = new RamBlockInfo[blockInfoStructs.Length];

            for (int i = 0; i < blockInfoStructs.Length; i++)
            {
                var blockInfo = new RamBlockInfo();
                blockInfo.Load(blockInfoStructs[i], flags);
                blocks[i] = blockInfo;
            }

            return blocks;
        }
    }
}
