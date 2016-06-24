using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace PayJunction.Transaction
{
    class NewTransactionRequest : Request<TransactionResponse>
    {
        public enum Mode
        {
            Charge,
            Refund
        }

        /// <summary>
        /// Defaults to Charge
        /// </summary>
        public Mode RequestMode
        {
            set
            {
                Params["action"] = value == Mode.Charge ? "CHARGE" : "REFUND";
            }
        }


        /// <summary>
        /// Endpoint. Don't include slash in beginning.
        /// </summary>
        public override string EndPoint
        {
            get
            {
                return "transactions";
            }
        }

        public string CreditCardNumber
        {
            set
            {
                Params["cardNumber"] = value;
            }get
            {
                return Params["cardNumber"];
            }
        }

        public string CardExpiryMonth
        {
            set
            {
                Params["cardExpMonth"] = value;
            }
            get
            {
                return Params["cardExpMonth"];
            }
        }

        public string CardExpiryYear
        {
            set
            {
                Params["cardExpYear"] = value;
            }
            get
            {
                return Params["cardExpYear"];
            }
        }

        /// <summary>
        /// ID of terminal to run transaction on.
        /// </summary>
        public string TerminalID
        {
            get
            {
                return Params["terminalId"];
            }
            set
            {
                Params["terminalId"] = value;
            }
        }

        /// <summary>
        /// Empty to turn off cvv check. Else CVV number
        /// </summary>
        public string CardCVV
        {
            set
            {
                Params["cvv"] = String.IsNullOrEmpty(value) ? "OFF" : "ON";
                Params["cardCvv"] = value;
            }
            get
            {
                return Params["cardCvv"];
            }
        }

        public string InvoiceNumber
        {
            get
            {
                return Params["invoiceNumber"];
            }
            set
            {
                Params["invoiceNumber"] = value;
            }
        }

        public string AmountBase
        {
            get
            {
                return Params["amountBase"];
            }
            set
            {
                Params["amountBase"] = value;
            }
        }

        public override Method Method
        {
            get
            {
                return Method.POST;
            }
        }

        public NewTransactionRequest(string cardNumber, string expYear, string expMonth,string amount)
        {
            this.CardExpiryMonth = expMonth;
            this.CardExpiryYear = expYear;
            this.CreditCardNumber = cardNumber;
            this.AmountBase = amount;
            this.CardCVV = "";
            this.RequestMode = Mode.Charge;
        }

        /// <summary>
        /// It creates new response everytime. Caller you reuse it instead of calling it multiple time
        /// </summary>
        /// <returns></returns>
        public override TransactionResponse ProcessResponse()
        {
            TransactionResponse res = JsonConvert.DeserializeObject<TransactionResponse>(RawResponse);
            return res;
        }
    }
}
