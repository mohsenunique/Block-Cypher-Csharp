using System;
using System.Collections.Generic;
using System.Text;

namespace BlockCypher.API.Csharp.Client.Models.General
{
    /// <summary>
    /// A TXSkeleton is a convenience/wrapper Object that's used primarily when Creating Transactions through the New and Send endpoints.
    /// </summary>
    public class TXSkeleton
    {
        /// <summary>
        /// A temporary TX, usually returned fully filled.
        /// </summary>
        public TX tx { get; set; }
        /// <summary>
        /// Array of hex-encoded data for you to sign, containing one element for you to sign. Still an array to maintain parity with the Bitcoin API.
        /// </summary>
        public string[] tosign { get; set; }
        /// <summary>
        /// Array of signatures corresponding to all the data in tosign, typically provided by you. Only one signature is required.
        /// </summary>
        public string[] signatures { get; set; }
        /// <summary>
        /// Optional Array of errors in the form "error":"description-of-error". This is only returned if there was an error in any stage of transaction generation, and is usually accompanied by a HTTP 400 code.
        /// </summary>
        public string[] errors { get; set; }
    }
}
