using AndroidApp.ViewModels;
using AndroidApp.Views;
using Autofac;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AndroidApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            BindingContext = App.Container.Resolve<AppShellViewModel>();
        }

        
    }
}
