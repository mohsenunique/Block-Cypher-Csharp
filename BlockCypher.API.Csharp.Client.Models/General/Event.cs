using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockCypher.API.Csharp.Client.Models.General
{
    /// <summary>
    /// An Event represents a WebHooks or WebSockets-based notification request, as detailed in the Events & Hooks section of the documentation.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Identifier of the event; generated when a new request is created.
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// Type of event; can be unconfirmed-tx, new-block, confirmed-tx, tx-confirmation, double-spend-tx.
        /// </summary>
        [JsonProperty("event")]
        public string _event { get; set; }
        /// <summary>
        /// optional Only objects with a matching hash will be sent. The hash can either be for a block or a transaction.
        /// </summary>
        public string hash { get; set; }
        /// <summary>
        /// optional Only transactions associated with the given address will be sent.
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// optional Used in concert with the tx-confirmation event type to set the number of confirmations desired for which to receive an update. You'll receive an updated TX for every confirmation up to this amount. The maximum allowed is 10; if not set, it will default to 6.
        /// </summary>
        public int confirmations { get; set; }
        public string token { get; set; }
        /// <summary>
        /// optional Callback URL for this Event's WebHook; not applicable for WebSockets usage.
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// Number of errors when attempting to POST to callback URL; not applicable for WebSockets usage.
        /// </summary>
        public int callback_errors { get; set; }
        public string filter { get; set; }
    }

}
