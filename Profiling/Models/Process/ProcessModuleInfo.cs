﻿using System.ComponentModel;
using System.Reflection;
using System.Windows.Media.Effects;

namespace ProcessManager.Profiling.Models.Process
{
    public class ProcessModuleInfo : INotifyPropertyChanged
    {
        private string _name = "N/A";
        private string _description = "N/A";
        private string _path = "N/A";
        private ulong _address;
        private ulong _size;

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
        public string Path
        {
            get => _path;
            set
            {
                if (_path != value)
                {
                    _path = value;
                    OnPropertyChanged(nameof(Path));
                }
            }
        }
        public ulong Address
        {
            get => _address;
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }
        public ulong Size
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

        public void Read(ulong flags, ProcessModuleInfoStruct infoStruct)
        {
            if ((flags & (ulong)ModuleInfoFlags.ModuleName) != 0)
            {
                Name = Profiler.ToString(infoStruct.name) ?? "N/A";
            }

            if ((flags & (ulong)ModuleInfoFlags.ModulePath) != 0)
            {
                Path = Profiler.ToString(infoStruct.path) ?? "N/A";
            }

            if ((flags & (ulong)ModuleInfoFlags.ModuleAddress) != 0)
            {
                Address = infoStruct.address;
            }

            if ((flags & (ulong)ModuleInfoFlags.ModuleDescription) != 0)
            {
                Description = Profiler.ToString(infoStruct.description) ?? "N/A";
            }

            if ((flags & (ulong)ModuleInfoFlags.ModuleSize) != 0)
            {
                Size = infoStruct.size;
            }
        }
        public void Unload(ulong flags)
        {
            if ((flags & (ulong)ModuleInfoFlags.ModuleName) != 0)
            {
                _name = "";
            }

            if ((flags & (ulong)ModuleInfoFlags.ModulePath) != 0)
            {
                _path = "";
            }

            if ((flags & (ulong)ModuleInfoFlags.ModuleAddress) != 0)
            {
                _address = 0;
            }

            if ((flags & (ulong)ModuleInfoFlags.ModuleDescription) != 0)
            {
                _description = "";
            }

            if ((flags & (ulong)ModuleInfoFlags.ModuleSize) != 0)
            {
                _size = 0;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
