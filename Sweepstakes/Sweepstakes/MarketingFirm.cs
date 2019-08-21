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

        public void RunSweepstakes(string winnerMessage, string loserMessage)
        {
            for(int i = 0; i < sweepstakesManager.Count; i++)
            {
                Sweepstakes sweepstakes1 = sweepstakesManager.GetSweepstakes();
                Contestant winner = sweepstakes1.GetWinner();
                NotifyContestants(sweepstakes1, winner, winnerMessage, loserMessage);
                string sweepstakesWinner = sweepstakes1.PickWinner(winner);
                sweepstakes1.PrintContestantInfo(sweepstakesWinner);
            }
        }

        public void NotifyContestants(Sweepstakes sweepstakes, Contestant winner, string winnerMessage, string loserMessage)
        {
            int entryNumber = winner.registrationNumber;
            sweepstakes.contestants.TryGetValue(entryNumber, out Contestant value);
            for(int i = 0; i < sweepstakes.contestants.Count; i++)
            {
                if(sweepstakes.contestants[i].registrationNumber == value.registrationNumber)
                {
                    SendEmailToWinner(winnerMessage);
                }
                else
                {
                    SendEmailToLosers(loserMessage);
                }
            }
        }

        public void SendEmailToWinner(string message)
        {
            UserInterface.NotifyWinner(message);
        }

        public void SendEmailToLosers(string message)
        {
            UserInterface.NotifyLosers(message);
        }

    }
}
