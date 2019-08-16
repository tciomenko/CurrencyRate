using CurrencyRate.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace CurrencyRate.Services
{
    public class PrivatBankService
    {
        HttpClient httpClient;
        public PrivatBankService()
        {
            httpClient = new HttpClient();
        }
        public async Task<RatePerDay> GetRate(DateTime date)
        {
            var response = await httpClient.GetStringAsync($"https://api.privatbank.ua/p24api/exchange_rates?json&date={date.ToString("dd/MM/yyyy")}");
            var ratePerDay = JsonConvert.DeserializeObject<RatePerDay>(response);
            return ratePerDay;
        }
    }
}