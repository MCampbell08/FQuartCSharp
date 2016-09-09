using ScratchConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchConsole
{
    public class Program
    {

        #region Primitives
        byte by;
        short s;
        int i;
        long l;

        float f;
        double dub;
        decimal dec;

        bool b;
        char c;

        #endregion

        #region Visibility
        public int pubNum;               // Visible to everyone
        private int privNum;             // Visible to only the owning class
        protected int protNum;           // Visible to the owning class and all it's subclasses
        internal int internalNum;        // Visible to the assembly
                                         //internal protected intProtNum; // Union of internal and protected
        #endregion

        #region Variables
        //      private string words;
        #endregion

        //public string Words
        //{
        //    get
        //    {
        //        return words;
        //    }
        //    set
        //    {
        //        words = value;
        //    }
        //}

        public int Words { get; set; }

        public static void Main(string[] args)
        {
            #region OldStuff
            //Some stuff in class!
            //Program p = new Program();
            //Console.WriteLine(p.Words);
            //p.Words = "Hello";

            //Some more stuff 6/24

            ////int i = 10;
            ////byte b = (byte)i;

            ////char c = (char)i;
            ////string s = i.ToString();

            ////string input = "l337";
            ////bool isValid = false;

            ////while (isValid)
            ////{
            ////    Console.Write("Please enter a inputber: ");
            ////    input = Console.ReadLine();
            ////    int parsedNum;
            ////    isValid = int.TryParse(input, out parsedNum);

            ////    if (isValid)
            ////    {
            ////        Console.WriteLine(parsedNum * 2);
            ////    }
            ////    else {
            ////        Console.WriteLine("Not a number");
            ////    }
            ////}
            #endregion
            Program p = new Program();
            Program c = new Child();
            c.Print();

            List<INothingable> nothings = new List<INothingable>
            {
                new Child(),
                new Teacher()
            };

            foreach(INothingable nothing in nothings)
            {
                
            }
        }
            
        public virtual void Method1()
        {
            Console.WriteLine("I'm the base class.");
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }

    public class Child : Program, INothingable
    {
        public override void Print()
        {
            Console.WriteLine("I'm the child method!");
        }

        public void MakeThePoop()
        {
            Console.WriteLine("*as loud as possible*");
        }
    }

    public class Teacher
    {

    }

    public interface IPrintable
    {
        void Print();
    }
    public interface INothingable { } 
    
}

