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
            SweepstakesManagerFactory testFactory = new SweepstakesManagerFactory();
            MarketingFirm test = new MarketingFirm(testFactory.ChooseSweepstakesManager("Would you like to choose stack or queue?"));

            test.CreateSweepstakes("How many sweepstakes?", "How many entries?", "test");
            test.RunSweepstakes();
        }
    }
}
