using AndroidApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidApp.Utility
{
    //locates the viewmodel associated with the view 
     public static class ViewModelLocator
    {
        public static LoginViewModel _loginViewModel { get; set; }
         = new LoginViewModel();

        public static RegisterViewModel _registerViewModel { get; set; }
         = new RegisterViewModel();
    }
}
