using AndroidApp.Services.Auth;
using AndroidApp.Utility;
using AndroidApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Forms;

namespace AndroidApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private String _username;
        public String Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        private String _password;
        public String Password
        {
            get
            {
               return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public ICommand _goToRegister { get; }
        public  ICommand _loginCommand { get; }
        public Auth _loginService { get; }

        public LoginViewModel()
        {

          _loginCommand = new Command(OnLoginClicked);
           _goToRegister = new Command(OnRegisterClick);
        }

        private async void OnRegisterClick(object obj)
        {
            App.NavigationService.NavigateTo(ViewNames.RegisterPage);
            
        }

        public async void OnLoginClicked()
        {
           
           var logService = new Auth();
           var  canLogIn = await logService.Login(Username, Password);
           
            
           if (canLogIn)
           {
              
                App.NavigationService.NavigateTo(ViewNames.FirstPage);
           }

           else
           {
               await App.Current.MainPage.DisplayAlert("Error", "Username or password are incorrect", "OK");
           }
        

        }

        public  ICommand SignInWithBiometrics => new Command(async () =>
       {

           var availability = await   // true if  biometrics are available ; false otherwise
            CrossFingerprint.Current.IsAvailableAsync();

           if(!availability)
           {
               await App.Current.MainPage.DisplayAlert("Warning", "No biometrics available", "Ok");
               return;
           }

           var authResult = await CrossFingerprint.Current.AuthenticateAsync(new
               AuthenticationRequestConfiguration("Heads up", "I would like" +
               " to use your biometrics"));
            
           if(authResult.Authenticated)
           {
               App.NavigationService.NavigateTo(ViewNames.FirstPage);
           }

       });

       
    }
}
