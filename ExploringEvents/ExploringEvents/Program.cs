using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploringEvents
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        public static int PromptForMenuSelection(IEnumerable<string> options, bool withQuit)
        {
            bool done = false;
            int menuSelection = 0;
            int counter = 0;
            string input;
            foreach (string choices in options)
            {
                ++counter;
                Console.WriteLine("{0}. {1}", counter, choices);
            }
            if (withQuit)
            {
                Console.WriteLine("\n0. Quit");
            }
            while (!done)
            {
                input = Console.ReadLine();
                bool isValid = int.TryParse(input, out menuSelection);
                if (isValid && withQuit && menuSelection >= counter - counter && menuSelection <= counter)
                {
                    done = true;
                }
                else if (isValid && !withQuit && menuSelection >= counter - counter + 1 && menuSelection <= counter)
                {
                    done = true;
                }
                if (withQuit && menuSelection == 0)
                {
                    done = true;
                }
                else if (!withQuit && menuSelection > counter || !withQuit && menuSelection < counter - counter + 1)
                {
                    Console.WriteLine("Invlaid input! Please try again: ");
                }
            }
            return menuSelection;
        }

        public void Run()
        {
            MyView myView = new MyView();
            MyButton ok = new MyButton("Ok");
            MyButton cancel = new MyButton("Cancel");
            MyButton bob = new MyButton("Bob");
            ok.ClickEvent += myView.ButtonClick_Handler;
            cancel.ClickEvent += myView.ButtonClick_Handler;
            bob.ClickEvent += myView.ButtonClick_Handler;

            string[] options =
            {
                "Ok button",
                "Cancel button",
                "Bob button",
                "All buttons"                
            };

            bool done = false;

            while(!done)
            {

                int choice = PromptForMenuSelection(options, true);

                switch(choice)
                {
                    case 1:
                        {
                            ok.ClickButton();
                            break;
                        }
                    case 2:
                        {
                            cancel.ClickButton();
                            break;
                        }
                    case 3:
                        {
                            bob.ClickButton();
                            break;
                        }
                    case 4:
                        {
                            ok.ClickButton();
                            cancel.ClickButton();
                            bob.ClickButton();
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
