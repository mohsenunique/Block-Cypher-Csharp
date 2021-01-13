using BlockCypher.API.Csharp.Client.Domain.Abstract;
using BlockCypher.API.Csharp.Client.Domain.Interfaces;
using BlockCypher.API.Csharp.Client.Models.Enums;
using BlockCypher.API.Csharp.Client.Models.General;
using BlockCypher.API.Csharp.Client.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlockCypher.API.Csharp.Client
{
    public class BlockCypherClient : BlockCypherClientAbstract
    {
        public BlockCypherClient(IApiClient apiClient) : base(apiClient)
        {

        }
        public async Task<TokenLimitation> TokenLimits(string Token)
        {
            if (string.IsNullOrWhiteSpace(Token))
            {
                throw new ArgumentException("Token cannot be empty.", "Token");
            }
            var result = await _apiClient.CallAsync<TokenLimitation>(ApiMethod.GET, $"{EndPoints.TokenLimits}/{Token}");

            return result;
        }
        #region Blockchain API
        /// <summary>
        /// General information about the Ethereum blockchain is available by GET-ing the base resource.
        /// </summary>
        /// <returns>The returned object contains a litany of information, including its height, the time/hash of the latest block, and more. For Ethereum, the object includes information on gas_price, denoted in wei. Unlike Bitcoin, fees are determined by the computational execution cost of the transaction via gas; in order to prevent runaway contract execution, each operation in Ethereum's Virtual Machine requires a fixed/known amount of gas. While the amount of gas is fixed for a given EVM operation, the price of gas fluctuates based on market demand on the Ethereum blockchain (similar to Bitcoin fees). For more detail, check this very helpful Stack Exchange explanation.</returns>
        public async Task<Blockchain> ChainEndpoint()
        {
            var result = await _apiClient.CallAsync<Blockchain>(ApiMethod.GET, EndPoints.ChainEndpoint);
            return result;
        }
        /// <summary>
        /// If you want more data on a particular block, you can use the Block Hash endpoint.
        /// </summary>
        /// <param name="BLOCK_HASH">s a string representing the hash of the block you're interested in querying</param>
        /// <param name="txstart">Filters response to only include transaction hashes after txstart in the block.</param>
        /// <param name="limit">Filters response to only include a maximum of limit transactions hashes in the block. Maximum value allowed is 500.</param>
        /// <returns>The returned object contains information about the block, including its height, the total amount of wei transacted within it, the number of transactions in it, transaction hashes listed in the canonical order in which they appear in the block, and more. For more detail on the data returned, check the Block object.</returns>
        public async Task<Block> BlockHashEndpoint(string BLOCK_HASH,int txstart=0,int limit=500)
        {
            if (string.IsNullOrWhiteSpace(BLOCK_HASH))
            {
                throw new ArgumentException("BLOCK_HASH cannot be empty.", "BLOCK_HASH");
            }
            var args = $"txstart={txstart}&limit={limit}";
            var result = await _apiClient.CallAsync<Block>(ApiMethod.GET, EndPoints.BlockHashEndpoint.Replace("$BLOCK_HASH", BLOCK_HASH), false, args);
            return result;
        }

        /// <summary>
        /// You can also query for information on a block using its height, using the same resource but with a different variable type.
        /// </summary>
        /// <param name="BLOCK_HEIGHT">BLOCK_HEIGHT is an integer representing the height of the block you're interested in querying.</param>
        /// <param name="txstart">Filters response to only include transaction hashes after txstart in the block.</param>
        /// <param name="limit">Filters response to only include a maximum of limit transactions hashes in the block. Maximum value allowed is 500.</param>
        /// <returns>As above, the returned object contains information about the block, including its hash, the total amount of wei transacted within it, the number of transactions in it, transaction hashes listed in the canonical order in which they appear in the block, and more. For more detail on the data returned, check the Block object.</returns>
        public async Task<Block> BlockHeightEndpoint(int BLOCK_HEIGHT, int txstart = 0, int limit = 500)
        {
            if (BLOCK_HEIGHT==0)
            {
                throw new ArgumentException("BLOCK_HEIGHT cannot be 0.", "BLOCK_HEIGHT");
            }
            var args = $"txstart={txstart}&limit={limit}";
            var result = await _apiClient.CallAsync<Block>(ApiMethod.GET, EndPoints.BlockHeightEndpoint.Replace("$BLOCK_HEIGHT", BLOCK_HEIGHT.ToString()), false, args);
            return result;
        }
        #endregion

        #region Address API
        /// <summary>
        /// The Address Balance Endpoint is the simplest---and fastest---method to get a subset of information on a public address.
        /// </summary>
        /// <param name="ADDRESS">ADDRESS is a string representing the public address you're interested in querying, for example: 738d145faabb1e00cf5a017588a9c0f998318012</param>
        /// <returns>The returned object contains information about the address, including its balance in wei and the number of transactions associated with it. The endpoint omits any detailed transaction information, but if that isn't required by your application, then it's the fastest and preferred way to get public address information.</returns>
        public async Task<Address> AddressBalanceEndpoint(string ADDRESS)
        {
            if (string.IsNullOrWhiteSpace(ADDRESS))
            {
                throw new ArgumentException("ADDRESS cannot be empty.", "ADDRESS");
            }
            var result = await _apiClient.CallAsync<Address>(ApiMethod.GET, EndPoints.AddressBalanceEndpoint.Replace("$ADDRESS", ADDRESS));
            return result;
        }

        /// <summary>
        /// The Address Endpoint returns more information about an address' transactions than the Address Balance Endpoint, but sacrifices some response speed in the process.
        /// </summary>
        /// <param name="ADDRESS">ADDRESS is a string representing the public address (or wallet/HD wallet name) you're interested in querying, for example: 738d145faabb1e00cf5a017588a9c0f998318012</param>
        /// <param name="before">Filters response to only include transactions below before height in the blockchain.</param>
        /// <param name="after">Filters response to only include transactions above after height in the blockchain.</param>
        /// <param name="limit">limit sets the minimum number of returned TXRefs; there can be less if there are less than limit TXRefs associated with this address, but there can be more in the rare case of more TXRefs in the block at the bottom of your call. This ensures paging by block height never misses TXRefs. Defaults to 200, maximum is 2000.</param>
        /// <param name="confirmations">If set, only returns the balance and TXRefs that have at least this number of confirmations.</param>
        /// <returns>The returned object contains information about the address, including its balance in wei, the number of transactions associated with it, and transaction summaries in descending order by block height.</returns>
        public async Task<Address> AddressEndpoint(string ADDRESS,int before=0,int after=0,int limit=0,int confirmations=0)
        {
            if (string.IsNullOrWhiteSpace(ADDRESS))
            {
                throw new ArgumentException("ADDRESS cannot be empty.", "ADDRESS");
            }
            var args = (before != 0 ? $"before={before}&" : "")
                + (after != 0 ? $"after={after}&" : "")
                + (limit != 0 ? $"limit={limit}&" : "")
                 + (confirmations != 0 ? $"confirmations={confirmations}&" : "");

            var result = await _apiClient.CallAsync<Address>(ApiMethod.GET, EndPoints.AddressEndpoint.Replace("$ADDRESS", ADDRESS),false,args);
            return result;
        }
        /// <summary>
        /// The Generate Address endpoint allows you to generate private-public key-pairs along with an associated public address. No information is required with this POST request.
        /// </summary>
        /// <returns>The returned object contains a private key, a public key, and a public address, all hex-encoded.</returns>
        public async Task<AddressKeychain> GenerateAddressEndpoint()
        {
            var result = await _apiClient.CallAsync<AddressKeychain>(ApiMethod.POST, EndPoints.Address, true);
            return result;
        }

        #endregion

        #region Transaction API

        /// <summary>
        /// The Transaction Hash Endpoint returns detailed information about a given transaction based on its hash.
        /// </summary>
        /// <param name="TXHASH">TXHASH is a string representing the hex-encoded transaction hash you're interested in querying, for example: 8f39fb4940c084460da00a876a521ef2ba84ad6ea8d2f5628c9f1f8aeb395342</param>
        /// <returns>The returned object contains detailed information about the transaction, including the value transfered, fees collected, date received, any scripts associated with an output, and more.</returns>
        public async Task<TX> TransactionHashEndpoint(string TXHASH)
        {
            if (string.IsNullOrWhiteSpace(TXHASH))
            {
                throw new ArgumentException("TXHASH cannot be empty.", "TXHASH");
            }
            var result = await _apiClient.CallAsync<TX>(ApiMethod.GET, EndPoints.TransactionHashEndpoint.Replace("$TXHASH", TXHASH));

            return result;
        }
        /// <summary>
        /// The Unconfirmed Transactions Endpoint returns an array of the latest transactions that haven't been included in any blocks.
        /// </summary>
        /// <returns>The returned object is an array of transactions that haven't been included in blocks, arranged in reverse chronological order (latest is first, then older transactions follow).</returns>
        public async Task<IList<TX>> UnconfirmedTransactionsEndpoint()
        {
            var result = await _apiClient.CallAsync<IList<TX>>(ApiMethod.GET, EndPoints.UnconfirmedTransactionsEndpoint);

            return result;
        }
        /// <summary>
        /// Using BlockCypher's API, you can push transactions to Ethereum in one of two ways: 1-Use another Ethereum library to create your transactions, then push them using our raw-transaction-endpoint Use our two-endpoint process outlined below, wherein we generate a TXSkeleton based on your input address, output address, and value to transfer. In either case, for security reasons, we never take possession of your private keys.
        /// </summary>
        /// <param name="Tx">To use BlockCypher's two-endpoint transaction creation tool, first you need to provide the input address, output address, and value to transfer (in wei). Provide this in a partially-filled out TX request object.</param>
        /// <returns>As a return object, you'll receive a TXSkeleton containing a slightly-more complete TX alongside data you need to sign in the tosign array. You'll need this object for the next steps of the transaction creation process.</returns>
        public async Task<TXSkeleton> NewTransactionEndpoint(TX Tx)
        {
            if (Tx.Equals(null))
            {
                throw new ArgumentException("Tx cannot be null.", "Tx");
            }
            var result = await _apiClient.CallAsync<TXSkeleton>(ApiMethod.POST, EndPoints.NewTransactionEndpoint, true, null, Tx);

            return result;
        }


        #endregion

    }
}
