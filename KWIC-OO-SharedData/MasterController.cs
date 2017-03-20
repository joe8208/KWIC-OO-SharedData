using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace KWIC_OO_SharedData
{
    public class MasterController
    {
        Input input;
        LineStorage lineStorage;
        CircularShifter circularShifter;
        Alphabetizer alphabetizer;
        Output output;

        public void Execute()
        {
            // create and call input
            input = new Input();
            lineStorage = new LineStorage();
            input.Read(lineStorage);

            // start timer to track performance
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // create and call circular shifter
            circularShifter = new CircularShifter(lineStorage);
            circularShifter.Shift();


            // create and call Alphabetizer
            alphabetizer = new Alphabetizer(circularShifter);
            alphabetizer.Alphabetize();


            // create and call Output
            output = new Output(alphabetizer);
            

            output.Write();
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString());
            Console.ReadLine();
        }
        
    }
}
