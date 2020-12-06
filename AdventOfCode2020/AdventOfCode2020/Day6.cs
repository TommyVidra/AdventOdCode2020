using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    class Day6
    {
        private Dictionary<int, List<String>> AnswerGroups = new Dictionary<int, List<String>>();
        public Day6(List<String> Input)
        {
            List<String> TmpGroup = new List<String>();
            int index = 0;
            foreach (String line in Input)
            {
                if (line.Length == 0)
                {
                    AnswerGroups.Add(index, TmpGroup);
                    TmpGroup = new List<String>();
                    ++index;
                }
                //if(Input.IndexOf(line) + 1 == Input.)
                else
                {
                    TmpGroup.Add(line);
                }

            }
        }

        public int FirstTask()
        {
            int sum = 0;
            foreach (int key in AnswerGroups.Keys)
            {
                SortedSet<char> TmpAnswers = new SortedSet<char>();
                foreach (String answers in AnswerGroups[key])
                {
                    foreach(char answer in answers.ToCharArray())
                        TmpAnswers.Add(answer);
                }
                sum += TmpAnswers.Count;
            }

            return sum;
        }

        public int SecondTask()
        {
            int sum = 0;

            foreach(int key in AnswerGroups.Keys)
            {
                Dictionary<char, int> AnswersCount = new Dictionary<char, int>();
                foreach(String answers in AnswerGroups[key])
                {
                    foreach(char answer in answers.ToCharArray())
                    {
                        if (AnswersCount.ContainsKey(answer))
                        {
                            int tmpValue = AnswersCount[answer] + 1;
                            AnswersCount.Remove(answer);
                            AnswersCount.Add(answer, tmpValue);
                        }
                        else
                            AnswersCount.Add(answer, 1);
                    }
                }
                foreach(char answer in AnswersCount.Keys)
                {
                    Console.WriteLine(answer + " | " + AnswersCount[answer]);
                    if (AnswersCount[answer] == AnswerGroups[key].Count)
                        ++sum;
                }
            }

            return sum;
        }
    }
}
