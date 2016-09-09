using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScratchConsole2.Enums;
namespace ScratchConsole2
{

    public static class Extensions
    {
        /// <summary>
        /// Adds two ints together and returns the sum
        /// </summary>
        /// <param name="x">The first int</param>
        /// <param name="y">The second int</param>
        /// <returns>the sum of x and y</returns>
        public static int Addition(this int x, int y)
        {
            return x + y;
        }
    }

    public class Program
    {
        public static Movie[] movies = new Movie[]
        {
            new Movie(1977, "Star Wars", 5f, MPAARating.PG),
            new Movie(1993, "Jurassic Park", 4.9f, MPAARating.PG13),
            new Movie(1995, "Waterworld", 3.05f, MPAARating.PG13),
            new Movie(2002, "Treasure Planet", 5f, MPAARating.PG),
            new Movie(2016, "Deadpool", 4.7f, MPAARating.R)
        };
        public static void Main(string[] args)
        {
            int[] nums = new int[] { 24, 5, 42, 1337, -13, 0, 7, 420, 7, 8, 69, 1997, 1978, 1977, 1980, 1983 };

            string[] lastNames =
            {
            "Smith",
            "Johnson",
            "Brown",
            "Davis",
            "Anderson"
            };

            string name = "";

            name += lastNames[0];
            name += lastNames[2];
            Console.WriteLine(name);

            //List<int> evenNums = new List<int>();
            //foreach (int n in nums)
            //{
            //    if (n % 2 == 0)
            //    {
            //        evenNums.Add(n);
            //    }
            //}

            //LINQ - Language Integrated Query
            //Comprehensive Syntax
            //var evenNums = from int n in nums
            //               where n % 2 == 0
            //               select n;

            //Extension Syntax                              v-Implied-v
            //var evenNums2 = nums.Where(n => n % 2 == 0)/*.Select(n => n)*/;

            //Sugarless Syntax
            //IEnumerable<int> evenNums3 = Enumerable.Select(Enumerable.Where(nums, Predicate1), Select1);

            //Select just the titles and years of the movies in our collection of movies
            //Then, print them out
        }
    }
}
