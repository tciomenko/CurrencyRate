using Autofac;
using CurrencyRate.Model;
using CurrencyRate.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace CurrencyRate.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel : IViewModel
    {
        PrivatBankService PrivatBankService;
        public RatePerDay RatePerDay { get; set; }
        public List<string> FixedList = new List<string>();
        public DateTime currentDate;
        public DateTime CurrentDate {
            get => currentDate;
            set {
                    currentDate = value;
                    if (GetRateCommand.CanExecute(value))
                        GetRateCommand?.Execute(value);
                }
        }
        public DateTime MinDate { get; set; } = DateTime.Parse("01/01/2017");
        public ICommand GetRateCommand;

        public MainPageViewModel()
        {
            using (var scope = App.Container.BeginLifetimeScope())
            {
                PrivatBankService = App.Container.Resolve<PrivatBankService>();
            }
            FixedList.Add("EUR");
            FixedList.Add("PLZ");
            GetRateCommand = new Command<DateTime>(async (dateTime) => { RatePerDay = await GetRatePB(dateTime); });
            CurrentDate = DateTime.Now;
        }
        private async Task<RatePerDay> GetRatePB(DateTime dateTime)
        {
            var _rate= await PrivatBankService.GetRate(dateTime);
            if(FixedList.Any())
                _rate.ExchangeRate = _rate.ExchangeRate.Where((rate) => FixedList.Any((f) => rate.Currency == f)).Union(_rate.ExchangeRate).ToList();
            return _rate;
        }
    }
}
