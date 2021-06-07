using AndroidApp.Services.Auth;
using AndroidApp.Utility;
using AndroidApp.Validators;
using AndroidApp.Validators.Rules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AndroidApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
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
                OnPropertyChanged(nameof(Username));
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
                OnPropertyChanged(nameof(Password));
            }
        }

        private String _email;
        public String Email
        { 
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        private bool _emailValid;
        public bool EmailValid
        {
            get
            {
                return _emailValid;
            }
            set
            {
                _emailValid = value;
                OnPropertyChanged("EmailValid");
            }
        }
        private bool _usernameValid;
        public bool UsernameValid
        {
            get
            {
                return _usernameValid;
            }
            set
            {
                _usernameValid = value;
                OnPropertyChanged("UsernameValid");
            }
        }

        private bool _passwordValid;
        public bool PasswordValid
        {
            get
            {
                return _passwordValid;
            }
            set
            {
                _passwordValid = value;
                OnPropertyChanged("PasswordValid");
            }
        }

        public RegisterViewModel()
        {
           
        }

        


        public   ICommand SignUpCommand => new Command(async () =>
        {
            var registerService = new Auth();
            var canRegister = await registerService.Register(Username,Password,Email);
           if(AreFieldsValid() && canRegister) // checks is fields are valid
            {
                await App.Current.MainPage.DisplayAlert("Welcome", "", "Ok");// display message
                App.NavigationService.NavigateTo(ViewNames.LoginPage);
            }
          
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "One or more fields are not valid", "Ok");
                // display message credentials error
            }
       
        });

        public ICommand GoToLogIn => new Command( () =>
        {
           
                App.NavigationService.NavigateTo(ViewNames.LoginPage);

        });

        private bool AreFieldsValid()
        {
            var valid = PasswordValid && UsernameValid && EmailValid; // true if valid; false otherwise
            var stringNull = String.IsNullOrEmpty(Username) && 
                String.IsNullOrEmpty(Password) && 
                String.IsNullOrEmpty(Email); // true if empty; false otherwise

            return valid && !stringNull;
        }




    }
}
