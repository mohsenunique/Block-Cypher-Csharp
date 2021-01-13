using System;
using System.Collections.Generic;
using System.Text;

namespace BlockCypher.API.Csharp.Client.Models.General
{
    /// <summary>
    /// A TX represents the current state of a particular transaction from either a Block within a Blockchain, or an unconfirmed transaction that has yet to be included in a Block.
    /// </summary>
    public class TX
    {
        /// <summary>
        /// Height of the block that contains this transaction. If this is an unconfirmed transaction, it will equal -1.
        /// </summary>
        public int block_height { get; set; }
        /// <summary>
        /// The hash of the transaction.
        /// </summary>
        public string hash { get; set; }
        /// <summary>
        /// Array of Ethereum addresses involved in the transaction.
        /// </summary>
        public string[] addresses { get; set; }
        /// <summary>
        /// The total number of wei exchanged in this transaction.
        /// </summary>
        public ulong total { get; set; }
        /// <summary>
        /// The total number of fees---in wei---collected by miners in this transaction. Equal to gas_price * gas_used.
        /// </summary>
        public ulong fees { get; set; }
        /// <summary>
        /// The size of the transaction in bytes.
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// The amount of gas used by this transaction.
        /// </summary>
        public int gas_used { get; set; }
        /// <summary>
        /// The price of gas---in wei---in this transaction.
        /// </summary>
        public ulong gas_price { get; set; }
        /// <summary>
        /// Address of the peer that sent BlockCypher's servers this transaction. May be empty.
        /// </summary>
        public string relayed_by { get; set; }
        /// <summary>
        /// Time this transaction was received by BlockCypher's servers.
        /// </summary>
        public DateTime received { get; set; }
        /// <summary>
        /// Version number of this transaction.
        /// </summary>
        public int ver { get; set; }
        /// <summary>
        /// true if this is an attempted double spend; false otherwise.
        /// </summary>
        public bool double_spend { get; set; }
        /// <summary>
        /// Total number of inputs in the transaction.
        /// </summary>
        public int vin_sz { get; set; }
        /// <summary>
        /// Total number of outputs in the transaction.
        /// </summary>
        public int vout_sz { get; set; }
        /// <summary>
        /// Number of subsequent blocks, including the block the transaction is in. Unconfirmed transactions have 0 confirmations.
        /// </summary>
        public int confirmations { get; set; }
        public int confidence { get; set; }
        /// <summary>
        /// An array object containing a single input with a sequence number (used as a nonce for account balances) and an Ethereum account address. Only contains one input in the array; we still use an array to maintain parity with the Bitcoin API.
        /// </summary>
        public Input[] inputs { get; set; }
        /// <summary>
        /// An array object containing a single output with value (in wei), script, and an Ethereum account address. Only contains one output in the array; we still use an array to maintain parity with the Bitcoin API.
        /// </summary>
        public Output[] outputs { get; set; }
        /// <summary>
        /// Optional If this transaction executed a contract which propagated its own subsequent transactions, then this array will be present, containing the hashes of those subsequent internal transactions.
        /// </summary>
        public string[] internal_txids { get; set; }
        /// <summary>
        /// Optional If this transaction was initiated by a contract, this field will be present, conveying the hash of the parent transaction that executed the contract resulting in this transaction (the inverse of an internal_txids hash).
        /// </summary>
        public string parent_tx { get; set; }
        /// <summary>
        /// Optional Time at which transaction was included in a block; only present for confirmed transactions.
        /// </summary>
        public DateTime confirmed { get; set; }
        /// <summary>
        /// Optional If creating a transaction, can optionally set a higher default gas limit (useful if your recepient is a contract). If not set, default is 21000 gas for external accounts and 80000 for contract accounts.
        /// </summary>
        public int gas_limit { get; set; }
        /// <summary>
        /// Optional If true, this transaction was used to create a contract and contract account. Note that the contract address (in the outputs field) will be blank until the transaction is confirmed.
        /// </summary>
        public bool contract_creation { get; set; }
        /// <summary>
        /// Optional Number of peers that have sent this transaction to BlockCypher; only present for unconfirmed transactions.
        /// </summary>
        public int receive_count { get; set; }
        /// <summary>
        /// Optional Hash of the block that contains this transaction; only present for confirmed transactions.
        /// </summary>
        public string block_hash { get; set; }
        /// <summary>
        /// Optional Canonical, zero-indexed location of this transaction in a block; only present for confirmed transactions.
        /// </summary>
        public int block_index { get; set; }
        /// <summary>
        /// Optional If this transaction is a double-spend (i.e. double_spend == true) then this is the hash of the transaction it's double-spending.
        /// </summary>
        public string double_of { get; set; }
        /// <summary>
        /// Optional If this transaction has an execution error, then this field will be included (e.g. "out of gas").
        /// </summary>
        public string execution_error { get; set; }
    }

    public class Input
    {
        /// <summary>
        /// used as a nonce for account balances
        /// </summary>
        public int sequence { get; set; }
        /// <summary>
        /// Ethereum account address
        /// </summary>
        public string[] addresses { get; set; }
    }

    public class Output
    {
        public ulong value { get; set; }
        public string script { get; set; }
        public string[] addresses { get; set; }
    }

}
