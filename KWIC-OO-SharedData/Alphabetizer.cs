using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWIC_OO_SharedData
{
    public class Alphabetizer
    {
        int[,] alphabetized;

        CircularShifter circularShifter;

        public int AlphabetizedLength { get; set; }

        public int LineIndexLength { get; set; }

        public int CharCoreLength { get; set; }

        public Alphabetizer(CircularShifter circularShifter)
        {
            this.circularShifter = circularShifter;
            LineIndexLength = circularShifter.LineIndexLength;
            CharCoreLength = circularShifter.CharCoreLength;
        }

        public int GetAlphabetized(int row, int col)
        {
            return alphabetized[row, col];
        }

        public char GetChar(int index)
        {
            return circularShifter.GetChar(index);
        }

        public int GetLineIndex(int index)
        {
            return circularShifter.GetLineIndex(index);
        }

        
        public void Alphabetize()
        {
            alphabetized = new int[2, circularShifter.GetCircularShiftsLength()];
            AlphabetizedLength = alphabetized.GetLength(1);

            int alphabetizedCount = 0;
            int low, mid, high = 0;
            
            for (int i = 0; i < alphabetized.GetLength(1); i++)
            {
                int lineCount = circularShifter.GetCircularShifts(0, i);
                int shiftBegin = circularShifter.GetCircularShifts(1, i);

                int lineBegin = circularShifter.GetLineIndex(lineCount);
                int lineEnd = 0;
                if (lineCount == circularShifter.LineIndexLength - 1)
                {
                    lineEnd = circularShifter.CharCoreLength;
                }
                else
                {
                    lineEnd = circularShifter.GetLineIndex(lineCount + 1);
                }


                string shift = "";

                if (lineBegin != shiftBegin)
                {
                    shift += circularShifter.GetWord(shiftBegin, lineEnd - shiftBegin);
                    shift += " ";
                    shift += circularShifter.GetWord(lineBegin, shiftBegin - lineBegin - 1);
                }
                else
                {
                    shift += circularShifter.GetWord(lineBegin, lineEnd - lineBegin);
                }


                // binary search
                low = 0;
                high = alphabetizedCount - 1;

                while(low <= high)
                {
                    mid = (low + high) / 2;

                    int midLineCount = alphabetized[0, mid];
                    int midShiftBegin = alphabetized[1, mid];
                    int midLineBegin = circularShifter.GetLineIndex(midLineCount);
                    int midLineEnd = 0;

                    if (midLineCount == circularShifter.LineIndexLength - 1)
                    {
                        midLineEnd = circularShifter.CharCoreLength;
                    }
                    else
                    {
                        midLineEnd = circularShifter.GetLineIndex(midLineCount + 1);
                    }

                    string midLine = "";
                    if (midLineBegin != midShiftBegin)
                    {
                        midLine += circularShifter.GetWord(midShiftBegin, midLineEnd - midShiftBegin);
                        midLine += " ";
                        midLine += circularShifter.GetWord(midLineBegin, midShiftBegin - midLineBegin - 1);
                    }
                    else
                    {
                        midLine += circularShifter.GetWord(midLineBegin, midLineEnd - midLineBegin);
                    }

                    // comparer
                    int compared = shift.CompareTo(midLine);

                    if (compared > 0)
                        low = mid + 1;
                    else if (compared < 0)
                        high = mid - 1;
                    else
                    {
                        low = mid;
                        high = mid - 1;
                    }

                    
                }
                    Array.Copy(alphabetized, low, alphabetized, low + 1, alphabetizedCount - low);
                    alphabetized[0, low] = lineCount;
                    alphabetized[1, low] = shiftBegin;
                    alphabetizedCount++;

            }
        }
        
    }
}
