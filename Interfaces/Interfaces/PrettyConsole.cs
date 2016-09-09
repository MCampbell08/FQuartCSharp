using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class PrettyConsole : IConsoleViewable
    {
        public void PrintInput(string input)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine(input);
            Console.ResetColor();
        }

        public string PromptForInput()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hey there! What's going on?");
            Console.ResetColor();
            string input = Console.ReadLine();
            return input;
        }
    }
}
