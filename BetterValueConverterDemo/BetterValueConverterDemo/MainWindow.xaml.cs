using BetterValueConverterDemo.Models;
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

namespace BetterValueConverterDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Student s = new Student()
            {
                Name = "Rick James",
                Age = 420,
                SSN = "123-45-6789",
                isEnrolled = true
            };

            studentGrid.DataContext = s;

        }

        private void ChangeStudentButton_ClickHandler(object sender, RoutedEventArgs e)
        {
            ((Student)changeStudentButton.DataContext).Name = "Charlie Murphey";
        }
    }
}
