using BlockCypher.API.Csharp.Client.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockCypher.API.Csharp.Client.Domain.Abstract
{
    public abstract class BlockCypherClientAbstract
    {
        /// <summary>
        /// Client to be used to call the API.
        /// </summary>
        public readonly IApiClient _apiClient;
        /// <summary>
        /// Defines the constructor of the Binance client.
        /// </summary>
        /// <param name="apiClient">API client to be used for API calls.</param>
        public BlockCypherClientAbstract(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
    }
}
