using AndroidApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AndroidApp.Services.Auth
{
    interface IAuth
    {
        Task<bool> Login(String Username, String Password);

        Task<bool> Register(String User, String Password, String Email);

    }
}
