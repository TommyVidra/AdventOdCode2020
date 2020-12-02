using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    class Day2
    {

        private IList<String> passwords = new List<String>();
        private int firstCondition;
        private int secondCondition;
        private char conditionChar;

        private void InitResults(String line)
        {
            var condition = line.Split(":")[0];
            firstCondition = Convert.ToInt32(condition.Split(" ")[0].Split("-")[0]);
            secondCondition = Convert.ToInt32(condition.Split(" ")[0].Split("-")[1]);
            conditionChar = char.Parse(condition.Split(" ")[1]);
        }

        public Day2(List<String> input)
        {
            passwords = input;
        }

        public int FirstTask()
        {
            int result = 0;
            foreach (String line in passwords)
            {
                InitResults(line);
                var password = line.Split(":")[1];
                var iterations = 0;

                foreach(char c in password.ToCharArray())
                {
                    if(c.Equals(conditionChar))
                        ++iterations;
                }

                if(iterations >= firstCondition && iterations <= secondCondition)
                    ++result;
            }

            return result;
        }

        public int SecondTask()
        {
            int result = 0;

            foreach (String line in passwords)
            {
                var password = line.Split(":")[1].ToCharArray();
                InitResults(line);

                if (!(password[firstCondition].Equals(conditionChar) && password[secondCondition].Equals(conditionChar)) 
                    && (password[firstCondition].Equals(conditionChar) || password[secondCondition].Equals(conditionChar)))
                    ++result;
            }

            return result;
        }
    }
}
