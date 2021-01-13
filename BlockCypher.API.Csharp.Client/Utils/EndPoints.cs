namespace BlockCypher.API.Csharp.Client.Utils
{
    public static class EndPoints
    {
        public static readonly string TokenLimits = "/v1/tokens";

        public static readonly string ChainEndpoint = "/v1/eth/main";
        public static readonly string BlockHashEndpoint = "/v1/eth/main/blocks/$BLOCK_HASH";
        public static readonly string BlockHeightEndpoint = "/v1/eth/main/blocks/$BLOCK_HEIGHT";

        public static readonly string AddressBalanceEndpoint = "/v1/eth/main/addrs/$ADDRESS/balance";
        public static readonly string AddressEndpoint = "/v1/eth/main/addrs/$ADDRESS";
        public static readonly string Address = "/v1/eth/main/addrs";

        public static readonly string TransactionHashEndpoint = "/v1/eth/main/txs/$TXHASH";
        public static readonly string UnconfirmedTransactionsEndpoint = "/v1/eth/main/txs";
        public static readonly string NewTransactionEndpoint = "v1/eth/main/txs/new";
    }
}
