using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionFeeCalculator.SharedKernel;

namespace TransactionFeeCalculator
{
    public class AppSettingManager
    {
         public static IConfiguration Configuration { get; set; }
        public static List<FeeModel> Fetch(string fetchingKey)
        {
            string stringValue = "";

            try
            {
                stringValue = Configuration[$"Appsettings:{fetchingKey}"] ?? "";
                var section = Configuration.GetSection($"Appsettings:{fetchingKey}");
                var folders = section.Get<List<FeeModel>>();
                return section.Get<List<FeeModel>>();
            }
            catch
            {
                // ignored
                return null;
            }
           
        }
    }
}
