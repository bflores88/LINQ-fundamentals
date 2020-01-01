using System;
using System.Collections.Generic;
using System.Linq;

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

            foreach (var employee in developers.Where(
            delegate (Employee employee)
            {
                return employee.Name.StartsWith("B");
            }))
            {
                Console.WriteLine(employee.Name);
            }
        }

        private static bool NameStartsWithB(Employee employee)
        {
            return employee.Name.StartsWith("B");
        }
    }
}
