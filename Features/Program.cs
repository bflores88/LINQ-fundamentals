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
                new Employee {Id = 1, Name = "Scott"},
                new Employee {Id = 2, Name = "Chris"}
            };

            IEnumerable<Employee> sales = new List<Employee>
            {
                new Employee {Id = 3, Name = "Sally"}
            };

            var query = developers.Where(e => e.Name.Length == 5)
                .OrderBy(e => e.Name);

            var query2 = from developer in developers
                where developer.Name.Length == 5
                orderby developer.Name
                select developer;

            foreach (var employee in query2)
            {
                Console.WriteLine(employee.Name);
            }
        }
    }
}
