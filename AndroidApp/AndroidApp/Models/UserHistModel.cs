using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidApp.Models
{
    class UserHistModel
    {
        public UInt64 Id { get; set; }
        public String Username { get; set; }
        public String Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public String Role { get; set; }
        public Int32 Version { get; set; }
        public byte[] Salt { get; set; }
    }
}
