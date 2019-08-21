using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweep_Stakes
{
    public static class UserInterface
    {
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string input = 
            Console.ReadLine().Trim();
            return input;
        }

        public static int GetIntUserInput(string message)
        {
            Console.WriteLine(message);
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input <= 0)
            {
                Console.WriteLine("Invalid response. Please enter a number.");
            }
            return input;
        }


        public static void AssignContestantInformation(Contestant contestant, Sweepstakes sweepstakes)
        {
            contestant.firstName = GetUserInput("Please enter your first name:");
            contestant.lastName = GetUserInput("Please enter your last name:");
            contestant.emailAddress = GetUserInput("Please enter your email address:");
            contestant.registrationNumber = sweepstakes.contestants.Count + 1;
            Console.WriteLine($"Your registration number is {contestant.registrationNumber.ToString()}.");
            Console.WriteLine("Thanks for entering.  Press enter to exit");
            Console.ReadLine();
        }

        public static int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            int number = random.Next(min, max);
            return number;
        }

        public static void IdentifyWinner(string winner, Sweepstakes sweepstakes)
        {
            Console.WriteLine($"The winner of the sweepstakes is: {winner}");
        }

        public static void ChooseSweepstakesManager()
        {
            Console.WriteLine("Choose which Sweepstakes Manager you would like to use.");
        }

        public static void NotifyWinner(string message)
        {
            Console.WriteLine(message);
        }

        public static void NotifyLosers(string message)
        {
            Console.WriteLine(message);
        }
    }
}
