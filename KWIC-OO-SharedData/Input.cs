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
        public List<string> Execute()
        {
            bool isValidFile = false;

            Console.Clear();
            Console.Title = "KWIC - OO and Shared Data";
            string filePath = "";
            List<string> inputFile = new List<string>();

            while (!isValidFile)
            {
                Console.WriteLine("Please enter a valid path of data file:");
                filePath = Console.ReadLine();

                try
                {
                    inputFile = File.ReadLines(filePath).ToList();
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
