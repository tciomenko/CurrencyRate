using Autofac;
using CurrencyRate.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace CurrencyRate.View
{
    [DesignTimeVisible(false)]
    public class AbstractPage<T> : ContentPage where T : IViewModel
    {
        readonly T _viewModel;
        public T ViewModel
        {
            get { return _viewModel; }
        }

        public AbstractPage()
        {
            using (var scope = App.Container.BeginLifetimeScope())
            {
                _viewModel = App.Container.Resolve<T>();
            }
            BindingContext = _viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewModel.OnDisappearing();
        }
    }
}
