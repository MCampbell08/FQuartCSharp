using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace BinarySerializationDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyObject obj = new MyObject();

            obj.num1 = 24;
            obj.num2 = 7;
            obj.str = "Here is a string";
            obj.boolean = true;

            IFormatter formatter = new BinaryFormatter();
            Stream fileStream = new FileStream("..\\..\\Data\\fileDirectory.bin", FileMode.Create);
            formatter.Serialize(fileStream, obj);
            fileStream.Close();

            Console.WriteLine(obj.num1);
            Console.WriteLine(obj.num2);
            Console.WriteLine(obj.str);
            Console.WriteLine(obj.boolean);
        }
    }
    [Serializable]
    public class MyObject : ISerializable
    {   
        public int num1 = 0;
        public int num2 = 0;
        public string str = null;
        public bool boolean = false;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("i", num1);
            info.AddValue("j", num1);
            info.AddValue("k", str);
            info.AddValue("l", boolean);
        }
    }
}
