using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    class Day8
    {
        private Dictionary<int, String> Operations = new Dictionary<int, String>();
        public Day8(List<String> Input)
        {
            int key = 0;
            foreach (String line in Input)
            {
                Operations.Add(key, line);
                key++;
            }
        }

        public int FirstTask()
        {
            int accValue = 0;

            DoesItTerminate(ref accValue, Operations);

            return accValue;
        }

        private bool DoesItTerminate(ref int accValue, Dictionary<int, String> OperationsCopy)
        {
            List<int> ExecutedLines = new List<int>();
            int key = 0;

            while (!(OperationsCopy.Count == key))
            {

                if (ExecutedLines.Contains(key))
                    return false;

                String operation = OperationsCopy[key];

                switch (operation.Split(" ")[0])
                {
                    case "nop":
                        ExecutedLines.Add(key);
                        key++;
                        break;
                    case "acc":
                        accValue += Convert.ToInt32(operation.Split(" ")[1]);
                        ExecutedLines.Add(key);
                        key++;
                        break;
                    case "jmp":
                        ExecutedLines.Add(key);
                        key += Convert.ToInt32(operation.Split(" ")[1]);
                        break;
                }
            }
            return true;
        }

        public int SecondTask()
        {
            int accValue = 0;
            Dictionary<int, String> OperationsCopy = new Dictionary<int, String>();
            foreach (var key in Operations.Keys)
                OperationsCopy.Add(key, Operations[key]);

            foreach(var operationLine in Operations.Keys)
            {
                if (Operations[operationLine].Contains("nop"))
                {
                    String operation = Operations[operationLine];
                    OperationsCopy.Remove(operationLine);
                    OperationsCopy.Add(operationLine, operation.Replace("nop", "jmp"));
                    if (DoesItTerminate(ref accValue, OperationsCopy))
                        return accValue;
                    accValue = 0;
                    OperationsCopy.Remove(operationLine);
                    OperationsCopy.Add(operationLine, operation.Replace("jmp", "nop"));
                }
                else if (Operations[operationLine].Contains("jmp"))
                {
                    String operation = Operations[operationLine];
                    OperationsCopy.Remove(operationLine);
                    OperationsCopy.Add(operationLine, operation.Replace("jmp", "nop"));
                    if (DoesItTerminate(ref accValue, OperationsCopy))
                        return accValue;
                    accValue = 0;
                    OperationsCopy.Remove(operationLine);
                    OperationsCopy.Add(operationLine, operation.Replace("nop", "jmp"));
                }
            }
           

            return accValue;
        }
    }
}
