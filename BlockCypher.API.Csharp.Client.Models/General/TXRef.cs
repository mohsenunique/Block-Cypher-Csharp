using System;
using System.Collections.Generic;
using System.Text;

namespace BlockCypher.API.Csharp.Client.Models.General
{
    /// <summary>
    /// A TXRef object represents summarized data about a transaction input or output. Typically found in an array within an Address object, which is usually returned from the standard Address Endpoint.
    /// </summary>
    public class TXRef
    {
        
        /// <summary>
        /// Height of the block that contains this transaction input/output. If it's unconfirmed, this will equal -1.
        /// </summary>
        public int block_height { get; set; }
        /// <summary>
        /// The hash of the transaction containing this input/output.
        /// </summary>
        public string tx_hash { get; set; }
        /// <summary>
        /// Index of this input in the enclosing transaction. 0 if it's an input, -1 if it's an output.
        /// </summary>
        public int tx_input_n { get; set; }
        /// <summary>
        /// Index of this output in the enclosing transaction. -1 if it's an input, 0 if it's an output.
        /// </summary>
        public int tx_output_n { get; set; }
        /// <summary>
        /// The value transfered by this input/output in wei exchanged in the enclosing transaction.
        /// </summary>
        public long value { get; set; }
        /// <summary>
        /// true if this is an attempted double spend; false otherwise.
        /// </summary>
        public bool double_spend { get; set; }
        /// <summary>
        /// Number of subsequent blocks, including the block the transaction is in. Unconfirmed transactions have 0 confirmations.
        /// </summary>
        public int confirmations { get; set; }
        /// <summary>
        /// Optional The past balance of the parent address the moment this transaction was confirmed. Not present for unconfirmed transactions.
        /// </summary>
        public long ref_balance { get; set; }
        /// <summary>
        /// Optional Time at which transaction was included in a block; only present for confirmed transactions.
        /// </summary>
        public DateTime confirmed { get; set; }
        /// <summary>
        /// Optional If this transaction is a double-spend (i.e. double_spend == true) then this is the hash of the transaction it's double-spending.
        /// </summary>
        public string double_of { get; set; }

    }

}
