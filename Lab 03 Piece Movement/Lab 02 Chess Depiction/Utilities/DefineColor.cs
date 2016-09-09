using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02_Chess_Depiction.Utilities
{
    public class DefineColor
    {
        public static string ColorDefined(string color)
        {
            if(color == "White")
            {
                color = "l";
            }
            else if (color == "Black")
            {
                color = "d";
            }
            return color;
        }
    }
}
