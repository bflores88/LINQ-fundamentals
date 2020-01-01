using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(2));

            Action<int> write = Console.WriteLine;
            write(square(3));

            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee {Id = 1, Name = "Brenda"},
                new Employee {Id = 2, Name = "Marian"}
            };

            IEnumerable<Employee> sales = new List<Employee>
            {
                new Employee {Id = 3, Name = "Sally"}
            };

            foreach (var employee in developers.Where(e => e.Name.StartsWith("B")))
            {
                Console.WriteLine(employee.Name);
            }
        }
    }
}
