using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploringEvents
{
    public class MyView
    {
        public void ButtonClick_Handler(string s)
        {
            Console.WriteLine("[" + s + "] was clicked");
        }

        public delegate void MyClickDelegate(string s);
    }

}
