using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionFeeCalculator.SharedKernel;

namespace TransactionFeeCalculator.Engine
{
    public static class TransactionEngine
    {
        public static TransferResponse GetCharges(decimal Amount)
        {
            try
            {
                decimal transactionCharge = 0;
               // var getAmountFeeRange = AppSettingManager.Fetch("fees");
                switch (Amount)
                {
                    case decimal n when (n <= AppSettingManager.Fetch("fees")[(int)ChargeEnum.BelowFiveThousand].maxAmount && n >= AppSettingManager.Fetch("fees")[(int)ChargeEnum.BelowFiveThousand].minAmount):

                        transactionCharge = AppSettingManager.Fetch("fees")[(int)ChargeEnum.BelowFiveThousand].feeAmount;

                        break;

                    case decimal n when (n <= AppSettingManager.Fetch("fees")[(int)ChargeEnum.BetweenFiveThousandAndFiftyThousand].maxAmount && n >= AppSettingManager.Fetch("fees")[(int)ChargeEnum.BetweenFiveThousandAndFiftyThousand].minAmount):

                        transactionCharge = AppSettingManager.Fetch("fees")[(int)ChargeEnum.BetweenFiveThousandAndFiftyThousand].feeAmount;
                        break;

                    case decimal n when (n <= AppSettingManager.Fetch("fees")[(int)ChargeEnum.AboveFiftyThousand].maxAmount && n >= AppSettingManager.Fetch("fees")[(int)ChargeEnum.AboveFiftyThousand].minAmount):

                        transactionCharge = AppSettingManager.Fetch("fees")[(int)ChargeEnum.AboveFiftyThousand].feeAmount;
                        break;
                }

                return new TransferResponse { Message = $"Amount = {Amount}, Charge = {transactionCharge} Naira only", status = true };
            }
            catch (Exception ex)
            {

                return new TransferResponse { Message = $"Error Processing Transaction, {ex.ToString()}, Please try again", status = false }; 
            }
          
        }

        public static TransferResponse SurchargeDetails(decimal Amount)
        {
            try
            {           
               SurchargeModel transactionDetail = null;
            switch (Amount)
            {
                case decimal n when (n <= AppSettingManager.Fetch("fees")[(int)ChargeEnum.BelowFiveThousand].maxAmount && n >= AppSettingManager.Fetch("fees")[(int)ChargeEnum.BelowFiveThousand].minAmount):

                    transactionDetail = SurchargeModel.Create(Amount, AppSettingManager.Fetch("fees")[(int)ChargeEnum.BelowFiveThousand].feeAmount);

                    break;

                case decimal n when (n <= AppSettingManager.Fetch("fees")[(int)ChargeEnum.BetweenFiveThousandAndFiftyThousand].maxAmount && n >= AppSettingManager.Fetch("fees")[(int)ChargeEnum.BetweenFiveThousandAndFiftyThousand].minAmount):

                    transactionDetail = SurchargeModel.Create(Amount, AppSettingManager.Fetch("fees")[(int)ChargeEnum.BetweenFiveThousandAndFiftyThousand].feeAmount);
                    break;

                case decimal n when (n <= AppSettingManager.Fetch("fees")[(int)ChargeEnum.AboveFiftyThousand].maxAmount && n >= AppSettingManager.Fetch("fees")[(int)ChargeEnum.AboveFiftyThousand].minAmount):

                    transactionDetail = SurchargeModel.Create(Amount, AppSettingManager.Fetch("fees")[(int)ChargeEnum.AboveFiftyThousand].feeAmount);
                    break;
            }

            return new TransferResponse 
            {
                Message = 
                $"Amount= {transactionDetail.Amount}, Transfer Amount = {transactionDetail.TransferAmount}, Charge = {transactionDetail.Charge}, Debit Amount(Transfer Amount + Charge) = {transactionDetail.DebitAmount}",

                status = true          
            
            };

            }
            catch (Exception ex)
            {

                return new TransferResponse { Message = "Transaction fails", status = false};
            }
        }
    }
}
