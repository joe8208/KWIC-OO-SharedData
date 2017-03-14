using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWIC_OO_SharedData
{
    class Output
    {
        Alphabetizer alpha;

        public Output(Alphabetizer alpha)
        {
            this.alpha = alpha;
        }
        public void Write()
        {
            for (int i = 0; i < alpha.AlphabetizedLength; i++)
            {
                int lineCount = alpha.GetAlphabetized(0, i);
                int shiftBegin = alpha.GetAlphabetized(1, i);
                int lineBegin = alpha.GetLineIndex(lineCount);

                int lineEnd = 0;

                if (lineCount == alpha.LineIndexLength - 1)
                {
                    lineEnd = alpha.CharCoreLength;
                }
                else
                {
                    lineEnd = alpha.GetLineIndex(lineCount + 1);
                }

                if (lineBegin != shiftBegin)
                {
                    for (int j = shiftBegin; j < lineEnd; j++)
                    {
                        Console.Write(alpha.GetChar(j));
                    }
                    Console.Write(' ');

                    for (int j = lineBegin; j < shiftBegin - 1; j++)
                    {
                        Console.Write(alpha.GetChar(j));
                    }
                }
                else
                {
                    for (int j = lineBegin; j < lineEnd; j++)
                    {
                        Console.Write(alpha.GetChar(j));
                    }
                }
                Console.Write('\n');
            }            
        }
    }
}
