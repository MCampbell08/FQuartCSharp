using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploringEvents
{
    public class MyButton
    {
        private string s;
        public event MyView.MyClickDelegate ClickEvent;
        public string ButtonName
        {
            get
            {
                return s;
            }
            set
            {
                s = value;
            }
        }
        public MyButton(string s)
        {
            ButtonName = s;
        }
        public void ClickButton()
        {
            ClickEvent(ButtonName);
        }
    }
}
