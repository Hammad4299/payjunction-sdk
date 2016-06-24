namespace PayJunction.SmartTerminal
{
    class SmartTerminalTransactionResponse : Response
    {
        /// <summary>
        /// Store permanently to compare response status with webhook response.
        /// </summary>
        public string RequestPaymentId { get; set; }
    }
}
