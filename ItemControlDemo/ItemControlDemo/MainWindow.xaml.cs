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
using ItemControlDemo.Models;
using System.Collections.ObjectModel;

namespace ItemControlDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<Car> cars = new ObservableCollection<Car>()
        {
            new Car() {Year= 1997, DriveTrainType=Enums.DriveTrain.FourWheelDrive, Make = "Ford", Model="Explorer"},
            new Car() {Year= 2001, DriveTrainType=Enums.DriveTrain.FourWheelDrive, Make = "Ford", Model="Sport", HasAC = true},
            new Car() {Year= 1981, DriveTrainType=Enums.DriveTrain.RearWheelDrive, Make = "DMC", Model="Delorean"},
            new Car() {Year= 2015, DriveTrainType=Enums.DriveTrain.RearWheelDrive, Make = "Chevy", Model="Corvette", HasAC = true},
        };

        public MainWindow()
        {
            InitializeComponent();

            carDataGrid.ItemsSource = cars;
        }
    }
}
            