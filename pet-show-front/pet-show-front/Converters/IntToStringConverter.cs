using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace pet_show_front.Converters
{
    public class IntToStringConverter : IValueConverter
    {
        // from Int32 to String
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        // String to Int
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int parsedInt = 0;
            if (int.TryParse(value.ToString(), out parsedInt))
            {
                return parsedInt;
            }
            else
            {
                return 0;
            }

            
        }
    }
}
