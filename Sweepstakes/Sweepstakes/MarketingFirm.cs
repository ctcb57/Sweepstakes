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



        //public void CreateSweepstakes(string message, Sweepstakes sweepstakes, Contestant contestant)
        //{
        //    int numberOfEntries = UserInterface.GetIntUserInput(message);
        //    for(int i = 0; i < numberOfEntries; i++)
        //    {
        //        sweepstakes.RegisterContestant(contestant);
        //    }
        //    sweepstakesManager.InsertSweepstakes(sweepstakes);
        //}

        public void RunSweepstakes()
        {
            for(int i = 0; i < sweepstakesManager.Count; i++)
            {
                Sweepstakes sweepstakes1 = sweepstakesManager.GetSweepstakes();
                sweepstakes1.PickWinner();
            }
        }

            //Notify contestants

            //

    }
}
