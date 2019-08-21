using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

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
                    SendEmailToWinner(winner.emailAddress);
                }
                else
                {
                    SendEmailToLosers(sweepstakes.contestants[i].emailAddress);
                }
            }
        }

        public void SendEmailToWinner(string emailAddress)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Name", "devcodecampsweepstakes@gmail.com"));
            message.To.Add(new MailboxAddress("WinnerName", emailAddress));
            message.Subject = "You're a winner!";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey Winner,

You entered a sweepstakes recently and won!

-- Charlie"
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s,c,h,e) => true;

                client.Connect("smtp.gmail.com", 587, false);

                client.Authenticate("devcodecampsweepstakes", "Cc283192");

                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void SendEmailToLosers(string emailAddress)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Name", "devcodecampsweepstakes@gmail.com"));
            message.To.Add(new MailboxAddress("WinnerName", emailAddress));
            message.Subject = "You're a loser!";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey Loser,

You entered a sweepstakes recently and lost!  Better luck next time!

-- Charlie"
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 587, false);

                client.Authenticate("devcodecampsweepstakes", "Cc283192");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
