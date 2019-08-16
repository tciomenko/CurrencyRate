using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyRate.Model
{
    public class ExchangeRate
    {
        [JsonProperty("baseCurrency")]
        public BaseCurrency BaseCurrency { get; set; }

        [JsonProperty("saleRateNB")]
        public double SaleRateNb { get; set; }

        [JsonProperty("purchaseRateNB")]
        public double PurchaseRateNb { get; set; }

        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        [JsonProperty("saleRate", NullValueHandling = NullValueHandling.Ignore)]
        public double? SaleRate { get; set; }

        [JsonProperty("purchaseRate", NullValueHandling = NullValueHandling.Ignore)]
        public double? PurchaseRate { get; set; }
    }
}
