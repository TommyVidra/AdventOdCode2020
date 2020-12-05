using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    class Day5
    {
        SortedSet<int> BoardingIds = new SortedSet<int>();


        public Day5(List<String> input)
        {
            int maxRow = 127;
            int minRow = 0;
            int maxColumn = 7;
            int minColumn = 0;
            int row = 0;
            int column = 0; 

            foreach (string line in input)
            {
                var charArray = line.ToCharArray();
                foreach(char c in charArray)
                {
                    int sumRow = maxRow - minRow;
                    int sumColumn = maxColumn - minColumn;
                    switch(c)
                    {
                        case 'F':
                            if (sumRow % 2 == 1)
                                maxRow -= ((sumRow / 2) + 1);
                            else
                                maxRow -= sumRow / 2;
                            break;
                        case 'B':
                            if (sumRow % 2 == 1)
                                minRow += (sumRow / 2) + 1;
                            else
                                minRow += sumRow / 2;
                            break;
                        case 'R':
                            if (minColumn + 1 == maxColumn)
                                column = maxColumn;
                            if (sumColumn % 2 == 1)
                                minColumn += ((sumColumn / 2) + 1);
                            else
                                minColumn += sumColumn / 2;
                            break;
                        case 'L':
                            if (minColumn == maxColumn - 1)
                                column = minColumn;
                            if (sumColumn % 2 == 1)
                                maxColumn -= ((sumColumn / 2) + 1);
                            else
                                maxColumn -= sumColumn / 2;
                            break;
                    }
                }
                if (maxRow == minRow)
                    row = maxRow;
                var id = row * 8 + column; 
                BoardingIds.Add((int)id);

                maxRow = 127;
                minRow = 0;
                maxColumn = 7;
                minColumn = 0;
                row = 0;
                column = 0;
            }
        }

        public int FirstTask()
        {
            return BoardingIds.Max;
        }

        public int SecondTask()
        {
            int myId = 0;
            int lastKey = 0;
            foreach(int key in BoardingIds)
            {
                if (lastKey + 2 == key)
                    return key - 1;
                lastKey = key;
            }
            return myId;
        }
    }
}
