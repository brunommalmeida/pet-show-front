using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace pet_show_front.Converters
{
    public class BoolToColorTransferencia : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Application.Current.Resources["Azul"] : Application.Current.Resources["Cinza"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value == (string)Application.Current.Resources["Azul"];
        }
    }
}
