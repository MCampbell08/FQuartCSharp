using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloWPF.Models
{
    public class Contact : INotifyPropertyChanged
    {
        protected string _phoneNumber;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
                FieldChanged();
            }
        }
        public Address HomeAddress { get; set; }

        protected void FieldChanged([CallerMemberName] string field = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(field));
            }
        }
    }
}
