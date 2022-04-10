using System;
using System.Globalization;
using Xamarin.Forms;

namespace O2NextGen.SmallTalk.Core.Converters
{
    public class InversOwnerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;
            var val = int.Parse(value.ToString());
            if (val == 1)
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
