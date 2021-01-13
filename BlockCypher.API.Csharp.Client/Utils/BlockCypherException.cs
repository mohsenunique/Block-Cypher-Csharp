using System;
using System.Collections.Generic;
using System.Text;

namespace BlockCypher.API.Csharp.Client.Utils
{
    [Serializable]
    public class BlockCypherException : Exception
    {
        public int eCode { get; set; }
        public string eMsg { get; set; }

        public BlockCypherException()
        {

        }
        public BlockCypherException(string error)
            : base(string.Format("Api Error Code:{0}", error))
        {

        }
        public BlockCypherException(int eCode, string eMsg)
       : base(string.Format("Api Error Code: {0} Message: {1}", eCode, eMsg))
        {

        }

        public BlockCypherException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
