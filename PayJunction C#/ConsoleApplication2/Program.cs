using PayJunction;
using PayJunction.SmartTerminal;
using PayJunction.Transaction;
using PayJunction.Webhook;
using System;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        public static void TestWebhook()
        {
            //Need to perform error checking and Response.IsSuccessful for validations in actual code
            PayJunction.PayJunctionClient client = new PayJunction.PayJunctionClient("e3c70907-6c5e-44e6-beef-8a39aae97fab", "rk3groupapi", "password1", PayJunction.PaymentClientMode.Test);
            Request<PayJunction.Webhook.WebhookResponse> req = new PayJunction.Webhook.AddWebhookRequest("https://payjunk.requestcatcher.com/", "");
            PayJunction.Webhook.WebhookResponse resp = null;
            if (client.ExecuteRequest(req))
            {
                resp = req.ProcessResponse();
            }

            if (resp.IsSuccessful && resp.Errors.Count == 0)
            {
                //Printing response data
                Console.WriteLine(resp.Created);
                Console.WriteLine(resp.Events[0]);
                Console.WriteLine(resp.Url);
                Console.WriteLine(resp.WebhookID + "\n\n");

                req = new PayJunction.Webhook.UpdateWebhookRequest("https://newpayjunk.requestcatcher.com/", "", resp.WebhookID);
                //req = new PayJunction.Webhook.UpdateWebhookRequest("https://requestb.in/10muni81", "", "e0ccff07-0161-48a5-a039-0cb31937c566");
                if (client.ExecuteRequest(req))
                {
                    resp = req.ProcessResponse();
                }
            }

            if (resp.IsSuccessful && resp.Errors.Count == 0)
            {
                req = new PayJunction.Webhook.DeleteWebhookRequest(resp.WebhookID);
                if (client.ExecuteRequest(req))
                {
                    resp = req.ProcessResponse();
                }
            }
        }

        static void TestTransaction()
        {
            PayJunction.PayJunctionClient client = new PayJunction.PayJunctionClient("e3c70907-6c5e-44e6-beef-8a39aae97fab", "pj-ql-01", "pj-ql-01p", PayJunction.PaymentClientMode.Test);
            PayJunction.Transaction.NewTransactionRequest req = new PayJunction.Transaction.NewTransactionRequest("4444333322221111", "2020", "01", "45");
            req.RequestMode = NewTransactionRequest.Mode.Charge;
            req.InvoiceNumber = new Random().Next().ToString();
            if (client.ExecuteRequest(req))
            {
                TransactionResponse res = req.ProcessResponse();
                if(res.Errors.Count == 0 && res.Response.Approved)
                {
                    Console.WriteLine("Approved");
                }
            }
        }

        public static void TestSmartTerminal()
        {
            PayJunction.PayJunctionClient client = new PayJunction.PayJunctionClient("e3c70907-6c5e-44e6-beef-8a39aae97fab", "rk3groupapi", "password1", PayJunction.PaymentClientMode.Test);
            Request<SmartTerminalTransactionResponse> req = new PayJunction.SmartTerminal.SmartTerminalTransactionRequest("11485","3432", "b0636439-df4e-42cd-881c-94f41be8b9d9");
            if (client.ExecuteRequest(req))
            {
                SmartTerminalTransactionResponse resp = req.ProcessResponse();
                if (resp.Errors.Count == 0)
                {
                    Console.WriteLine(resp.RequestPaymentId);
                }
            }
        }

        static void Main(string[] args)
        {
            //TestTransaction();
            TestWebhook();
            //TestSmartTerminal();
            //PayJunction.PayJunctionClient client = new PayJunction.PayJunctionClient("e3c70907-6c5e-44e6-beef-8a39aae97fab", "rk3groupapi", "password1", PayJunction.PaymentClientMode.Test);
            //StreamReader reader = new StreamReader("JSON.txt");
            //string json = reader.ReadToEnd();
            //PayJunction.SmartTerminal.WebhookResponse webhookResponse = PayJunction.SmartTerminal.WebhookResponse.Parse(json,client);
            //var s = new System.Collections.Specialized.NameValueCollection();
            //s["X-Pj-Signature"] = "1151ee5fb4afb3c288b8db17eb49d5eab14c5d17465c2f39ee82c493ec698481";
            return;
        }
    }
}