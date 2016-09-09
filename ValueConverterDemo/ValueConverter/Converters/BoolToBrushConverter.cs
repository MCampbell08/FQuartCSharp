using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ValueConverter.Converters
{
    public class BoolToBrushConverter : IValueConverter, INotifyPropertyChanged
    {
        
        #region IValueConverter Implementation

        //In order to function as a converter in WPF, our custom class must implement the IValueConverter interface

        //This is the method the framework calls when converting from the source data (bool) to the UIElement data (Brush)
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(Brush))
                throw new Exception("The conversion target must be of type Brush");

            SolidColorBrush scb = null;

            bool state;
            if (bool.TryParse(value.ToString(), out state))
            {
                scb = state ? TrueBrush : FalseBrush;
            }

            return scb;
        }

        //This is the method the framework calls when converting BACK from the UIElement data to the source data
        //I have intentionally left this one unimplemented. This converter is really meant to only go from bool to Brush,
        //not the other way around.
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
         
        #endregion

        #region Dependency Properties

        //You don't need to implement INotifyPropertyChanged to be a Value Converter
        //I chose to implement this interface so I could wire up a pair of properties for the
        //brushes, making reuse and refactoring easier and more effective
        public event PropertyChangedEventHandler PropertyChanged;

        private SolidColorBrush _trueBrush;
        private SolidColorBrush _falseBrush;

        public SolidColorBrush TrueBrush
        {
            get { return _trueBrush; }
            set
            {
                _trueBrush = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("TrueBrush"));
            }
        }

        public SolidColorBrush FalseBrush
        {
            get { return _falseBrush; }
            set
            {
                _falseBrush = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("FalseBrush"));
            }
        }
        #endregion

        
    }
}
