using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace BetterValueConverterDemo.Converters
{
    public class BoolToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)     
        {
            //Make sure the target can take a brush

            if(targetType != typeof(Brush))
            {
                throw new ArgumentException("The type of targetType is not equivalent to a Brush");
            } 

            SolidColorBrush scb = (bool) value ? Brushes.Green : Brushes.Red;

                

            return scb;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
