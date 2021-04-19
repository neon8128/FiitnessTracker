﻿using AndroidApp.Models;
using AndroidApp.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AndroidApp.Services.Auth
{
   public  class Auth : IAuth
    {
        public async  Task<bool> Login(String Username, String Password)
        {
            var login = new UserLoginDto()
            {
                Username = Username,
                Password = Password
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(login); // serializing the login object 
            var content = new StringContent(json, Encoding.UTF8, "application/json"); //specifying the json format 
            var response = await httpClient.PostAsync(AppSettings.Url+"/auth/login", content);
            // calling post async with the json object

            if(!response.IsSuccessStatusCode)
            {
                return false;
            }
            var jsonResult = await response.Content.ReadAsStringAsync();

            var jwtToken = JsonConvert.DeserializeObject<Token>(jsonResult);
            Preferences.Set("Token", jwtToken.Data); // save the jwt token in the local storage
            Preferences.Set("Username", jwtToken.Username);
            Preferences.Set("Role", jwtToken.Role);
            return true;

        }

        public Task<String> Register(UserModel User, String Password)
        {
            throw new NotImplementedException();
        }
    }
}
