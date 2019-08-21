using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweep_Stakes
{
    class MarketingFirm
    {
        public ISweepstakesManager sweepstakesManager;

        public MarketingFirm(ISweepstakesManager sweepstakesManager)
        {
            this.sweepstakesManager = sweepstakesManager;
        }

        public void CreateContestant(Sweepstakes sweepstakes, Contestant contestant)
        {
            sweepstakes.RegisterContestant(contestant);
        }


        public void CreateSweepstakes(string sweepstakesMessage, string entriesMessage, Sweepstakes sweepstakes, Contestant contestant)
        {
            int numberOfSweepstakes = UserInterface.GetIntUserInput(sweepstakesMessage);
            for (int i = 0; i < numberOfSweepstakes; i++)
            {
                int numberOfEntries = UserInterface.GetIntUserInput(entriesMessage);
                for (int j = 0; j < numberOfEntries; j++)
                {
                    sweepstakes.RegisterContestant(contestant);
                }
                sweepstakesManager.InsertSweepstakes(sweepstakes);
            }
        }

        public void RunSweepstakes()
        {
            for(int i = 0; i < sweepstakesManager.Count; i++)
            {
                Sweepstakes sweepstakes1 = sweepstakesManager.GetSweepstakes();
                string winner = sweepstakes1.PickWinner();
                sweepstakes1.PrintContestantInfo(winner);
            }
        }

            //Notify contestants

            //

    }
}
