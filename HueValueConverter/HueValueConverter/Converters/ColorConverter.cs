using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace HueValueConverter.Converters
{
    public class ColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Color))
            {
                throw new ArgumentException("Type of targetType must be a Brush type.");
            }

            int alphaRaw = Rounder((double)values[3]);
            int redRaw =   Rounder((double)values[0]);
            int greenRaw = Rounder((double)values[1]);
            int blueRaw =  Rounder((double)values[2]);

            byte alphaParsed = (byte)alphaRaw;
            byte redParsed = (byte)redRaw;
            byte greenParsed = (byte)greenRaw;
            byte blueParsed = (byte)blueRaw;

            Color color = Color.FromArgb(alphaParsed, redParsed, greenParsed, blueParsed);

            return color;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public int Rounder(double value)
        {
            return (int)value;
        }
    }
}
