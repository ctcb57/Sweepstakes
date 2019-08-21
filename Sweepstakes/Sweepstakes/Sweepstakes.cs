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
            sweepstakesName = name;
            contestants = new Dictionary<int, Contestant>();
        }

        public void RegisterContestant(Contestant contestant)
        {
            UserInterface.AssignContestantInformation(contestant, this);
            contestants.Add(contestant.registrationNumber, contestant);
        }

        public string PickWinner()
        {
            int count = contestants.Count;
            int winnerNumber = UserInterface.GenerateRandomNumber(1, count + 1);
            contestants.TryGetValue(winnerNumber, out Contestant value);
            return value.firstName + " " + value.lastName;
        }

        public void PrintContestantInfo()
        {
            Console.WriteLine(PickWinner());
            Console.ReadLine();
        }

        
    }
}
