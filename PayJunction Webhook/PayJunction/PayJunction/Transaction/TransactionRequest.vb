Imports Newtonsoft
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports RestSharp

Namespace PayJunction.Transaction
    Class NewTransactionRequest
        Inherits Request(Of TransactionResponse)
        Public Enum Mode
            Charge
            Refund
        End Enum

        ''' <summary>
        ''' Defaults to Charge
        ''' </summary>
        Public WriteOnly Property RequestMode() As Mode
            Set
                Params("action") = If(Value = Mode.Charge, "CHARGE", "REFUND")
            End Set
        End Property


        ''' <summary>
        ''' Endpoint. Don't include slash in beginning.
        ''' </summary>
        Public Overrides ReadOnly Property EndPoint() As String
            Get
                Return "transactions"
            End Get
        End Property

        Public Property CreditCardNumber() As String
            Get
                Return Params("cardNumber")
            End Get
            Set
                Params("cardNumber") = Value
            End Set
        End Property

        Public Property CardExpiryMonth() As String
            Get
                Return Params("cardExpMonth")
            End Get
            Set
                Params("cardExpMonth") = Value
            End Set
        End Property

        Public Property CardExpiryYear() As String
            Get
                Return Params("cardExpYear")
            End Get
            Set
                Params("cardExpYear") = Value
            End Set
        End Property

        ''' <summary>
        ''' ID of terminal to run transaction on.
        ''' </summary>
        Public Property TerminalID() As String
            Get
                Return Params("terminalId")
            End Get
            Set
                Params("terminalId") = Value
            End Set
        End Property

        ''' <summary>
        ''' Empty to turn off cvv check. Else CVV number
        ''' </summary>
        Public Property CardCVV() As String
            Get
                Return Params("cardCvv")
            End Get
            Set
                Params("cvv") = If([String].IsNullOrEmpty(Value), "OFF", "ON")
                Params("cardCvv") = Value
            End Set
        End Property

        Public Property InvoiceNumber() As String
            Get
                Return Params("invoiceNumber")
            End Get
            Set
                Params("invoiceNumber") = Value
            End Set
        End Property

        Public Property AmountBase() As String
            Get
                Return Params("amountBase")
            End Get
            Set
                Params("amountBase") = Value
            End Set
        End Property

        Public Overrides ReadOnly Property Method() As Method
            Get
                Return Method.POST
            End Get
        End Property

        Public Sub New(cardNumber As String, expYear As String, expMonth As String, amount As String)
            Me.CardExpiryMonth = expMonth
            Me.CardExpiryYear = expYear
            Me.CreditCardNumber = cardNumber
            Me.AmountBase = amount
            Me.CardCVV = ""
            Me.RequestMode = Mode.Charge
        End Sub

        ''' <summary>
        ''' It creates new response everytime. Caller you reuse it instead of calling it multiple time
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function ProcessResponse() As TransactionResponse
            Dim res = JsonConvert.DeserializeObject(Of TransactionResponse)(RawResponse)
            Return res
        End Function
    End Class
End Namespace