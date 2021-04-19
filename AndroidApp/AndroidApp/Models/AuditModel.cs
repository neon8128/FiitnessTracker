using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidApp.Models
{
    public partial class AuditModel
    {
     
        public UInt64 Id { get; set; }
        public String Username { get; set; }
        public DateTime? Ts { get; set; }
        public String Details { get; set; }
        public String MachineName { get; set; }
        public String Ip { get; set; }


    }
}
