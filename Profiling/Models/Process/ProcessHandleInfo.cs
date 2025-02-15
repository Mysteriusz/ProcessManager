using ProcessManager.Profiling.Models.Process.Models;
using System.ComponentModel;

namespace ProcessManager.Profiling.Models.Process
{
    public class ProcessHandleInfo : INotifyPropertyChanged
    {
        //
        // ---------------------------------- PROPERTIES ----------------------------------
        //

        public string _name = "N/A";
        public string _type = "N/A";
        public ulong _address;

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

        public void Load(ulong flags, ProcessHandleInfoStruct infoStruct)
        {
            if ((flags & (ulong)ProcessHandleInfoFlags.PROCESS_HIF_NAME) != 0)
            {
                Name = Profiler.ToString(infoStruct.name) ?? "N/A";
            }

            if ((flags & (ulong)ProcessHandleInfoFlags.PROCESS_HIF_TYPE) != 0)
            {
                Type = Profiler.ToString(infoStruct.type) ?? "N/A";
            }

            if ((flags & (ulong)ProcessHandleInfoFlags.PROCESS_HIF_ADDRESS) != 0)
            {
                Address = infoStruct.address;
            }
        }
        public void Unload(ulong flags)
        {
            if ((flags & (ulong)ProcessHandleInfoFlags.PROCESS_HIF_NAME) != 0)
            {
                _name = "";
            }

            if ((flags & (ulong)ProcessHandleInfoFlags.PROCESS_HIF_TYPE) != 0)
            {
                _type = "";
            }

            if ((flags & (ulong)ProcessHandleInfoFlags.PROCESS_HIF_ADDRESS) != 0)
            {
                _address = 0;
            }
        }
    }
}
