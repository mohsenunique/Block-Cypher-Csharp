using System;
using System.Collections.Generic;
using System.Text;

namespace BlockCypher.API.Csharp.Client.Models.General
{
    /// <summary>
    /// A Blockchain represents the current state of the Ethereum blockchain. Typically returned from the Chain API endpoint.
    /// </summary>
    public class Blockchain
    {
        /// <summary>
        /// The name of the blockchain represented, in the form of $COIN.$CHAIN.
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// The current height of the blockchain; i.e., the number of blocks in the blockchain.
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// The hash of the latest confirmed block in the blockchain; in Ethereum, the hashing function is Keccak/SHA3.
        /// </summary>
        public string hash { get; set; }
        /// <summary>
        /// The time of the latest update to the blockchain; typically when the latest block was added.
        /// </summary>
        public DateTime time { get; set; }
        /// <summary>
        /// The BlockCypher URL to query for more information on the latest confirmed block; returns a Block.
        /// </summary>
        public Uri latest_url { get; set; }
        /// <summary>
        /// The hash of the second-to-latest confirmed block in the blockchain.
        /// </summary>
        public string previous_hash { get; set; }
        /// <summary>
        /// The BlockCypher URL to query for more information on the second-to-latest confirmed block; returns a Block.
        /// </summary>
        public Uri previous_url { get; set; }
        /// <summary>
        /// N/A, will be deprecated soon.
        /// </summary>
        public int peer_count { get; set; }
        /// <summary>
        /// Number of unconfirmed transactions in memory pool (likely to be included in next block).
        /// </summary>
        public int unconfirmed_count { get; set; }
        /// <summary>
        /// A rolling average of the gas price (in wei) for transactions to be confirmed within 1 to 2 blocks.
        /// </summary>
        public long high_gas_price { get; set; }
        /// <summary>
        /// A rolling average of the gas price (in wei) for transactions to be confirmed within 3 to 6 blocks.
        /// </summary>
        public long medium_gas_price { get; set; }
        /// <summary>
        /// A rolling average of the gas price (in wei) for transactions to be confirmed in 7 or more blocks.
        /// </summary>
        public long low_gas_price { get; set; }
        /// <summary>
        /// Optional The current height of the latest fork to the blockchain; when no competing blockchain fork present, not returned with endpoints that return Blockchains.
        /// </summary>
        public int last_fork_height { get; set; }
        /// <summary>
        /// Optional The hash of the latest confirmed block in the latest fork of the blockchain; when no competing blockchain fork present, not returned with endpoints that return Blockchains.
        /// </summary>
        public string last_fork_hash { get; set; }
    }

}
