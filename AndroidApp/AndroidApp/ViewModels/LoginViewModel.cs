using AndroidApp.Services.Auth;
using AndroidApp.Utility;
using AndroidApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AndroidApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private String _userName;
        public String UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
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

        
        public  ICommand _loginCommand { get; }
        public Auth _loginService { get; }

        public LoginViewModel()
        {

          _loginCommand = new Command(OnLoginClicked);
           
        }
        
       
       
        
        public async void OnLoginClicked()
        {
          
  
           var logService = new Auth();
          var  canLogIn = await logService.Login(UserName, Password);
           
            
           if (canLogIn)
           {
              
                App.NavigationService.NavigateTo(ViewNames.NewItemPage);
           }

           else
           {
               await App.Current.MainPage.DisplayAlert("Test Title", "Test", "OK");
           }
        

        }

       
    }
}
