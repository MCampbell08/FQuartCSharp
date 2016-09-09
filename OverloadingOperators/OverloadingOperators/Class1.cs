using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadingOperators
{
    public struct Fraction
    {
        private int _denominator;
        public int WholeNumber { get; set; }
        public int Numerator { get; set; }
        public int Denominator
        {
            get { return _denominator; }
            set
            {
                _denominator = value;
                if (_denominator == 0)
                {
                    throw new ArgumentException("Value set for denominator cannot be 0.");
                }
            }
        }

        public Fraction(int whole = 0, int numerator = 0, int denominator = 1)
        {
            WholeNumber = whole;
            Numerator = numerator;
            _denominator = denominator;
            Denominator = _denominator;
        }

        public void Reduce()
        {
            int reduce = GCD(Numerator, Denominator);
            if (reduce == 0)
            {
                reduce = 1;
            }
            Numerator = Numerator / reduce;
            Denominator = Denominator / reduce;
            if (Denominator < 0 && Numerator > 0)
            {
                Numerator *= -1;
                Denominator *= -1;
            }
            if (Denominator == 1)
            {
                WholeNumber += Numerator;
            }
        }

        public void MakeProper()
        {
            if (this.Numerator > this.Denominator)
            {
                WholeNumber += Numerator / Denominator;
                Numerator = Numerator % Denominator;

            }
            if (this.Numerator == this.Denominator)
            {
                WholeNumber += 1;
            }
            Reduce();
        }

        public void MakeImproper()
        {
            if (WholeNumber != 0)
            {
                Numerator = (this.Denominator * this.WholeNumber) + Numerator;
                WholeNumber = 0;
            }
        }

        public void Simplify()
        {
            this.MakeProper();
        }

        private static int GCD(int m, int n)
        {
            //Implement Euclid's recursice algo for finding the greatest common divisor
            while (n != 0)
            {
                int remainder = m % n;
                m = n;
                n = remainder;
            }
            return m;
        }

        private static int LCD(int m, int n)
        {
            return (m * n) / GCD(m, n);
        }

        //Overload four standard math operators aa well as the equality operators

        public static Fraction operator +(Fraction a, Fraction b)
        {
            int commonDiv = LCD(a.Denominator, b.Denominator);
            int aNewNum = a.Numerator * (commonDiv / a.Denominator);
            int bNewNum = b.Numerator * (commonDiv / b.Denominator);
            int newWhole = a.WholeNumber + b.WholeNumber;
            
            Fraction c = new Fraction(newWhole, aNewNum + bNewNum, commonDiv);
            c.Simplify();
            return c;
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            if (a.WholeNumber != 0)
            {
                a.MakeImproper();
            }
            if (b.WholeNumber != 0)
            {
                b.MakeImproper();
            }

            int commonDiv = LCD(a.Denominator, b.Denominator);
            int aNewNum = a.Numerator * (commonDiv / a.Denominator);
            int bNewNum = b.Numerator * (commonDiv / b.Denominator);
            int newWhole = a.WholeNumber - b.WholeNumber;

            Fraction c = new Fraction(newWhole, aNewNum - bNewNum, commonDiv);
            c.Simplify();
            return c;
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            if (a.WholeNumber != 0)
            {
                a.MakeImproper();
            }
            if (b.WholeNumber != 0)
            {
                b.MakeImproper();
            }
            
            Fraction c = new Fraction(0, a.Numerator * b.Numerator, a.Denominator * b.Denominator);
            c.Simplify();
            return c;
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (a.WholeNumber != 0)
            {
                a.MakeImproper();
            }
            if (b.WholeNumber != 0)
            {
                b.MakeImproper();
            }
            int newNum = a.Numerator * b.Denominator;
            int newDen = a.Denominator * b.Numerator;

            Fraction c = new Fraction(0, newNum, newDen);
            c.Simplify();
            return c;
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            a.MakeProper();
            b.MakeProper();
            if (a.Numerator.Equals(b.Numerator) && a.Denominator.Equals(b.Denominator))
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            a.MakeProper();
            b.MakeProper();
            if (!(a == b))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            if (WholeNumber == 0)
            {
                if (Numerator == 0 || Denominator == 1)
                {
                    return WholeNumber.ToString();
                }
                return Numerator + "/" + Denominator;
            }
            if (Numerator == 0)
            {
                return WholeNumber.ToString();
            }
            if (Denominator == 1)
            {
                return WholeNumber.ToString();
            }
            return WholeNumber + " " + Numerator + "/" + Denominator;
        }
    }
    //public class program
    //{
    //    public static void Main(string[] args)
    //    {
    //        Fraction f  = new Fraction(2, 1, 2);
    //        Fraction f2 = new Fraction(3, 4, 7);
    //        Fraction f3 = f2 * f;

    //        Console.WriteLine(f3.ToString());
    //    }
    //}
}
