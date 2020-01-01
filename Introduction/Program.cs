using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\brend\Downloads";
            ShowLargeFilesWithoutLinq(path);

            ShowLargeFilesWithLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                orderby file.Length descending
                select file;

            foreach (var file in query.Take(5))
            {
                Console.WriteLine($"{file.Name,-20}: {file.Length,10:N0}");
            }
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());


            /*-- Retrieves top 5 files
            
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{files[i].Name, -20}: {files[i].Length, 10:N0}");
            }
            */


            /*-- Retrieves and logs all files

            foreach (FileInfo file in files)
            {
                Console.WriteLine($"{file.Name}: {file.Length}");
            }
            */
        }
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
