using System;
using System.Globalization;
using Xamarin.Forms;

namespace YGOmpanion.Converters
{
    public class ValidationTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolean)
            {
                return boolean ? Color.Black : Color.Red;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
