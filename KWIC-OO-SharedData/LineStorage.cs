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
            currentWord = chars.ToString();
            currentLine[wordPosition] = currentWord;
        }

        public char getChar(int lineNumber, int wordPosition, int charPosition)
        {
            return (lines[lineNumber][wordPosition].ToCharArray())[charPosition];
        }

        public void addWord(string word, int lineNumber)
        {
            List<string> currentLine = lines[lineNumber];
            currentLine.Add(word);
        }

        public void addEmptyLine()
        {
            List<string> newLine = new List<string>();
            lines.Add(newLine);
        }
    }
}
