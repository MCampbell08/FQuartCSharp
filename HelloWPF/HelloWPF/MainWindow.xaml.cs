using HelloWPF.Models;
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

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            int rows = mainGrid.RowDefinitions.Count;
            int cols = mainGrid.ColumnDefinitions.Count;

            for(int r = 0; r < rows; r++)
            {
                for(int c = 0; c< cols; c++)
                {
                    Label l = new Label() { Content = (r* cols)+c };
                    if (c % 2 == 0 && r % 2 == 0)
                    {
                        l.Background = Brushes.Black;
                        l.Foreground = Brushes.White;   
                    }
                    Grid.SetColumn(l, c);
                    Grid.SetRow(l, r);
                    mainGrid.Children.Add(l);
                }
            }
            //Use math

            Label getLabel = mainGrid.Children[3] as Label;
            Label getLabel2 = mainGrid.Children[8] as Label;
            //getLabel.Background = Brushes.Aqua;


        }
    }
}
