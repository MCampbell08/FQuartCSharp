using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingExercise.Models
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _age;
        private string _name = "";
        private string _gender = "";
        private Random rand = new Random();
        private string[] firstNames =
        {
            "Andrew",
            "Taylor",
            "Lydia",
            "Dillon",
            "Edward"

        };
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                FieldChanged();
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                FieldChanged();
            }
        }

        public string Gender
        {
            get { return _gender; }

            set
            {
                int choice = rand.Next(0, 2);
                if (value == firstNames[0] || value == firstNames[1] && choice == 0 || value == firstNames[3] || value == firstNames[4])
                {
                    _gender = "Male";
                }
                else if (value == firstNames[1] && choice == 1 || value == firstNames[2])
                {
                    _gender = "Female";
                }
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
}
