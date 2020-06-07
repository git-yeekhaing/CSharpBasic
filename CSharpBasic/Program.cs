using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasic
{
    //Example: We have an integer list and we need to write a LINQ query 
    //which will return all the integers which are greater than 5. We are going to create a console application.
    class Program
    {
        static void Main(string[] args)
        {
            //IEnumerabelWithQuery();
            //IEnumerabelWithMixed();
            //IQueryableWithMixed();
            //JoinUsingQuerySyntax();
            //JoinUsingMethodSyntax();
            //LinqGroupBy();
            LinqDistinct();

            Console.ReadKey();
        }

        public static void LinqDistinct()
        {
            List<int> intCollection = new List<int>()
            {
                1,2,3,2,3,4,4,5,6,3,4,5
            };
            //Using Method Syntax
            var MS = intCollection.Distinct();

            //Using Query Syntax
            var QS = (from num in intCollection
                      select num).Distinct();

            foreach (var item in MS)
            {
                Console.WriteLine(item);
            }
        }

        public static void LinqGroupBy()
        {
            //Using Method Syntax
            var GroupByMS = Student2.GetStudents().GroupBy(s => s.Barnch);

            //Using Query Syntax
            IEnumerable<IGrouping<string, Student2>> GroupByQS = (from std in Student2.GetStudents()
                                                                 group std by std.Barnch);
            //It will iterate through each groups
            foreach (var group in GroupByMS)
            {
                Console.WriteLine(group.Key + " : " + group.Count());
                //Iterate through each student of a group
                foreach (var student in group)
                {
                    Console.WriteLine("  Name :" + student.Name + ", Age: " + student.Age + ", Gender :" + student.Gender);
                }
            }

        }

        public static void JoinUsingMethodSyntax()
        {
            var JoinUsingMS = Employee.GetAllEmployees()
                .Join(Address.GetAllAddresses(),
                emp => emp.AddressId,
                addr => addr.ID,
                (emp, addr) => new
                {
                    EmployeeName = emp.Name,
                    AddressLine = addr.AddressLine
                }).ToList();

            foreach (var employee in JoinUsingMS)
            {
                Console.WriteLine($"Name :{employee.EmployeeName}, Address : {employee.AddressLine}");
            }
        }

        public static void JoinUsingQuerySyntax()
        {
            var JoinUsingQS = (from emp in Employee.GetAllEmployees()
                               join address in Address.GetAllAddresses()
                               on emp.AddressId equals address.ID
                               select new
                               {
                                   EmployeeName = emp.Name,
                                   AddressLine = address.AddressLine
                               }).ToList();

            foreach (var employee in JoinUsingQS)
            {
                Console.WriteLine($"Name :{employee.EmployeeName}, Address : {employee.AddressLine}");
            }
        }

        public static void IQueryableWithMixed()
        {
            List<Student> studentList = new List<Student>()
            {
                new Student(){ID = 1, Name = "James", Gender = "Male"},
                new Student(){ID = 2, Name = "Sara", Gender = "Female"},
                new Student(){ID = 3, Name = "Steve", Gender = "Male"},
                new Student(){ID = 4, Name = "Pam", Gender = "Female"}
            };

            //Linq Query to Fetch all students with Gender Male
            IQueryable<Student> MethodSyntax = studentList.AsQueryable()
                                .Where(std => std.Gender == "Male");

            //Iterate through the collection
            foreach (var student in MethodSyntax)
            {
                Console.WriteLine($"ID : {student.ID}  Name : {student.Name}");
            }
        }

        public static void IEnumerabelWithMixed()
        {
            List<Student> studentList = new List<Student>()
            {
                new Student(){ID = 1, Name = "James", Gender = "Male"},
                new Student(){ID = 2, Name = "Sara", Gender = "Female"},
                new Student(){ID = 3, Name = "Steve", Gender = "Male"},
                new Student(){ID = 4, Name = "Pam", Gender = "Female"}
            };
            //Linq Query to Fetch all students with Gender Male
            IEnumerable<Student> QuerySyntax = from std in studentList
                                               where std.Gender == "Male"
                                               select std;
            //Iterate through the collection
            foreach (var student in QuerySyntax)
            {
                Console.WriteLine($"ID : {student.ID}  Name : {student.Name}");
            }
        }

        public static void IEnumerabelWithQuery()
        {
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            IEnumerable<int> QuerySyntax = from obj in integerList
                                           where obj > 5
                                           select obj;

            foreach (var item in QuerySyntax)
            {
                Console.Write(item + " ");
            }
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public static List<Employee> GetAllEmployees()
        {
            return new List<Employee>()
            {
                new Employee { ID = 1, Name = "Preety", AddressId = 1 },
                new Employee { ID = 2, Name = "Priyanka", AddressId = 2 },
                new Employee { ID = 3, Name = "Anurag", AddressId = 3 },
                new Employee { ID = 4, Name = "Pranaya", AddressId = 4 },
                new Employee { ID = 5, Name = "Hina", AddressId = 5 },
                new Employee { ID = 6, Name = "Sambit", AddressId = 6 },
                new Employee { ID = 7, Name = "Happy", AddressId = 7},
                new Employee { ID = 8, Name = "Tarun", AddressId = 8 },
                new Employee { ID = 9, Name = "Santosh", AddressId = 9 },
                new Employee { ID = 10, Name = "Raja", AddressId = 10},
                new Employee { ID = 11, Name = "Sudhanshu", AddressId = 11}
            };
        }
    }
    public class Address
    {
        public int ID { get; set; }
        public string AddressLine { get; set; }
        public static List<Address> GetAllAddresses()
        {
            return new List<Address>()
            {
                new Address { ID = 1, AddressLine = "AddressLine1"},
                new Address { ID = 2, AddressLine = "AddressLine2"},
                new Address { ID = 3, AddressLine = "AddressLine3"},
                new Address { ID = 4, AddressLine = "AddressLine4"},
                new Address { ID = 5, AddressLine = "AddressLine5"},
                new Address { ID = 9, AddressLine = "AddressLine9"},
                new Address { ID = 10, AddressLine = "AddressLine10"},
                new Address { ID = 11, AddressLine = "AddressLine11"},
            };
        }
    }


    public class Student2
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Barnch { get; set; }
        public int Age { get; set; }
        public static List<Student2> GetStudents()
        {
            return new List<Student2>()
            {
                new Student2 { ID = 1001, Name = "Preety", Gender = "Female", Barnch = "CSE", Age = 20 },
                new Student2 { ID = 1002, Name = "Snurag", Gender = "Male", Barnch = "ETC", Age = 21  },
                new Student2 { ID = 1003, Name = "Pranaya", Gender = "Male", Barnch = "CSE", Age = 21  },
                new Student2 { ID = 1004, Name = "Anurag", Gender = "Male", Barnch = "CSE", Age = 20  },
                new Student2 { ID = 1005, Name = "Hina", Gender = "Female", Barnch = "ETC", Age = 20 },
                new Student2 { ID = 1006, Name = "Priyanka", Gender = "Female", Barnch = "CSE", Age = 21 }            
            };
        }
    }
}