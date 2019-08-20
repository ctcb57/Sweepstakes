using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public static class UserInterface
    {
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine().Trim();
            return input;
        }




        public static int AssignRegistrationNumber()
        {
            int number =
            Console.WriteLine("Your registrstation number is: " + number);
            return number;
        }

        public static void AssignContestantInformation(Contestant contestant)
        {
            contestant.firstName = GetUserInput("Please enter your first name:");
            contestant.lastName = GetUserInput("Please enter your last name:");
            contestant.emailAddress = GetUserInput("Please enter your email address:");
            contestant.registrationNumber = GetUserInputInt();
        }

        public static int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            int number = random.Next(min, max);
            return number;
        }
    }
}
