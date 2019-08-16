using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyRate.Model
{
    public class RatePerDay
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("bank")]
        public string Bank { get; set; }

        [JsonProperty("baseCurrency")]
        public long BaseCurrency { get; set; }

        [JsonProperty("baseCurrencyLit")]
        public BaseCurrency BaseCurrencyLit { get; set; }

        [JsonProperty("exchangeRate")]
        public List<ExchangeRate> ExchangeRate { get; set; }
    }
}
