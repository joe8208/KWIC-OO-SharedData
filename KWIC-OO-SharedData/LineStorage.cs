using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWIC_OO_SharedData
{
    public class LineStorage
    {
        // represents the list of lines for the system
        List<List<string>> lines = new List<List<string>>();

        public void setChar(int lineNumber, int wordPosition, int charPosition, char c)
        {
            List<string> currentLine = lines[lineNumber];
            string currentWord = currentLine[wordPosition];
            char[] chars = currentWord.ToCharArray();
            chars[charPosition] = c;
        }
    }
}
