using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    class Day7
    {

        Dictionary<String, List<String>> Bags = new Dictionary<String, List<String>>();
        public Day7(List<String> Input)
        {
            foreach(String line in Input)
            {
                List<String> ChildBags = new List<String>();
                var parentBag = line.Split(" contain ")[0];

                if (line.Contains(","))
                {
                    var childBags = line.Split(" contain ")[1].Split(", ");

                    foreach (var bag in childBags)
                    {
                        String tmpBag = bag.Replace("bags", ""); 
                        tmpBag = tmpBag.Replace("bag", ""); 
                        tmpBag = tmpBag.Replace(".", "");
                        ChildBags.Add(tmpBag);
                    }
                        
                }

                else if (line.Contains("no other"))
                    ChildBags.Add("-");

                else
                {
                    String tmpBag = line.Split(" contain ")[1].Replace("bags", "");
                    tmpBag = tmpBag.Replace("bag", "");
                    tmpBag = tmpBag.Replace(".", "");
                    ChildBags.Add(tmpBag);
                }

                Bags.Add(parentBag.Replace("bags", ""), ChildBags);
            }

            foreach(String key in Bags.Keys)
            {
                foreach (String bag in Bags[key])
                    Console.WriteLine(key + " | " + bag);
            }
        }

        private bool ReturnChildBags(String bag)
        {
            var ChildBags = Bags[bag];
            foreach (var child in ChildBags)
            {
                if (child.Contains("-")) return false;
                if (child.Contains("shiny gold")){return true;}

                else if (ReturnChildBags(child.Remove(0, 2))) {return true; }

            }

            return false;
        }
        
        private int ReturnAllShinyChildBags(String bag)
        {
            var ChildBags = Bags[bag];
            int noOfBags = 0;

            foreach(var child in ChildBags)
            {
                if (child.Contains("-"))
                    return noOfBags;
                
                int coefOfBag = Convert.ToInt32(child.Split(" ")[0]);
                noOfBags += coefOfBag + coefOfBag * ReturnAllShinyChildBags(child.Remove(0, 2));
            }

            return noOfBags;
        }

        public int FirstTask()
        {
            int noOfBags = 0;
            foreach(var bag in Bags.Keys)
            {
                if(ReturnChildBags(bag))
                    ++noOfBags;
            }

            return noOfBags;
        }

        public int SecondTask()
        {
            int noOfBags = 0;
            String keyBag = "shiny gold ";

            foreach (String bag in Bags[keyBag])
            {
                int coefOfBag = Convert.ToInt32(bag.Split(" ")[0]);
                noOfBags += coefOfBag + coefOfBag * ReturnAllShinyChildBags(bag.Remove(0, 2));
            }

            return noOfBags;
        }
    }
}
