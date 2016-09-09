using GenericsDemo.DataStructure;
using GenericsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            VideoGame[] games = new VideoGame[5];

            GenericUtility.SortArray(games);
        }
    }
}

