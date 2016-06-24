using PayJunction;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayJunction
{
    abstract class Request<T> where T : Response
    {
        public Dictionary<String,String> Params { get; set; }
        public Dictionary<String,String> Headers { get; set; }

        public abstract RestSharp.Method Method { get; }
        
        public IRestResponse Response { get; set; }
        public string RawResponse { get; set; }


        /// <summary>
        /// Can be used to check whether all required params and headers are entered by API Library user.
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return true;
        }

        public abstract T ProcessResponse();

        public Request()
        {
            Params = new Dictionary<string, string>();
            Headers = new Dictionary<string, string>();
        }

        abstract public string EndPoint { get; }
    }
}