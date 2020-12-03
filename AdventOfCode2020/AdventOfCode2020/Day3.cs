using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    class Day3
    {

        private IList<String> rows;
        private List<String> slopes;
        private int length;
        private int row;
        private char tree;


        public Day3(List<String> input)
        {
            
            String line = input[0].Replace(" ", string.Empty);
            tree = '#';
            length = line.Length;
            row = input.Count;
            rows = input;

            slopes = new List<String>();
            slopes.Add("1 1");
            slopes.Add("3 1");
            slopes.Add("5 1");
            slopes.Add("7 1");
            slopes.Add("1 2");
        }

        private int HowManyTrees(int stepsRight, int stepsDown)
        {
            int index = 0;
            int trees = 0;

            for (int i = 0; i < row; i = i+stepsDown)
            {
                if (rows[i].ToCharArray()[index % length].Equals(tree))
                    ++trees;
                index += stepsRight;
            }

            return trees;
        }

        public int FirstTask()
        {
            return HowManyTrees(3, 1);
        }

        public double SecondTask()
        {
            double multiplyedTrees = 1;

            foreach(String slope in slopes)
                multiplyedTrees *= HowManyTrees(Convert.ToInt32(slope.Split(" ")[0]), Convert.ToInt32(slope.Split(" ")[1]));
                
            
            return multiplyedTrees;
        }
    }
}
