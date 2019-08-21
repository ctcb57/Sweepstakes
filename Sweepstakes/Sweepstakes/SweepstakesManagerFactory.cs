using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweep_Stakes
{
    class SweepstakesManagerFactory
    {
        public void ChooseSweepstakesManager()
        {
            string input = UserInterface.GetUserInput("Choose which manager method you would like to use (stack or queue):");
            switch (input)
            {
                case "stack":
                    MarketingFirm newStackMethod = new MarketingFirm(new SweepstakesStackManager());
                    break;
                case "queue":
                    MarketingFirm newQueueMethod = new MarketingFirm(new SweepstakesQueueManager());
                    break;
                default:
                    break;
            }
        }
    }
}
