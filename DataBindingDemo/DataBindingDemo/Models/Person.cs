using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace DataBindingDemo.Models
{
    #region INotifyPropertyChanged Demo
    //Person class that uses INotifyPropertyChanged
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _age;
        private string _name = "";

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                FieldChanged();
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                FieldChanged();
            }
        }

        protected void FieldChanged([CallerMemberName] string field = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(field));
            }
        }
    }
    #endregion

    #region DependencyObject Demo
    ////Person class that inherits from DependencyObject and uses Dependency Properties
    //public class Person : DependencyObject
    //{
    //    public int Age
    //    {
    //        get { return (int)GetValue(AgeProperty); }
    //        set { SetValue(AgeProperty, value); }
    //    }

    //    // Using a DependencyProperty as the backing store for Age.  This enables animation, styling, binding, etc...
    //    public static readonly DependencyProperty AgeProperty =
    //        DependencyProperty.Register("Age", typeof(int), typeof(Person), new UIPropertyMetadata(42));

    //    public string Name
    //    {
    //        get { return (string)GetValue(NameProperty); }
    //        set { SetValue(NameProperty, value); }
    //    }

    //    // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
    //    public static readonly DependencyProperty NameProperty =
    //        DependencyProperty.Register("Name", typeof(string), typeof(Person), new UIPropertyMetadata("Pat"));
    //}
    #endregion

    #region Event Naming Convention Demo
    ////Person class that uses Event Name Convention for data binding
    //public class Person
    //{
    //    public event EventHandler NameChanged;
    //    public event EventHandler AgeChanged;

    //    private string _name = String.Empty;
    //    private int _age;

    //    public string Name
    //    {
    //        get { return _name; }
    //        set
    //        {
    //            _name = value;
    //            if (NameChanged != null)
    //            {
    //                NameChanged(this, EventArgs.Empty);
    //            }
    //        }
    //    }

    //    public int Age
    //    {
    //        get { return _age; }
    //        set
    //        {
    //            _age = value;
    //            if (AgeChanged != null)
    //            {
    //                AgeChanged(this, EventArgs.Empty);
    //            }
    //        }
    //    }
    //}
    #endregion

    #region No Dependency Properties
    //With no dependency properties
    //public class Person
    //{
    //    public int Age { get; set; }
    //    public string Name { get; set; }
    //}
    #endregion
}
