using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace AdventOfCode2020
{
    class Day1
    {

        private int sum = 2020;
        private int result = 0;
        private static List<int> inputs;
        public Day1(List<int> list)
        {
            inputs = list;
            inputs.Sort();
        }

        public int firstTask()
        {
            foreach(int i in inputs)
            {
                int second = sum - i;
                if (inputs.Contains(second))
                    result = second * i;
            }
            return result;
        }

        public int secondTask()
        {
            foreach (int i in inputs)
            {
                int second = sum - i;
                if (!(inputs.Contains(second)))
                {
                    for(int j = inputs.IndexOf(i); j < inputs.Count; ++j)
                    {
                        if (inputs.Contains(second - inputs[j]))
                            result = i * (second - inputs[j]) * inputs[j];
                    }
                }
            }
            return result;
        }
    }
}
