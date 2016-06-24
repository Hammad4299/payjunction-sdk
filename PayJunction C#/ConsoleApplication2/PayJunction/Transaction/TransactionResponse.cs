using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayJunction.Transaction
{
    class TransactionResponse: Response
    {   
        public class ResponseData
        {
            public string Message { get; set; }
            public bool Approved { get; set; }
            public string Code { get; set; }
        }
        
        public int TransactionID { get; set; }
        public int TerminalID { get; set; }
        public string AmountBase { get; set; }
        public string AmountTax { get; set; }
        public string Action { get; set; }
        public string AmountShipping { get; set; }
        public string AmountTotal { get; set; }
        public string Status { get; set; }
        public string InvoiceNumber { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }
        public ResponseData Response { get; set; }
    }
}