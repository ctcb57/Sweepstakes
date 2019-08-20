using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public static class UserInterface
    {
        public static string GetUserInput()
        {
            Console.WriteLine("Enter the information below:");
            return Console.ReadLine().Trim();
        }

        public static int GetUserInputInt()
        {
            int response;
            Console.WriteLine("Enter the information below:");
            while(!int.TryParse(Console.ReadLine(), out response) || response <= 0)
            {
                Console.WriteLine("Invalid entry. Enter the information again:");
            }
            return response;

        }

        public static void AssignContestantInformation(Contestant contestant)
        {
            Console.WriteLine("Please enter your first name:");
            contestant.firstName = GetUserInput();
            contestant.lastName = GetUserInput();
            contestant.emailAddress = GetUserInput();
            contestant.registrationNumber = GetUserInputInt();
        }
    }
}
