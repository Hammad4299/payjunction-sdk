using PayJunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net.Http;
using Newtonsoft.Json;

namespace PayJunction.Transaction
{
    class GetTransactionRequest : Request<TransactionResponse>
    {
        public override string EndPoint
        {
            get
            {
                return "transactions/"+TransactionID;
            }
        }

        public override Method Method
        {
            get
            {
                return Method.GET;
            }
        }

        public override TransactionResponse ProcessResponse()
        {
            TransactionResponse resp = JsonConvert.DeserializeObject<TransactionResponse>(RawResponse);
            return resp;
        }

        public string TransactionID
        {
            get;set;
        }

        public GetTransactionRequest(string id)
        {
            this.TransactionID = id;
        }
    }
}
