using System;
using System.Collections.Generic;
using System.Text;

namespace BlockCypher.API.Csharp.Client.Models.General
{
    /// <summary>
    /// A PaymentForward object represents a request set up through the Payment Forwarding service.
    /// </summary>
    public class PaymentForward
    {
        /// <summary>
        /// Identifier of the payment forwarding request; generated when a new request is created.
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// The mandatory user token.
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// The required destination address for payment forwarding.
        /// </summary>
        public string destination { get; set; }
        /// <summary>
        /// The address which will automatically forward to destination; generated when a new request is created.
        /// </summary>
        public string input_address { get; set; }
        /// <summary>
        /// Optional The URL to call anytime a new payment is forwarded.
        /// </summary>
        public Uri callback_url { get; set; }
        /// <summary>
        /// Optional Whether to also call the callback_url with subsequent confirmations of the forwarding transactions. Automatically sets up a WebHook.
        /// </summary>
        public bool enable_confirmations { get; set; }
        /// <summary>
        /// Optional Gas price for the forwarding transaction, in gwei. If not set, defaults to 80 gwei.
        /// </summary>
        public int gas_price_gwei { get; set; }
        public string[] txs { get; set; }
    }

}
