using System;
using System.Collections.Generic;

namespace CSC160_ConsoleMenu
{
    public static class CIO
    {
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
                else if(isValid && !withQuit && menuSelection >= counter - counter + 1 && menuSelection <= counter)
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

        public static bool PromptForBool(string message, string trueString, string falseString)
        {
            bool done = false;
            Console.WriteLine(message);

            while (!done)
            {
                string input = Console.ReadLine();
                input = input.ToLower();
                trueString = trueString.ToLower();
                falseString = falseString.ToLower();
                if (input == trueString)
                {
                    return true;
                }
                else if (input == falseString)
                {
                    return false;
                }
                else if (input != trueString && input != falseString)
                {
                    Console.Write("Invalid input, try again:");
                    message = Console.ReadLine();
                    done = false;
                }
            }
            return false;
        }

        public static byte PromptForByte(string message, byte min, byte max)
        {
            byte byteParsed = 0;
            bool done = false;
            Console.WriteLine(message);
            
            while (!done)
            {
                string input = Console.ReadLine();
                bool tryParse = Byte.TryParse(input, out byteParsed);
                if (!tryParse)
                {
                    Console.Write("Invalid input, try again: ");
                    done = false;
                }
                else
                {
                    if (byteParsed < min || byteParsed > max)
                    {
                        Console.Write("Number out of bounds, try again: ");
                        done = false;
                    }
                    else
                    {
                        done = true;
                    }
                }   
            }

            return byteParsed;
        }

        public static short PromptForShort(string message, short min, short max)
        {
            short shortParsed = 0;
            bool done = false;
            Console.WriteLine(message);

            while (!done)
            {
                string input = Console.ReadLine();
                bool tryParse = Int16.TryParse(input, out shortParsed);
                if (!tryParse)
                {
                    Console.Write("Invalid input, try again: ");
                    done = false;
                }
                else
                {
                    if (shortParsed < min || shortParsed > max)
                    {
                        Console.Write("Number out of bounds, try again: ");
                        done = false;
                    }
                    else
                    {
                        done = true;
                    }
                }
            }
            return shortParsed;
        }

        public static int PromptForInt(string message, int min, int max)
        {
            int intParsed = 0;
            bool done = false;
            Console.WriteLine(message);

            while (!done)
            {
                string input = Console.ReadLine();
                bool tryParse = Int32.TryParse(input, out intParsed);
                if (!tryParse)
                {
                    Console.Write("Invalid input, try again: ");
                    done = false;
                }
                else
                {
                    if (intParsed < min || intParsed > max)
                    {
                        Console.Write("Number out of bounds, try again: ");
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

        public static long PromptForLong(string message, long min, long max)
        {
            long longParsed = 0;
            bool done = false;
            Console.WriteLine(message);

            while (!done)
            {
                string input = Console.ReadLine();
                bool tryParse = Int64.TryParse(input, out longParsed);
                if (!tryParse)
                {
                    Console.Write("Invalid input, try again: ");
                    done = false;
                }
                else
                {
                    if (longParsed < min || longParsed > max)
                    {
                        Console.Write("Number out of bounds, try again: ");
                        done = false;
                    }
                    else
                    {
                        done = true;
                    }
                }
            }
            return longParsed;
        }

        public static float PromptForFloat(string message, float min, float max)
        {
            float floatParsed = 0;
            bool done = false;
            Console.WriteLine(message);

            while (!done)
            {
                string input = Console.ReadLine();
                bool tryParse = float.TryParse(input, out floatParsed);
                if (!tryParse)
                {
                    Console.Write("Invalid input, try again: ");
                    done = false;
                }
                else
                {
                    if (floatParsed < min || floatParsed > max)
                    {
                        Console.Write("Number out of bounds, try again: ");
                        done = false;
                    }
                    else
                    {
                        done = true;
                    }
                }
            }
            return floatParsed;
        }

        public static double PromptForDouble(string message, double min, double max)
        {
            double doubleParsed = 0;
            bool done = false;
            Console.WriteLine(message);

            while (!done)
            {
                string input = Console.ReadLine();
                bool tryParse = double.TryParse(input, out doubleParsed);
                if (!tryParse)
                {
                    Console.Write("Invalid input, try again: ");
                    done = false;
                }
                else
                {
                    if (doubleParsed < min || doubleParsed > max)
                    {
                        Console.Write("Number out of bounds, try again: ");
                        done = false;
                    }
                    else
                    {
                        done = true;
                    }
                }
            }
            return doubleParsed;
        }

        public static decimal PromptForDecimal(string message, decimal min, decimal max)
        {
            decimal decimalParsed = 0;
            bool done = false;
            Console.WriteLine(message);

            while (!done)
            {
                string input = Console.ReadLine();
                bool tryParse = decimal.TryParse(input, out decimalParsed);
                if (!tryParse)
                {
                    Console.Write("Invalid input, try again: ");
                    done = false;
                }
                else
                {
                    if (decimalParsed < min || decimalParsed > max)
                    {
                        Console.Write("Number out of bounds, try again: ");
                        done = false;
                    }
                    else
                    {
                        done = true;
                    }
                }
            }
            return decimalParsed;
        }

        public static string PromptForInput(string message, bool allowEmpty)
        {
            bool done = false;
            string input = "";

            Console.WriteLine(message);

            while (!done)
            {
                input = Console.ReadLine();
                if (!allowEmpty && input == "")
                {
                    Console.Write("You can not enter a empty string, try again: ");
                    done = false;
                }
                else
                {
                    done = true;
                }
            }
            return input;
        }

        public static char PromptForChar(string message, char min, char max)
        {
            char charParsed = ' ';
            bool done = false;

            Console.WriteLine(message);

            while (!done)
            {
                string input = Console.ReadLine();
                bool tryParse = char.TryParse(input, out charParsed);
                if (!tryParse)
                {
                    Console.Write("Invalid input, try again: ");
                    done = false;
                }
                else
                {
                    if (charParsed < min || charParsed > max)
                    {
                        Console.Write("Char out of bounds, try again: ");
                        done = false;
                    }
                    else
                    {
                        done = true;
                    }
                }
            }
            return charParsed;
        }
    }
}
