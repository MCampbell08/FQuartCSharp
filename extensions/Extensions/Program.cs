using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionLibrary;

namespace Extensions
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
                "Print",
                "To Power",
                "Check If Palindrome",
                "Amount In Each String of Objects",
                "Amount Of Repeated Characters In A String",
                "Uppercase To Chosen Letter"
            };
            bool done = false;

            while (!done)
            {
                int choice = PromptForMenuSelection(options, true);

                switch (choice)
                {
                    case 1:
                        {
                            string[] objects = new string[]
                            {
                            "a", "ab", "abc", "abcd"
                            };
                            objects.Print();
                            break;
                        }
                    case 2:
                        {
                            int number = 2;
                            int exponent = 4;
                            Console.WriteLine(number.ToPower(exponent));
                            break;
                        }
                    case 3:
                        {
                            string palindrome = "racecar";
                            Console.WriteLine(palindrome.IsPalindrome());
                            break;
                        }
                    case 4:
                        {

                            string[] objects = new string[]
                            {
                            "a", "ab", "abc", "abcd"
                            };
                            objects.AmountInEachString();
                            break;
                        }
                    case 5:
                        {
                            string repString = "bananas";
                            char certChar = 'a';
                            Console.WriteLine(repString.AmountofCharInStr(certChar));
                            break;
                        }
                    case 6:
                        {
                            string lowerString = "hello";
                            int placement = 4;
                            Console.WriteLine(lowerString.UppercaseChosenLetter(placement));
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
        public static int PromptForMenuSelection(IEnumerable<string> options, bool withQuit)
        {
            bool done = false;
            int menuSelection = 0;
            int counter = 0;
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
                string input = Console.ReadLine();
                if (withQuit)
                {
                    menuSelection = PromptForInt(input, counter - counter, counter);
                    done = true;
                }
                else
                {
                    menuSelection = PromptForInt(input, counter - counter + 1, counter);
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
        public static int PromptForInt(string message, int min, int max)
        {
            int intParsed = 0;
            bool done = false;

            while (!done)
            {
                bool tryParse = int.TryParse(message, out intParsed);
                if (!tryParse)
                {
                    Console.Write("Invalid input, try again: ");
                    message = Console.ReadLine();
                    done = false;
                }
                else
                {
                    if (intParsed < min || intParsed > max)
                    {
                        Console.Write("Number out of bounds, try again: ");
                        message = Console.ReadLine();
                        done = false;
                    }
                    else
                    {
                        done = true;
                    }
                }
            }
            return intParsed;
        }
    }
}
