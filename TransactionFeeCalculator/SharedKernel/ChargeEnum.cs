using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionFeeCalculator.SharedKernel
{
    public enum ChargeEnum
    {
        BelowFiveThousand = 0,
        BetweenFiveThousandAndFiftyThousand,
        AboveFiftyThousand
    }
}
