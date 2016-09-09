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

namespace DemoAddingResources
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int Count { get; set; } = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Button_ClickHandler(object sender, RoutedEventArgs e)
        {
            var resource = mainPanel.Resources["BodyColor"] as SolidColorBrush;
            if (resource != null)
            {
                resource = Count++ % 2 == 0 ? Brushes.Aqua : Brushes.LawnGreen;
                mainPanel.Resources["BodyColor"] = resource;
            }
        }
    }
}
