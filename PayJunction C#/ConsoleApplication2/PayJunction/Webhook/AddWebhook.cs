﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace PayJunction.Webhook
{
    class AddWebhookRequest : Request<WebhookResponse>
    {
        public override string EndPoint
        {
            get
            {
                return "webhooks";
            }
        }

        public override Method Method
        {
            get
            {
                return Method.POST;
            }
        }

        /// <summary>
        /// Must be HTTPS
        /// </summary>
        public string Url
        {
            get
            {
                return Params["url"];
            }
            set
            {
                Params["url"] = value;
            }
        }

        public string Secret
        {
            get
            {
                return Params["secret"];
            }
            set
            {
                Params["secret"] = value;
            }
        }

        private string Event
        {
            get
            {
                return Params["event"];
            }
            set
            {
                Params["event"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">Must be HTTPS</param>
        /// <param name="secret">Empty if don't want webhook response validation else need to store and provide it while parsing response which is received on webhook. Max length 255</param>
        public AddWebhookRequest(string url,string secret)
        {
            Url = url;
            Secret = secret;
            Event = "SMARTTERMINAL_TRANSACTION";
        }

        public override WebhookResponse ProcessResponse()
        {
            WebhookResponse res = JsonConvert.DeserializeObject<WebhookResponse>(RawResponse);
            return res;
        }
    }
}
