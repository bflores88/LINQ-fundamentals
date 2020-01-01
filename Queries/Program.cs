using System;
using System.Collections.Generic;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie {Title = "Spirited Away", Rating = 8.5f, Year = 2001},
                new Movie {Title = "Your Name.", Rating = 8.5f, Year = 2016},
                new Movie {Title = "Princess Mononoke", Rating = 8.4f, Year = 1997},
                new Movie {Title = "A Silent Voice", Rating = 8.3f, Year = 2016},
                new Movie {Title = "My Neighbor Totoro", Rating = 8.1f, Year = 1988}
            };

            var query = movies.Filter(m => m.Year > 2000);

            //foreach (var movie in query)
            //{
            //    Console.WriteLine(movie.Title);
            //}
        }
    }
}
