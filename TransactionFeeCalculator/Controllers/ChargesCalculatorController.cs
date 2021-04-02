using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionFeeCalculator.Engine;

namespace TransactionFeeCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ChargesCalculatorController : Controller
    {
        [HttpGet]
        public IActionResult GetCHarges(decimal Amount)
        {
            var Transaction = TransactionEngine.GetCharges(Amount);
            return (Transaction.status) ? Ok(Transaction) : Ok(Transaction);
        }

        [HttpPost]
        public IActionResult SurchargeTransactionDetails(decimal Amount)
        {
            var Transaction = TransactionEngine.SurchargeDetails(Amount);
            return (Transaction.status) ? Ok(Transaction) : Ok(Transaction);
        }
    }
}
