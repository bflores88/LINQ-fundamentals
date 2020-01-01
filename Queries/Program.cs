using System;
using System.Collections.Generic;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = MyLinq.Random().Where(n => n > 0.5).Take(10);
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }


            var movies = new List<Movie>
            {
                new Movie {Title = "Spirited Away", Rating = 8.5f, Year = 2001},
                new Movie {Title = "Your Name.", Rating = 8.5f, Year = 2016},
                new Movie {Title = "Princess Mononoke", Rating = 8.4f, Year = 1997},
                new Movie {Title = "A Silent Voice", Rating = 8.3f, Year = 2016},
                new Movie {Title = "My Neighbor Totoro", Rating = 8.1f, Year = 1988}
            };

            var query = movies.Where(m => m.Year > 2000).OrderByDescending(m => m.Rating);

            var enumerator = query.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current.Title);
            //}
        }
    }
}
