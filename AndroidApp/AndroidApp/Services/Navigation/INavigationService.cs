using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AndroidApp.Services.Navigation
{
   public  interface INavigationService
    {
        Page MainPage { get; }
        void Configure(String Key, Type PageType);
        void GoBack();
        void NavigateTo(String Key, object parameter = null);
    }
}
