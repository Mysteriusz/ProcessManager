using ProcessManager.Profiling.Models.Process.Models;
using System.ComponentModel;

namespace ProcessManager.Profiling.Models.Process
{
    public class ProcessThreadInfo : INotifyPropertyChanged
    {
        //
        // ---------------------------------- PROPERTIES ----------------------------------
        //

        private ulong _priority;
        private ulong _tid;
        private ulong _startAddress;
        private ulong _cyclesDelta;

        public ulong Priority
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
        public ulong TID
        {
            get => _tid;
            set
            {
                if (_tid != value)
                {
                    _tid = value;
                    OnPropertyChanged(nameof(TID));
                }
            }
        }
        public ulong StartAddress
        {
            get => _startAddress;
            set
            {
                if (_startAddress != value)
                {
                    _startAddress = value;
                    OnPropertyChanged(nameof(StartAddress));
                }
            }
        }
        public ulong CyclesDelta
        {
            get => _cyclesDelta;
            set
            {
                if (_cyclesDelta != value)
                {
                    _cyclesDelta = value;
                    OnPropertyChanged(nameof(CyclesDelta));
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

        public void Load(ulong flags, ProcessThreadInfoStruct infoStruct)
        {
            if ((flags & (ulong)ProcessThreadInfoFlags.PROCESS_RIF_PRIORITY) != 0)
            {
                Priority = infoStruct.priority;
            }

            if ((flags & (ulong)ProcessThreadInfoFlags.PROCESS_RIF_TID) != 0)
            {
                TID = infoStruct.tid;
            }

            if ((flags & (ulong)ProcessThreadInfoFlags.PROCESS_RIF_START_ADDRESS) != 0)
            {
                StartAddress = infoStruct.startAddress;
            }

            if ((flags & (ulong)ProcessThreadInfoFlags.PROCESS_RIF_CYCLES) != 0)
            {
                CyclesDelta = infoStruct.cyclesDelta;
            }
        }

        public void Unload(ulong flags)
        {
            if ((flags & (ulong)ProcessThreadInfoFlags.PROCESS_RIF_PRIORITY) != 0)
            {
                _priority = 0;
            }

            if ((flags & (ulong)ProcessThreadInfoFlags.PROCESS_RIF_TID) != 0)
            {
                _tid = 0;
            }

            if ((flags & (ulong)ProcessThreadInfoFlags.PROCESS_RIF_START_ADDRESS) != 0)
            {
                _startAddress = 0;
            }

            if ((flags & (ulong)ProcessThreadInfoFlags.PROCESS_RIF_CYCLES) != 0)
            {
                _cyclesDelta = 0;
            }
        }
    }
}
