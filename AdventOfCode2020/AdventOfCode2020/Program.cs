using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    class Program
    {
        private static string directory = "E:/Projects/AoC/AdventOfCode2020/AdventOfCode2020"; 
        private static List<int> returnInput()
        {
            var fileName = directory + "/inputs.txt";
            String[] input = File.ReadAllLines(fileName);

            List<int> list = new List<int>();
            foreach (String s in input)
                list.Add(Convert.ToInt32(s));

            return list;
        }

        static void Main(string[] args)
        {

            Day1 task = new Day1(returnInput());
            Console.WriteLine(task.firstTask());
            Console.WriteLine(task.secondTask());
        }
    }
}
