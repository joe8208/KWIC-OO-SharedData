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

        public void Alphabetize(CircularShifter circularShift)
        {
            alphabetized = new int[2, circularShift.GetCircularShiftsLength()];

            int alphabetizedCount = 0;
            int low, mid, high = 0;
            
            for (int i = 0; i < alphabetized.GetLength(0); i++)
            {
                int lineCount = circularShift.GetCircularShifts(0, i);
                int shiftBegin = circularShift.GetCircularShifts(1, i);

                int lineBegin = circularShift.GetLineIndex(lineCount);
                int lineEnd = 0;
                if (lineCount == circularShift.LineIndexLength - 1)
                {
                    lineEnd = circularShift.CharCoreLength;
                }
                else
                {
                    lineEnd = circularShift.GetLineIndex(lineCount + 1);
                }


                string shift = "";

                if (lineBegin != shiftBegin)
                {
                    shift += circularShift.GetWord(shiftBegin, lineEnd - shiftBegin);
                    shift += " ";
                    shift += circularShift.GetWord(lineBegin, shiftBegin - lineBegin - 1);
                }
                else
                {
                    shift += circularShift.GetWord(lineBegin, lineEnd - lineBegin);
                }


                // binary search
                low = 0;
                high = alphabetizedCount - 1;

                while(low <= high)
                {
                    mid = (low + high) / 2;

                    int midLineCount = alphabetized[0, mid];
                    int midShiftBegin = alphabetized[1, mid];
                    int midLineBegin = circularShift.GetLineIndex(midLineCount);
                    int midLineEnd = 0;

                    if (midLineCount == circularShift.LineIndexLength - 1)
                    {
                        midLineEnd = circularShift.CharCoreLength;
                    }
                    else
                    {
                        midLineEnd = circularShift.GetLineIndex(midLineCount + 1);
                    }

                    string midLine = "";
                    if (midLineBegin != midShiftBegin)
                    {
                        midLine += circularShift.GetWord(midShiftBegin, midLineEnd - midShiftBegin);
                        midLine += " ";
                        midLine += circularShift.GetWord(midLineBegin, midShiftBegin - midLineBegin - 1);
                    }
                    else
                    {
                        midLine += circularShift.GetWord(midLineBegin, midLineEnd - midLineBegin);
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

                    Array.Copy(alphabetized[0], low, alphabetized[0], low + 1, alphabetizedCount - low);
                }
            }
        }
    }
}
