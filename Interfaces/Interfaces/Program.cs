using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Program
    {
        IConsoleViewable classIConsole;
        public Program(IConsoleViewable iConsole)
        {
            classIConsole = iConsole;
            Run();
        }

        public void Run()
        {
            string input = classIConsole.PromptForInput();
            classIConsole.PrintInput(input);
        }
        public static void Main(string[] args)
        {
            bool isValid = false;
            int parsedArgs;
            if (args.Length == 0)
            {
                parsedArgs = 1;
                isValid = true;
            }
            else {
                isValid = int.TryParse(args[0], out parsedArgs);
            }
            if (isValid)
            {
                if(parsedArgs != 2 && parsedArgs != 3)
                {
                    parsedArgs = 1;
                }
                switch (parsedArgs)
                {
                    case 1:
                        {
                            Program p = new Program(new PirateConsole());
                            break;
                        }
                    case 2:
                        {
                            Program p = new Program(new PrettyConsole());
                            break;
                        }
                    case 3:
                        {
                            Program p = new Program(new AngryConsole());
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("Invalid input, quitting.");
            }
        }
    }

    public interface IConsoleViewable
    {
        string PromptForInput();
        void PrintInput(string input);
    }
}
