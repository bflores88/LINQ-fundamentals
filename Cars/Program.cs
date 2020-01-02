using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessCars("fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");

            var query = 
                from car in cars
                join manufacturer in manufacturers 
                    on car.Manufacturer equals manufacturer.Name
                orderby car.Combined descending , car.Name ascending 
                select  new
                {
                    manufacturer.Headquarters,
                    car.Name,
                    car.Combined
                };

            var query2 =
                cars.Join(manufacturers,
                        c => c.Manufacturer,
                        m => m.Name, (c, m) => new
                        {
                           Car = c,
                           Manufacturer = m
                        })
                    .OrderByDescending(c => c.Car.Combined)
                    .ThenBy(c => c.Car.Name)
                    .Select( c => new
                    {
                        c.Manufacturer.Headquarters,
                        c.Car.Name,
                        c.Car.Combined
                    });

            var result =
                cars.SelectMany(c => c.Name)
                    .OrderBy(c => c);

            //foreach (var character in result)
            //{
            //    Console.WriteLine(character);
            //}


            foreach (var car in query2.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} {car.Name}: {car.Combined}");
            }
        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query =
                File.ReadAllLines(path)
                    .Where(l => l.Length > 1)
                    .Select(l =>
                    {
                        var columns = l.Split(',');
                        return new Manufacturer
                        {
                            Name = columns[0],
                            Headquarters = columns[1],
                            Year = int.Parse(columns[2])
                        };
                    });
            return query.ToList();
        }

        private static List<Car> ProcessCars(string path)
        {
            var query =
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .ToCar();


                //from line in File.ReadAllLines(path).Skip(1)
                //where line.Length > 1
                //select Car.ParseFromCsv(line);

            return query.ToList();
        }
    }

    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var columns = line.Split(',');

                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }
           
        }
    }
}
