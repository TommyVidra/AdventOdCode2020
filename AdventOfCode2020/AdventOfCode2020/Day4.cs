using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    class Day4
    {
        IDictionary<int, List<String>> Passports = new Dictionary<int, List<String>>();
        Dictionary<int, Dictionary<String, String>> PassportsRequlations = new Dictionary<int, Dictionary<String, String>>();

        private int minBirthYear = 1920;
        private int maxBirthYear = 2002;
        private int minIssueYear = 2010;
        private int maxIssueYear = 2020;
        private int minExpirationYear = 2020;
        private int maxExpirationYear = 2030;

        private int minCmHeight = 150;
        private int maxCmHeight = 193;
        private int minInHeight = 59;
        private int maxInHeight = 76;

        private List<String> EyeColor = new List<String>();


        public Day4(IList<String> input)
        {
            EyeColor.Add("amb");
            EyeColor.Add("blu");
            EyeColor.Add("brn");
            EyeColor.Add("gry");
            EyeColor.Add("grn");
            EyeColor.Add("hzl");
            EyeColor.Add("oth");

            int key = 0;
            var TmpFields = new List<String>();
            var TmpPassport = new Dictionary<String, String>();
            foreach(String line in input)
            {
                if (line.Length > 2)
                {
                    foreach (String field in line.Split(" "))
                    {
                        TmpPassport.Add(field.Split(":")[0], field.Split(":")[1]);
                        TmpFields.Add(field.Split(":")[0]);
                    }
                }
                else
                {
                    Passports.Add(key, TmpFields);
                    PassportsRequlations.Add(key, TmpPassport);
                    ++key;
                    TmpPassport = new Dictionary<String, String>();
                    TmpFields = new List<String>();
                }
            }
        }

        private bool IsValid(int key)
        {
            switch (Passports[key].Count)
            {
                case 8:
                    return true;
                case 7:
                    if (!(Passports[key].Contains("cid")))
                        return true;
                    return false;
                default:
                    return false;
            }
        }

        public int FirstTask()
        {
            int valid = 0;

            foreach(int key in Passports.Keys)
            {
                if (IsValid(key))
                    ++valid;
            }
            return valid + 1; 
        }

        public int SecondTask()
        {
            int valid = 0;

            foreach (int key in Passports.Keys)
            {
                bool canPass = false;
                if (IsValid(key))
                {
                    var TmpPassport = PassportsRequlations[key];
                    if ((Convert.ToInt32(TmpPassport["byr"]) >= minBirthYear && Convert.ToInt32(TmpPassport["byr"]) <= maxBirthYear))
                    {
                        if ((Convert.ToInt32(TmpPassport["iyr"]) >= minIssueYear && Convert.ToInt32(TmpPassport["iyr"]) <= maxIssueYear))
                        {
                            if ((Convert.ToInt32(TmpPassport["eyr"]) >= minExpirationYear && Convert.ToInt32(TmpPassport["eyr"]) <= maxExpirationYear))
                            {
                                if (((TmpPassport["hcl"].StartsWith("#")) && (TmpPassport["hcl"].Length == 7)) && !(Regex.IsMatch(TmpPassport["hcl"], @"^[g-z]+$")))
                                {
                                    if ((EyeColor.Contains(TmpPassport["ecl"])))
                                    {
                                        if ((Regex.IsMatch(TmpPassport["pid"], @"^[0-9]+$")) && (TmpPassport["pid"].Length == 9))
                                        {
                                            if (TmpPassport["hgt"].Contains("cm") || TmpPassport["hgt"].Contains("in"))
                                            {
                                                if (TmpPassport["hgt"].EndsWith("cm") && (Convert.ToInt32(TmpPassport["hgt"].Replace("cm", "")) >= minCmHeight && Convert.ToInt32(TmpPassport["hgt"].Replace("cm", "")) <= maxCmHeight))
                                                    canPass = true;
                                                else if (TmpPassport["hgt"].EndsWith("in") && (Convert.ToInt32(TmpPassport["hgt"].Replace("in", "")) >= minInHeight && Convert.ToInt32(TmpPassport["hgt"].Replace("in", "")) <= maxInHeight))
                                                    canPass = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    
                }

                if (canPass)
                    ++valid;
            }


            return valid + 1;
        }
    }
}
