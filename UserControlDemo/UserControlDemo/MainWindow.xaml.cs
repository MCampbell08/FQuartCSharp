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
using UserControlDemo.Models;

namespace UserControlDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {         
        public MainWindow()
        {
            InitializeComponent();

            List<Movie> movies = new List<Movie>()
            {
                new Movie() { Title="Movie1", Year=2000, MPAARating="PG" },
                new Movie() { Title="Movie2", Year=2001, MPAARating="PG13" },
                new Movie() { Title="Movie3", Year=2002, MPAARating="R" }
            };

            mainPanel.DataContext = movies[0];
            mainPanel.DataContext = movies[1];
            mainPanel.DataContext = movies[2];
        }
    }
}
