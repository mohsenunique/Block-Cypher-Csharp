using System;
using System.Collections.Generic;
using System.Text;

namespace BlockCypher.API.Csharp.Client.Models.General
{
    /// <summary>
    /// A Block represents the current state of a particular block from a Blockchain. Typically returned from the Block Hash and Block Height endpoints.
    /// </summary>
    public class Block
    {
        /// <summary>
        /// The hash of the block; in Ethereum, the hashing function is Keccak/SHA3
        /// </summary>
        public string hash { get; set; }
        /// <summary>
        /// The height of the block in the blockchain; i.e., there are height earlier blocks in its blockchain.
        /// </summary>
        public long height { get; set; }
        /// <summary>
        /// The depth of the block in the blockchain; i.e., there are depth later blocks in its blockchain.
        /// </summary>
        public int depth { get; set; }
        /// <summary>
        /// The name of the blockchain represented, in the form of $COIN.$CHAIN
        /// </summary>
        public string chain { get; set; }
        /// <summary>
        /// The total number of wei transacted in this block.
        /// </summary>
        public long total { get; set; }
        /// <summary>
        /// The total number of fees---in wei---collected by miners in this block.
        /// </summary>
        public long fees { get; set; }
        /// <summary>
        /// Raw size of block (including header and all transactions) in bytes.
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// Block version.
        /// </summary>
        public int ver { get; set; }
        /// <summary>
        /// Recorded time at which block was built.
        /// </summary>
        public DateTime time { get; set; }
        /// <summary>
        /// The time BlockCypher's servers receive the block.
        /// </summary>
        public DateTime received_time { get; set; }
        /// <summary>
        /// The Ethereum address of the miner that received the coinbase and fee reward.
        /// </summary>
        public string coinbase_addr { get; set; }
        /// <summary>
        /// Address of the peer that sent BlockCypher's servers this block.
        /// </summary>
        public string relayed_by { get; set; }
        /// <summary>
        /// The number used by a miner to generate this block.
        /// </summary>
        public ulong nonce { get; set; }
        /// <summary>
        /// Number of transactions in this block.
        /// </summary>
        public int n_tx { get; set; }
        /// <summary>
        /// The hash of the previous block in the blockchain.
        /// </summary>
        public string prev_block { get; set; }
        /// <summary>
        /// The BlockCypher URL to query for more information on the previous block.
        /// </summary>
        public Uri prev_block_url { get; set; }
        /// <summary>
        /// The base BlockCypher URL to receive transaction details. To get more details about specific transactions, you must concatenate this URL with the desired transaction hash(es).
        /// </summary>
        public Uri tx_url { get; set; }
        /// <summary>
        /// The Merkle root of this block.
        /// </summary>
        public string mrkl_root { get; set; }
        /// <summary>
        /// An array of transaction hashes in this block (initiated by externally controlled accounts). By default, only 20 are included.
        /// </summary>
        public string[] txids { get; set; }
        /// <summary>
        /// An array of internal transaction hashes (initiated by internal contracts) in this block. By default, only 20 are included.
        /// </summary>
        public string[] internal_txids { get; set; }
        /// <summary>
        /// Optional If there are more transactions that couldn't fit in the txids array, this is the BlockCypher URL to query the next set of transactions (within a Block object).
        /// </summary>
        public Uri next_txids { get; set; }
        /// <summary>
        /// Optional If there are more internal transactions that couldn't fit in the internal_txids array, this is the BlockCypher URL to query the next set of transactions (within a Block object).
        /// </summary>
        public Uri next_internal_txids { get; set; }
        /// <summary>
        /// List of uncle blocks by hash included by the miner of this block. You can read more about uncles here.<a href="https://www.cryptocompare.com/mining/guides/what-are-mining-rewards-in-ethereum/">here</a> 
        /// </summary>
        public string[] uncles { get; set; }

    }

}
