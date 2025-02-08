using System.ComponentModel;
using System.Diagnostics;

namespace ProcessManager.Profiling.Models.Process
{
    public class ProcessHandleInfo : INotifyPropertyChanged
    {
        public string _name = "N/A";
        public string _type = "N/A";
        public int _address;

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
        public string Type
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
        public int Address
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

        public void Read(ulong flags, ProcessHandleInfoStruct infoStruct)
        {
            if ((flags & (ulong)HandleInfoFlags.HandleName) != 0)
            {
                Name = Profiler.ToString(infoStruct.name) ?? "N/A";
            }

            if ((flags & (ulong)HandleInfoFlags.HandleType) != 0)
            {
                Type = Profiler.ToString(infoStruct.type) ?? "N/A";
            }

            if ((flags & (ulong)HandleInfoFlags.HandleAddress) != 0)
            {
                Address = infoStruct.address;
            }
        }
        public void Unload(ulong flags)
        {
            if ((flags & (ulong)HandleInfoFlags.HandleName) != 0)
            {
                _name = "";
            }

            if ((flags & (ulong)HandleInfoFlags.HandleType) != 0)
            {
                _type = "";
            }

            if ((flags & (ulong)HandleInfoFlags.HandleAddress) != 0)
            {
                _address = 0;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
