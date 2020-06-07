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
            MyGenericClass<int> integerGenericClass = new MyGenericClass<int>(10);
            int val = integerGenericClass.genericMethod(200);

            Console.WriteLine();

            MyGenericClass<string> strGenericClass = new MyGenericClass<string>("ABC");
            string strval = strGenericClass.genericMethod("DEF");

            Console.ReadKey();
        }
    }

    public class MyGenericClass<T>
    {
        //Generic variable
        //The data type is generic
        private T genericMemberVariable;
        //Generic Constructor
        //Constructor accepts one parameter of Generic type
        public MyGenericClass(T value)
        {
            genericMemberVariable = value;
        }
        //Generic Method
        //Method accepts one Generic type Parameter
        //Method return type also Generic
        public T genericMethod(T genericParameter)
        {
            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T).ToString(), genericParameter);
            Console.WriteLine("Return type: {0}, value: {1}", typeof(T).ToString(), genericMemberVariable);
            return genericMemberVariable;
        }
        //Generic Property
        //The data type is generic
        public T genericProperty { get; set; }
    }
}