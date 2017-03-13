using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWIC_OO_SharedData
{
    public class MasterController
    {
        

        public void Execute()
        {
            Input input = new Input();
            LineStorage lineStorage = new LineStorage();
            CircularShifter circularShifter = new CircularShifter(lineStorage);
            Alphabetizer alphabetizer = new Alphabetizer(circularShifter);
            Output output = new Output(alphabetizer);

            input.Read(lineStorage);
            circularShifter.Shift();
            alphabetizer.Alphabetize();
            output.Write();
        }
        
    }
}
