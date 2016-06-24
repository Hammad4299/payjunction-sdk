using Newtonsoft.Json;
using PayJunction;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PayJunction
{
    class PayJunctionClient
    {
        private static Dictionary<PaymentClientMode, string> EndPointBaseUrl;

        protected string APIKey { get; set; }
        protected string UserID { get; set; }
        protected string Password { get; set; }
        protected PaymentClientMode Mode { get; set; }

        static PayJunctionClient()
        {
            EndPointBaseUrl = new Dictionary<PaymentClientMode, string>();
            EndPointBaseUrl.Add(PaymentClientMode.Test, "https://api.payjunctionlabs.com/");
            EndPointBaseUrl.Add(PaymentClientMode.Live, "https://api.payjunction.com/");
        }

        virtual protected string BaseEndpoint
        {
            get
            {
                return EndPointBaseUrl[Mode];
            }
        }

        public PayJunctionClient(string appKey,string apiUser,string apiPassword,PaymentClientMode mode)
        {
            this.APIKey = appKey;
            this.UserID = apiUser;
            this.Password = apiPassword;
            this.Mode = mode;
        }

        /// <summary>
        /// Executes request. Check request object after execution to see response.
        /// </summary>
        /// <param name="request">Request to process</param>
        public bool ExecuteRequest<T>(PayJunction.Request<T> request) where T : Response
        {
            if (request.IsValid())
            {
                RestSharp.RestClient client = new RestSharp.RestClient(BaseEndpoint);
                RestSharp.RestRequest req = new RestSharp.RestRequest(request.EndPoint, request.Method);
                req.AddHeader("X-PJ-Application-Key", APIKey);
                foreach (string s in request.Headers.Keys)
                {
                    if (!string.IsNullOrWhiteSpace(request.Headers[s]))
                        req.AddHeader(s, request.Headers[s]);
                }

                foreach (string s in request.Params.Keys)
                {
                    if (!string.IsNullOrWhiteSpace(request.Params[s]))
                        req.AddParameter(s, request.Params[s]);
                }

                client.Authenticator = new HttpBasicAuthenticator(UserID, Password);
                IRestResponse resp = client.Execute(req);
                Console.WriteLine("\n\nRaw Json Received\n");
                Console.WriteLine(resp.Content);
                Console.WriteLine("\n\n");
                request.RawResponse = resp.Content;
                request.Response = resp;
                
                return true;
            }

            return false;
        }
    }
}
