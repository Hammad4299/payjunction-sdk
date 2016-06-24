using System.Collections.Generic;
using System.Net;

namespace PayJunction.Webhook
{
    class WebhookResponse : Response
    {
        public string WebhookID { get; set; }
        public List<string> Events { get; set; }
        public string Url { get; set; }
        public string Created { get; set; }
        public bool IsSuccessful { get; set; }

        public WebhookResponse() : this(HttpStatusCode.NoContent)
        {
        }

        public WebhookResponse(HttpStatusCode code)
        {
            IsSuccessful = (code == HttpStatusCode.NoContent);
        }
    }
}
