using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockCypher.API.Csharp.Client.Models.General
{
    public class TokenLimitation
    {
        [JsonProperty("token")]
        public string token { get; set; }
        public Limits limits { get; set; }
        public Hits_History[] hits_history { get; set; }
    }

    public class Limits
    {
        [JsonProperty("api/day")]
        public int apiday { get; set; }
        [JsonProperty("api/hour")]
        public int apihour { get; set; }
        [JsonProperty("api/second")]
        public int apisecond { get; set; }
        [JsonProperty("confidence/hour")]
        public int confidencehour { get; set; }
        [JsonProperty("hooks")]
        public int hooks { get; set; }
        [JsonProperty("hooks/hour")]
        public int hookshour { get; set; }
    }

    public class Hits_History
    {
        [JsonProperty("api/hour")]
        public int apihour { get; set; }
        public DateTime time { get; set; }
    }

}
