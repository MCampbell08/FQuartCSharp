using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionLibrary
{
    public static class Extensions
    {
        /// <summary>
        /// Prints collection of objects corresponding to that specific type.
        /// </summary>
        /// <param name="input">Type of collection</param>
        public static void Print(this IEnumerable input)
        {
            int counter = 0;
            int secondCounter = 0;
            foreach (Object value in input) { ++counter; }
            foreach (Object value in input)
            {
                ++secondCounter;
                Console.Write(value);
                if (secondCounter == counter)
                {
                    Console.WriteLine(".");
                }
                else
                {
                    Console.Write(", ");
                }
            }
        }
        /// <summary>
        /// Returns the powered number by it's exponent
        /// </summary>
        /// <param name="num">Number that is being powered</param>
        /// <param name="exponent">Exponent</param>
        /// <returns></returns>
        public static int ToPower(this int num, int exponent)
        {
            int multiplier = num;
            if (exponent == 0)
            {
                num = 1;
            }
            else if (exponent != 1)
            {
                for (int i = 0; i < exponent; ++i)
                {
                    num *= multiplier;
                }
            }
            return num;
        }
        /// <summary>
        /// Checks string to see if it is a palindrome
        /// </summary>
        /// <param name="input">String being checked</param>
        /// <returns></returns>
        public static bool IsPalindrome(this string input)
        {
            int forward = 0;
            int backward = input.Length - 1;

            while (forward < backward)
            {
                if (input[forward] != input[backward])
                {
                    return false;
                }
                ++forward;
                --backward;
            }
            return true;
        }
        /// <summary>
        /// Prints the amount of characters in each string
        /// </summary>
        /// <param name="values">Collection of strings</param>
        public static void AmountInEachString(this IEnumerable<string> values)
        {
            int countVal = 0;
            foreach (string str in values)
            {
                ++countVal;
                int counter = 0;
                foreach (char c in str)
                {
                    ++counter;
                }
                Console.Write(counter);
                if (countVal != values.Count())
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(".");
        }
        /// <summary>
        /// Returns the amount of characters repeated in a string
        /// </summary>
        /// <param name="input">String being checcked for repeated characters</param>
        /// <param name="character">Character being looked for in a string</param>
        /// <returns></returns>
        public static int AmountofCharInStr(this string input, char character)
        {
            int amount = 0;

            foreach(char c in input)
            {
                if (character == c)
                {
                    ++amount;
                }       
            }
            return amount;
        }
        /// <summary>
        /// Uppercases the letter looked for and returns the new string
        /// </summary>
        /// <param name="input">String being changed</param>
        /// <param name="placement">Location in string to be checked</param>
        /// <returns></returns>
        public static string UppercaseChosenLetter(this string input, int placement)
        {
            if (placement < input.Count())
            {
                char[] newString = input.ToCharArray();
                char letter = newString[placement-1];
                if (letter >= 'A' && letter <= 'Z' || letter >= 'a' && letter <= 'z')
                {
                    newString[placement-1] = char.ToUpper(letter);
                    return new string(newString);
                }
                else
                {
                    Console.WriteLine("This character cannot be changed.");
                }
            }
            else
            {
                Console.WriteLine("There is no character at this placement.");
            }
            return input;
        }
    }
}
