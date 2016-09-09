using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace HueValueConverter.Converters
{
    public class DecimalHexadecimalConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(string))
            {
                throw new ArgumentException("Type of targetType  must be Type string.");
            }
            int decValue = 0;

            bool isParsed = Int32.TryParse((string)value, out decValue);

            if (isParsed)
            {
                if (decValue > 255)
                {
                    decValue = 255;
                }
                else if (decValue < 0)
                {
                    decValue = 0;
                }
            }

            string hexa = decValue.ToString("X");


            return hexa;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            int dec = Int32.Parse((string)value, System.Globalization.NumberStyles.HexNumber);

            if (dec > 255)
            {
                dec = 255;
            }
            else if(dec < 0)
            {
                dec = 0;
            }

            return dec.ToString();
        }
    }
}
