using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWIC_OO_SharedData
{
    public class Input
    {
        public void Read(LineStorage lineStorage)
        {
            bool isValidFile = false;
            
            Console.Clear();
            Console.Title = "KWIC - OO and Shared Data";
            string filePath = "";
            List<string> inputFile;
            while (!isValidFile)
            {
                Console.WriteLine("Please enter a valid path of data file:");
                filePath = Console.ReadLine();

                try
                {
                    inputFile = File.ReadLines(filePath).ToList();
                                       
                    for (int i = 0; i < inputFile.Count; i++)
                    {
                        // create new empty line to be filled
                        lineStorage.addEmptyLine();

                        // grab line and break it up into words
                        string[] words = inputFile[i].Split(new char[] {' '});

                        for (int j = 0; j < words.Length; j++)
                        {
                            // add the words to the LineStorage
                            lineStorage.addWord(words[j], i);
                        }
                    }
                    

                    isValidFile = true;
                }
                catch (Exception)
                {
                    isValidFile = false;
                }
            }

            
            
        }
    }
}
