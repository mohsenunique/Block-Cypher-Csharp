using System;
using System.Collections.Generic;
using System.Text;

namespace BlockCypher.API.Csharp.Client.Models.General
{
    /// <summary>
    /// An Address represents the state of an Ethereum address/account, containing information about the state of balances and transactions related to this address. Typically returned from the Address Balance and Address endpoints.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// The requested address.
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// Total amount of confirmed wei received by this address.
        /// </summary>
        public ulong total_received { get; set; }
        /// <summary>
        /// Total amount of confirmed wei sent by this address.
        /// </summary>
        public ulong total_sent { get; set; }
        /// <summary>
        /// Balance of confirmed wei on this address. (i.e., for transactions whose confirmations > 0).
        /// </summary>
        public ulong balance { get; set; }
        /// <summary>
        /// Balance of unconfirmed wei on this address. Can be negative (if unconfirmed transactions are just spending part of an address balance). Only unconfirmed transactions (haven't made it into a block) are included in this calculation.
        /// </summary>
        public ulong unconfirmed_balance { get; set; }
        /// <summary>
        /// Total balance of wei, including confirmed and unconfirmed transactions, for this address.
        /// </summary>
        public ulong final_balance { get; set; }
        /// <summary>
        /// Number of confirmed transactions on this address. Only transactions that have made it into a block (confirmations > 0) are counted.
        /// </summary>
        public int n_tx { get; set; }
        /// <summary>
        /// Number of unconfirmed transactions for this address. Only unconfirmed transactions (confirmations == 0) are counted.
        /// </summary>
        public int unconfirmed_n_tx { get; set; }
        /// <summary>
        /// Final number of transactions, including confirmed and unconfirmed transactions, for this address.
        /// </summary>
        public int final_n_tx { get; set; }
        /// <summary>
        /// Optional To retrieve base URL transactions. To get the full URL, concatenate this URL with a transaction's hash.
        /// </summary>
        public Uri tx_url { get; set; }
        /// <summary>
        /// Optional Array of transaction summaries for this address. Usually only returned from the standard Address Endpoint.
        /// </summary>
        public TXRef[] txrefs { get; set; }
        /// <summary>
        /// Optional All unconfirmed transaction summaries for this address. Usually only returned from the standard Address Endpoint.
        /// </summary>
        public TXRef[] unconfirmed_txrefs { get; set; }
        /// <summary>
        /// Optional If true, then the Address object contains more transactions than shown. Useful for determining whether to poll the API for more transaction information.
        /// </summary>
        public bool hasMore { get; set; }
        public int nonce { get; set; }
        public int pool_nonce { get; set; }

    }
}
