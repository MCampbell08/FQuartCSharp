using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ValueConverter.Converters;

namespace ValueConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /* You should note that this binding is functionally IDENTICAL
             * to the binding set up in XAML for the xamlBoundLabel
             */

            //Instantiate a new Binding object, passing the property name we'll use for the Path
            Binding labelBinding = new Binding("IsChecked");

            //Set the ElementName property to the name of the CheckBox
            labelBinding.ElementName = "boolBox";

            //Set the Mode property to Default since we don't need any special behavior
            labelBinding.Mode = BindingMode.Default;

            //Grab the BoolToBrushConverter instance found in the global resource dictionary and set
            //the Binding's converter to this resource
            labelBinding.Converter = (BoolToBrushConverter)Application.Current.FindResource("BoolConverter");

            //Last, tell codeBoundLabel to set the binding for the BackGround property
            codeBoundLabel.SetBinding(BackgroundProperty, labelBinding);
        }
    }
}
