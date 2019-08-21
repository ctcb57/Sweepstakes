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


        public void CreateSweepstakes(string sweepstakesMessage, string entriesMessage, string name)
        {
            int numberOfSweepstakes = UserInterface.GetIntUserInput(sweepstakesMessage);
            for (int i = 0; i < numberOfSweepstakes; i++)
            {
                Sweepstakes sweepstakes = new Sweepstakes(name);
                int numberOfEntries = UserInterface.GetIntUserInput(entriesMessage);
                for (int j = 0; j < numberOfEntries; j++)
                {
                    Contestant contestant = new Contestant();
                    sweepstakes.RegisterContestant(contestant);
                }
                sweepstakesManager.InsertSweepstakes(sweepstakes);
            }
        }

        public void RunSweepstakes()
        {
            for(int i = 0; i < sweepstakesManager.Count; i++)
            {
                Sweepstakes sweepstake = sweepstakesManager.GetSweepstakes();
                NotifyContestants(sweepstake);
            }
        }

        public void NotifyContestants(Sweepstakes sweepstakes)
        {
            Contestant winner = sweepstakes.GetWinner();
            for (int i = 1; i <= sweepstakes.contestants.Count; i++)
            {
                if(sweepstakes.contestants[i].registrationNumber == winner.registrationNumber)
                {
                    SendEmailToWinner();
                }
                else
                {
                    SendEmailToLosers();
                }
            }
        }

        public void SendEmailToWinner()
        {
            UserInterface.NotifyWinner();
        }

        public void SendEmailToLosers()
        {
            UserInterface.NotifyLosers();
        }

    }
}
