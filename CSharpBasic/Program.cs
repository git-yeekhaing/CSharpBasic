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
            //bool IsEqual = ClsCalculator.AreEqual(10, 20);
            bool IsEqual = ClsCalculator.AreEqual("ABC", "ABC");
            if (IsEqual)
            {
                Console.WriteLine("Both are Equal");
            }
            else
            {
                Console.WriteLine("Both are Not Equal");
            }
            Console.ReadKey();
        }
    }
    public class ClsCalculator
    {
        public static bool AreEqual(object value1, object value2)
        {
            return value1 == value2;
        }
    }
}
