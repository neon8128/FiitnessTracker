using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidApp.Models
{
   public class UserModel
    {
        public String Username { get; set; }
        public String Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public String Role { get; set; }
        public Int32 Version { get; set; }
        public byte[] Salt { get; set; }
    }
}
