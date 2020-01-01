﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\brend\Downloads";
            ShowLargeFilesWithoutLinq(path);
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