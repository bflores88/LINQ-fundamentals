using System;
using System.Collections.Generic;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee {Id = 1, Name = "Brenda"},
                new Employee {Id = 2, Name = "Marian"}
            };

            IEnumerable<Employee> sales = new List<Employee>
            {
                new Employee {Id = 3, Name = "Sally"}
            };

            IEnumerator<Employee> enumerator = sales.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }
        }
    }
}
