using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class AngryConsole : IConsoleViewable
    {
        public void PrintInput(string input)
        {
            input = input.ToUpper();
            Console.WriteLine(input);
        }

        public string PromptForInput()
        {
            Console.WriteLine("Oh great, look who it is! What do you want now?");
            string input = Console.ReadLine();
            return input;
        }
    }
}
