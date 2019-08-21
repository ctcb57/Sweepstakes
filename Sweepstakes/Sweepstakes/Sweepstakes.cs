using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweep_Stakes
{
    public class Sweepstakes
    {
        public string sweepstakesName;
        public Dictionary<int, Contestant> contestants;
        public Sweepstakes(string name)
        {
            this.sweepstakesName = name;
            this.contestants = new Dictionary<int, Contestant>();
        }

        public void RegisterContestant(Contestant contestant)
        {
            UserInterface.AssignContestantInformation(contestant, this);
            contestants.Add(contestant.registrationNumber, contestant);
        }
        //Mike Heinisch stated it was ok to have a method which returns the winner as the object and a different one which makes that a string
        public Contestant GetWinner()
        {
            int count = contestants.Count;
            int winnerNumber = UserInterface.GenerateRandomNumber(1, count + 1);
            contestants.TryGetValue(winnerNumber, out Contestant value);
            return value;
        }

        public string PickWinner(Contestant contestant)
        {
            return contestant.firstName + " " + contestant.lastName;
        }

        public void PrintContestantInfo(string winner)
        {
            Console.WriteLine(winner);
            Console.ReadLine();
        }

        
    }
}
