using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockCypher.API.Csharp.Client.Models.General
{
    /// <summary>
    /// An AddressKeychain represents an associated collection of public and private keys alongside their respective Ethereum address. Generally returned and used with the Generate Address Endpoint.
    /// </summary>
    public class AddressKeychain
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("private")]
        public string Private { get; set; }
        /// <summary>
        /// Hex-encoded Public key.
        /// </summary>
        [JsonProperty("public")]
        public string Public { get; set; }
        /// <summary>
        /// Hex-encoded Private key.
        /// </summary>
        public string address { get; set; }
    }

}
