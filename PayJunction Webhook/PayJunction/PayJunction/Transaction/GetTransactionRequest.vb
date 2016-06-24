Imports RestSharp
Imports Newtonsoft.Json

Namespace PayJunction.Transaction
    Class GetTransactionRequest
        Inherits Request(Of TransactionResponse)
        Public Overrides ReadOnly Property EndPoint() As String
            Get
                Return Convert.ToString("transactions/") & TransactionID
            End Get
        End Property

        Public Overrides ReadOnly Property Method() As Method
            Get
                Return Method.[GET]
            End Get
        End Property

        Public Overrides Function ProcessResponse() As TransactionResponse
            Dim resp As TransactionResponse = JsonConvert.DeserializeObject(Of TransactionResponse)(RawResponse)
            Return resp
        End Function

        Public Property TransactionID() As String
            Get
                Return m_TransactionID
            End Get
            Set
                m_TransactionID = Value
            End Set
        End Property
        Private m_TransactionID As String

        Public Sub New(id As String)
            Me.TransactionID = id
        End Sub
    End Class
End Namespace
