using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweep_Stakes
{
    class SweepstakesManagerFactory
    {
        public ISweepstakesManager ChooseSweepstakesManager(string message)
        {
            string response = UserInterface.GetUserInput(message);
            ISweepstakesManager manager = null;
            switch (response)
            {
                case "stack":
                    manager = new SweepstakesStackManager();
                    break;

                case "queue":
                    manager = new SweepstakesQueueManager();
                    break;

                default:
                    return ChooseSweepstakesManager(message);
            }
            return manager;
        }
    }
}
