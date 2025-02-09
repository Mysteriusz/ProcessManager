﻿using System.ComponentModel;

namespace ProcessManager.Profiling.Models.Process
{
    public class ProcessThreadInfo : INotifyPropertyChanged
    {
        private uint _priority;
        private uint _tid;
        private ulong _startAddress;
        private ulong _cyclesDelta;

        public uint Priority
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
        public uint TID
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

        public void Read(ulong flags, ProcessThreadInfoStruct infoStruct)
        {
            if ((flags & (ulong)ThreadInfoFlags.ThreadPriority) != 0)
            {
                Priority = infoStruct.priority;
            }

            if ((flags & (ulong)ThreadInfoFlags.ThreadTid) != 0)
            {
                TID = infoStruct.tid;
            }

            if ((flags & (ulong)ThreadInfoFlags.ThreadStartAddress) != 0)
            {
                StartAddress = infoStruct.startAddress;
            }

            if ((flags & (ulong)ThreadInfoFlags.ThreadCycles) != 0)
            {
                CyclesDelta = infoStruct.cyclesDelta;
            }
        }
        public void Unload(ulong flags)
        {
            if ((flags & (ulong)ThreadInfoFlags.ThreadPriority) != 0)
            {
                _priority = 0;
            }

            if ((flags & (ulong)ThreadInfoFlags.ThreadTid) != 0)
            {
                _tid = 0;
            }

            if ((flags & (ulong)ThreadInfoFlags.ThreadStartAddress) != 0)
            {
                _startAddress = 0;
            }

            if ((flags & (ulong)ThreadInfoFlags.ThreadCycles) != 0)
            {
                _cyclesDelta = 0;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
