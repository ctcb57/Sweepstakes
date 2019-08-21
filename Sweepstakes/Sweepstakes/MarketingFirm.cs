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

        //need to make factory class
        //
        public MarketingFirm(ISweepstakesManager sweepstakesManager)
        {
            this.sweepstakesManager = sweepstakesManager;
        }
    }
}
