using Newtonsoft.Json;
using PayJunction.Transaction;
using System;
using System.Collections.Specialized;
using System.Security.Cryptography;

namespace PayJunction.SmartTerminal
{
    class WebhookResponse : Response
    {
        public string ID { get; set; }
        public string Created { get; set; }
        public string Type { get; set; }
        public bool IsValid { get; set; }

        public TransactionResponse TransResponse { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="secret">Secret for webhook used when adding it.</param>
        /// <returns></returns>
        public bool Validate(string secret, string requestBody, NameValueCollection headers)
        {
            return true;
            if (string.IsNullOrEmpty(secret) && headers["X-Pj-Signature"] == null)
            {
                IsValid = true;
            }
            else if (!string.IsNullOrEmpty(secret))
            {
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] keyByte = encoding.GetBytes(secret);
                HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);
                string hash = ByteToString(hmacsha256.ComputeHash(encoding.GetBytes(requestBody)));
                IsValid = hash == headers["X-Pj-Signature"];
            }

            return IsValid;
        }

        public static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("x2"); // hex format
            }
            return (sbinary);
        }

        public static WebhookResponse Parse(string requestBody,PayJunctionClient client)
        {
            WebhookResponse resp = JsonConvert.DeserializeObject<WebhookResponse>(requestBody);
            GetTransactionRequest req = new GetTransactionRequest(resp.Data.TransactionID);
            client.ExecuteRequest(req);
            resp.TransResponse = req.ProcessResponse();
            return resp;
        }

        public WebhookData Data { get; set; }
    }

    public class WebhookData
    {
        public string RequestPaymentID { get; set; }
        public string SmartTerminalID { get; set; }
        public string TransactionID { get; set; }
    }
}
