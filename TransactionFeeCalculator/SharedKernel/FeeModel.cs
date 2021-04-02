using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionFeeCalculator.SharedKernel
{
    public class FeeModel
    {
        public decimal maxAmount { get; set; }
        public decimal minAmount { get; set; }
        public decimal feeAmount { get; set; }
    }
}
