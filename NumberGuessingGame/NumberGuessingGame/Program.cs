using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NumberGuessingGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Driver driver = new Driver();
            Console.WriteLine("Welcome to the Number Guessing Game!");
            driver.Run();
        }
    }
}
