﻿using BlockCypher.API.Csharp.Client.Models.Enums;
using System.Threading.Tasks;

namespace BlockCypher.API.Csharp.Client.Domain.Interfaces
{
    public interface IApiClient
    {
        /// <summary>
        /// Calls API Methods.
        /// </summary>
        /// <typeparam name="T">Type to which the response content will be converted.</typeparam>
        /// <param name="method">HTTPMethod (POST-GET-PUT-DELETE)</param>
        /// <param name="endpoint">Url endpoing.</param>
        /// <param name="isSigned">Specifies if the request needs a signature.</param>
        /// <param name="parameters">Request parameters.</param>
        /// <returns></returns>
        Task<T> CallAsync<T>(ApiMethod method, string endpoint, bool IsTokenRequst=false , string parameters = null, object Content = null);
    }
}
