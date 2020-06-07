using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            bool IsEqual = ClsCalculator.AreEqual(10, 20);
            Console.WriteLine($"int result {IsEqual}");

            IsEqual = ClsCalculator.AreEqual("ABC", "ABC");
            Console.WriteLine($"string result {IsEqual}");

            IsEqual = ClsCalculator.AreEqual(10.5, 20.5);
            Console.WriteLine($"double result {IsEqual}");
            
            Console.ReadKey();
        }
    }

    public class ClsCalculator
    {
        public static bool AreEqual<T>(T value1, T value2)
        {
            return value1.Equals(value2);
        }        
    }
}