using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class PirateConsole : IConsoleViewable
    {
        public void PrintInput(string input)
        {
            string modifiedString = input;
            int counter = 0;
            string pirateTalk = "-ARR-";
            foreach (char c in input)
            {
                if (c == 'r')
                {
                    modifiedString = modifiedString.Remove(counter, 1);
                    modifiedString = modifiedString.Insert(counter, pirateTalk);
                    counter += (pirateTalk.Length - 1);
                }
                ++counter;
            }
            modifiedString += ", me hearty!";
            Console.WriteLine(modifiedString);
        }

        public string PromptForInput()
        {
            Console.WriteLine("Arrr! What ye be wantin' to tell me?");
            string input = Console.ReadLine();
            return input;
        }
    }
}
