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

namespace Battleship
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeBoard();
        }
        
        public void InitializeBoard()
        {
            int rows = mainGrid.RowDefinitions.Count;
            int cols = mainGrid.ColumnDefinitions.Count;

            for (int i = 0; i < rows; ++i)
            {
                for(int j = 0; j < cols; ++j)
                {
                    char colChar = (char)i; colChar += (char)64;

                    Label label = new Label();
                    if (i == 0 && j == 0)
                    {
                        label.Content = "Pt.1";
                    }
                    else if (i == 0 && j != 0)
                    {
                        label.Content = j;
                    }
                    else if (j == 0 && i != 0)
                    {
                        label.Content = colChar;
                    } 
                    else
                    {
                        string location = "";
                        location += colChar;
                        location += j;
                        label.Content = location;
                        label.Background = Brushes.Blue;
                    }
                    label.BorderBrush = Brushes.Black;
                    label.BorderThickness = new Thickness(1);
                    label.MouseLeftButtonDown += Label_MouseLeftButtonDown;
                    Grid.SetRow(label, i);
                    Grid.SetColumn(label, j);
                    mainGrid.Children.Add(label);
                }
            }
        }

        private void Label_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            Label label = (Label)e.Source;
            if(label.Background == Brushes.Blue)
            {
                label.Background = Brushes.White;
            }
            else if (label.Background == Brushes.White)
            {
                label.Background = Brushes.Red;
            }
            else if (label.Background == Brushes.Red)
            {
                label.Background = Brushes.Gray;
            }
            else if (label.Background == Brushes.Gray)
            {
                label.Background = Brushes.Blue;
            }
            int col = Grid.GetColumn(label);
            char row = (char)Grid.GetRow(label); row += (char)64;
            string alphaNum = ""; alphaNum += row; alphaNum += col;
            Location.Text = alphaNum;
        }
    }
}
