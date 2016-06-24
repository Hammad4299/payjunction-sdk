using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace PayJunction.Webhook
{
    class DeleteWebhookRequest : Request<WebhookResponse>
    {
        public override string EndPoint
        {
            get
            {
                return "webhooks/"+WebhookID;
            }
        }

        public override Method Method
        {
            get
            {
                return Method.DELETE;
            }
        }

        public string WebhookID { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="secret">Empty if don't want webhook response validation else need to store and provide it while parsing response which is received on webhook. Max length 255</param>
        public DeleteWebhookRequest(string webhookID)
        {
            WebhookID = webhookID;
        }

        public override WebhookResponse ProcessResponse()
        {
            WebhookResponse res = new WebhookResponse(Response.StatusCode);
            return res;
        }
    }
}
