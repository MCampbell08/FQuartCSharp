using System.Windows;
using DataBindingDemo.Models;


namespace DataBindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int num = 1;

        public MainWindow()
        {
            InitializeComponent();
            InitializePerson();
        }

        private void InitializePerson()
        {
            Person p = new Person { Name = "John", Age = 20 };
            mainGrid.DataContext = p;
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            Person context = ((Person)nameLabel.DataContext);
            context.Name += num;
            context.Age *= num++;   
        }
    }
}
