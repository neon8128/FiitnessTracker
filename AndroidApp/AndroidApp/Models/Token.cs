using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidApp.Models
{
    class Token
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("nbf")]
        public int Nbf { get; set; }

        [JsonProperty("exp")]
        public int Exp { get; set; }

        [JsonProperty("iat")]
        public int Iat { get; set; }
    }
}
