using System.Globalization;
using System.Windows.Data;

namespace ProcessManager.WPFHelpers
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public string DateTimeFormat { get; set; } = "HH:mm:ss.fff";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.ToString(DateTimeFormat);
            }
            return "00:00:00.000";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class UlongToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ulong val)
            {
                return val.ToString("N0");
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
