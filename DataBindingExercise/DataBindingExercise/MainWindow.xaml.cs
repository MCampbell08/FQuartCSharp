using DataBindingExercise.Models;
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

namespace DataBindingExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random rand = new Random();
        private int firNameDec;
        private int lasNameDec;
        private int age;
        private string fullName;
        private string firstName;
        private Person statP;
        private string[] firstNames =
        {
            "Andrew",
            "Taylor",
            "Lydia",
            "Dillon",
            "Edward"
        };
        private string[] lastNames =
        {
            "Smith",
            "Johnson",
            "Brown",
            "Davis",
            "Anderson"
        };
        public MainWindow()
        {
            InitializeComponent();
            InitializePerson();
        }

        private void InitializePerson()
        {
            Regen();
            Person p = new Person { Name = fullName, Age = age, Gender = firstName };
            statP = p;
            mainStack.DataContext = statP;
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            Person context = ((Person)nameLabel.DataContext);
            context.Name = statP.Name;
            context.Age = statP.Age;
            context.Gender = firstName;
            mainStack .DataContext = statP;
            NextRandom();
        }
            private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
        public void Regen()
        {
            firNameDec = rand.Next(0, 5);
            lasNameDec = rand.Next(0, 5);
            firstName = firstNames[firNameDec];
            fullName = firstName + " " + lastNames[lasNameDec];
            age = rand.Next(5, 121);
        }
            
        public void NextRandom()
        {
            Regen();
            statP.Name = fullName;
            statP.Age = age;
            statP.Gender = firstName;
        }
    }
    
}
