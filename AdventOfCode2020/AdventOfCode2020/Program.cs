using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    class Program
    {
        private static string directory = "E:/Projects/AoC/AdventOfCode2020/AdventOfCode2020"; 
        //private static List<int> returnInput()
        //{
        //    var fileName = directory + "/inputs.txt";
        //    String[] input = File.ReadAllLines(fileName);             //This was used for gathering data 
                                                                        //from the first day tasks
        //    List<int> list = new List<int>();
        //    foreach (String s in input)
        //        list.Add(Convert.ToInt32(s));

        //    return list;
        //}
        private static List<String> returnInput()
        {
            var fileName = directory + "/inputs.txt";
            String[] input = File.ReadAllLines(fileName);

            List<String> list = new List<String>();
            foreach (String s in input)
                list.Add(s);

            return list;
        }
        static void Main(string[] args)
        {

            Day4 task = new Day4(returnInput());
            Console.WriteLine(task.FirstTask());
            Console.WriteLine(task.SecondTask());
        }
    }
}
