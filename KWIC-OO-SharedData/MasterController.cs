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
            CircularShifter circularShifter = new CircularShifter();

            input.Read(lineStorage);
            circularShifter.Shift(lineStorage);
        }
        
    }
}
