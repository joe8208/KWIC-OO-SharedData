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
        

        public void Execute()
        {
            Input input = new Input();
            LineStorage lineStorage = new LineStorage();
            input.Read(lineStorage);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            CircularShifter circularShifter = new CircularShifter(lineStorage);
            circularShifter.Shift();

            Alphabetizer alphabetizer = new Alphabetizer(circularShifter);
            alphabetizer.Alphabetize();

            Output output = new Output(alphabetizer);
            

            output.Write();
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString());
            Console.ReadLine();
        }
        
    }
}
