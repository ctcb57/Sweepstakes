using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweep_Stakes
{
    class Program
    {
        static void Main(string[] args)
        {
            Sweepstakes test = new Sweepstakes("test");
            Contestant newContestant = new Contestant();

            test.RegisterContestant(newContestant);
            test.RegisterContestant(newContestant);

            test.PickWinner();
            test.PrintContestantInfo(newContestant);
        }
    }
}
