using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweep_Stakes
{
    class SweepstakesManagerFactory
    {
        public ISweepstakesManager ChooseSweepstakesManager()
        {
            string message = UserInterface.GetUserInput("stack or queue");
            ISweepstakesManager manager = null;
            switch (message)
            {
                case "stack":
                    manager = new SweepstakesStackManager();
                    break;

                case "queue":
                    manager = new SweepstakesQueueManager();
                    break;

                default:
                    break;
            }
            return manager;
        }
    }
}
