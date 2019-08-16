using Autofac;
using Autofac.Core;
using CurrencyRate.Services;
using CurrencyRate.View;
using CurrencyRate.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CurrencyRate
{
    public partial class App : Application
    {
        public static IContainer Container;
        public static ContainerBuilder Builder;
        public App()
        {
            RegisterType();
            InitializeComponent();
            MainPage = new MainPage();
        }
        private void RegisterType()
        {
            Builder = new ContainerBuilder();
            Builder.RegisterType<MainPageViewModel>();
            Builder.RegisterType<PrivatBankService>(); 
            App.Container = Builder.Build();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
