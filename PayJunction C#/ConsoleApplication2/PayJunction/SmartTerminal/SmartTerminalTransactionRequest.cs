using RestSharp;
using Newtonsoft.Json;

namespace PayJunction.SmartTerminal
{
    class SmartTerminalTransactionRequest : Request<SmartTerminal.SmartTerminalTransactionResponse>
    {
        public override string EndPoint
        {
            get
            {
                return "smartterminals/" + SmartTerminalID + "/request-payment";
            }
        }

        public string SmartTerminalID { get; set; }

        public override Method Method
        {
            get
            {
                return Method.POST;
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

        public SmartTerminalTransactionRequest(string terminalID, string amountBase, string smartTerminalID)
        {
            this.TerminalID = terminalID;
            this.AmountBase = amountBase;
            this.SmartTerminalID = smartTerminalID;
        }

        public override SmartTerminalTransactionResponse ProcessResponse()
        {
            SmartTerminalTransactionResponse resp = JsonConvert.DeserializeObject<SmartTerminalTransactionResponse>(RawResponse);
            return resp;
        }
    }
}
