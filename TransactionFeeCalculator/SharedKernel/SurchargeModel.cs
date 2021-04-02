using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionFeeCalculator.SharedKernel
{
    public class SurchargeModel
    {
       public decimal Amount { get; set; }
        public decimal TransferAmount { get; set; }
        public decimal Charge { get; set; }
        public decimal DebitAmount { get; set; }

        public static SurchargeModel Create(decimal Amount, decimal charge)
        {
            var amountToTransfer = Amount - charge;
            SurchargeModel transactionDetails = new SurchargeModel
            {
                Amount = Amount,
                TransferAmount = amountToTransfer,
                Charge = charge,
                DebitAmount = amountToTransfer + charge
            };

            return transactionDetails;
        }
    }
}
