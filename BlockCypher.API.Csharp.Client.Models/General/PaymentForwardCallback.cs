using System;
using System.Collections.Generic;
using System.Text;

namespace BlockCypher.API.Csharp.Client.Models.General
{
    public class PaymentForwardCallback
    {
        /// <summary>
        /// Amount sent to the destination address, in wei.
        /// </summary>
        public long value { get; set; }
        /// <summary>
        /// The intermediate address to which the payment was originally sent.
        /// </summary>
        public string input_address { get; set; }
        /// <summary>
        /// The final destination address to which the payment will eventually be sent.
        /// </summary>
        public string destination { get; set; }
        /// <summary>
        /// The transaction hash of the generated transaction that forwards the payment from the input_address to the destination.
        /// </summary>
        public string transaction_hash { get; set; }
    }

}
