using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo.DataStructure
{
    public class GenericUtility
    {

        public static string Concatnator<T, U>(T input1, U input2)
        {
            string rVal = input1.GetType()
        }
        public static void SortArray<T>(T[] array) where T : IComparable<T>
        {
            for(int i = 0; i < array.Length-1; i++)
            {
                for (int j = i+1; j < array.Length; j++)
                {
                    if(array[i].CompareTo(array[j]) > 0)
                    {
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
