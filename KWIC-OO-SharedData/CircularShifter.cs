using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWIC_OO_SharedData
{
    public class CircularShifter
    {
        List<int> wordIndices = new List<int>();
        List<int> lineIndices = new List<int>();

        int[,] circularShifts;

        public void Shift(LineStorage lineStorage)
        {
            for(int i = 0; i < lineStorage.GetLineIndexLength(); i++)
            {
                wordIndices.Add(lineStorage.GetLineIndex(i));
                lineIndices.Add(i);
                int lastIndex = 0;

                if(i != lineStorage.GetLineIndexLength() - 1)
                {
                    lastIndex = lineStorage.GetLineIndex(i + 1);
                }
                else
                {
                    lastIndex = lineStorage.GetCharCoreLength();
                }

                for(int j = lineStorage.GetLineIndex(i); j < lastIndex; j++)
                {
                    if(lineStorage.GetChar(j) == ' ')
                    {
                        wordIndices.Add(j + 1);
                        lineIndices.Add(i);
                    }
                }
            }
            circularShifts = new int[2, wordIndices.Count];

            for(int i = 0; i < wordIndices.Count; i++)
            {
                circularShifts[0, i] = lineIndices[i];
                circularShifts[1, i] = wordIndices[i];
            }
        }
    }
}
