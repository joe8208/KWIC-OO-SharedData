using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWIC_OO_SharedData
{
    public class NoiseRemover
    {
        IEnumerable<string> noiseWordsFile = new List<string>();

        

        public NoiseRemover()
        {
            try
            {
                noiseWordsFile = File.ReadLines("noiseword.txt").ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public bool HasNoiseWords(string input)
        {            

            // iterate and remove any lines that start with any of the noise words.
            
            
            string[] words = input.Split(new char[] { ' ' });

            // check to see if the first word in line matches a noise word

            foreach (string noiseWord in noiseWordsFile)
            {
                if (words[0].ToLower() == noiseWord.ToLower())
                {
                    return true;
                }
            }
            return false;
            
        }
    }
}
