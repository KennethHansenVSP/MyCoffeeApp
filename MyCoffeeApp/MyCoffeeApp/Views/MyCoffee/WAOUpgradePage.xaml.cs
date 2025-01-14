﻿using MyCoffeeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCoffeeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WAOUpgradePage : ContentPage
    {
        public WAOUpgradePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = (WAOUpgradeViewModel)BindingContext;
            if (vm.BuildingsColl.Count == 0)
                await vm.RefreshCommand.ExecuteAsync();
        }
    }
}