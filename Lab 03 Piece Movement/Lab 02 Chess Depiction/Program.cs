using Chess;
using System;
using System.IO;

namespace Chess
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            Run(args);
        }
        public static void Run(string[] args)
        {
            StreamReader file = new StreamReader(args[0]);
            Translate translate = new Translate();

            Console.WriteLine("Hello from Chess Translator!\n\n");
            Console.WriteLine("File: " + args[0] + " \n\n ---------------------- \n");

            translate.Run(file);
        }
    }
}
