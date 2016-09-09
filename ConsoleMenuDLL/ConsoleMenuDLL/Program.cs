using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC160_ConsoleMenu;

namespace ConsoleMenuDLL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        public void Run()
        {
            string[] options =
            {
                "Bool",
                "Byte",
                "Short",    
                "Int",
                "Long",
                "Float",
                "Double",
                "Decimal",
                "Input",
                "Char"
            };
            bool done = false;

            while (!done)
            {
                int choice = CIO.PromptForMenuSelection(options, true);
                Console.WriteLine(choice);

                switch (choice)
                {
                    case 1:
                        {
                            string message = "Please enter your bool response.";
                            CIO.PromptForBool(message, "True", "False");
                            break;
                        }
                    case 2:
                        {
                            string message = "Please enter your byte response.";
                            CIO.PromptForByte(message, 0, 10);
                            break;
                        }
                    case 3:
                        {
                            string message = "Please enter your short response.";
                            CIO.PromptForShort(message, 0, 10);
                            break;
                        }
                    case 4:
                        {
                            string message = "Please enter your int response.";
                            CIO.PromptForInt(message, 0, 10);
                            break;
                        }
                    case 5:
                        {
                            string message = "Please enter your long response.";
                            CIO.PromptForLong(message, 0, 10);
                            break;
                        }
                    case 6:
                        {
                            string message = "Please enter your float response.";
                            CIO.PromptForFloat(message, 0f, 10f);
                            break;
                        }
                    case 7:
                        {
                            string message = "Please enter your double response.";
                            CIO.PromptForDouble(message, 0.0, 10.0);
                            break;
                        }
                    case 8:
                        {
                            string message = "Please enter your decimal response.";
                            CIO.PromptForDecimal(message, 0, 10);
                            break;
                        }
                    case 9:
                        {
                            string message = "Please enter your input response.";
                            CIO.PromptForInput(message, true);
                            break;
                        }
                    case 10:
                        {
                            string message = "Please enter your char response.";
                            CIO.PromptForChar(message, 'a', 'z');
                            break;
                        }
                    case 0:
                        {
                            done = true;
                            break;
                        }
                }
            }
        }
    }
}
