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
        public List<string> Read()
        {
            bool isValidFile = false;
            char[] core;
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

                    foreach (string line in inputFile)
                    {

                    }

                    isValidFile = true;
                }
                catch (Exception)
                {
                    isValidFile = false;
                }
            }

            
                        
            return inputFile;
        }
    }
}
