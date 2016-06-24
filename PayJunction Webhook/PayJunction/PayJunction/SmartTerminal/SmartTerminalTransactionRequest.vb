Imports RestSharp
Imports Newtonsoft.Json

Namespace PayJunction.SmartTerminal
    Class SmartTerminalTransactionRequest
        Inherits Request(Of SmartTerminalTransactionResponse)
        Public Overrides ReadOnly Property EndPoint() As String
            Get
                Return (Convert.ToString("smartterminals/") & SmartTerminalID) + "/request-payment"
            End Get
        End Property

        Public Property SmartTerminalID() As String
            Get
                Return m_SmartTerminalID
            End Get
            Set
                m_SmartTerminalID = Value
            End Set
        End Property
        Private m_SmartTerminalID As String

        Public Overrides ReadOnly Property Method() As Method
            Get
                Return Method.POST
            End Get
        End Property

        Public Property AmountBase() As String
            Get
                Return Params("amountBase")
            End Get
            Set
                Params("amountBase") = Value
            End Set
        End Property

        Public Property TerminalID() As String
            Get
                Return Params("terminalId")
            End Get
            Set
                Params("terminalId") = Value
            End Set
        End Property

        Public Sub New(terminalID As String, amountBase As String, smartTerminalID As String)
            Me.TerminalID = terminalID
            Me.AmountBase = amountBase
            Me.SmartTerminalID = smartTerminalID
        End Sub

        Public Overrides Function ProcessResponse() As SmartTerminalTransactionResponse
            Dim resp As SmartTerminalTransactionResponse = JsonConvert.DeserializeObject(Of SmartTerminalTransactionResponse)(RawResponse)
            Return resp
        End Function
    End Class
End Namespace