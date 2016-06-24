Imports RestSharp
Imports Newtonsoft.Json

Namespace PayJunction.Webhook
    Class AddWebhookRequest
        Inherits Request(Of WebhookResponse)
        Public Overrides ReadOnly Property EndPoint() As String
            Get
                Return "webhooks"
            End Get
        End Property

        Public Overrides ReadOnly Property Method() As Method
            Get
                Return Method.POST
            End Get
        End Property

        ''' <summary>
        ''' Must be HTTPS
        ''' </summary>
        Public Property Url() As String
            Get
                Return Params("url")
            End Get
            Set
                Params("url") = Value
            End Set
        End Property

        Public Property Secret() As String
            Get
                Return Params("secret")
            End Get
            Set
                'Params("secret") = Value
            End Set
        End Property

        Private Property [Event]() As String
            Get
                Return Params("event")
            End Get
            Set
                Params("event") = Value
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="url__1">Must be HTTPS</param>
        ''' <param name="secret__2">No support.Empty if don't want webhook response validation else need to store and provide it while parsing response which is received on webhook. Max length 255</param>
        Public Sub New(url__1 As String, secret__2 As String)
            Url = url__1
            Secret = secret__2
            [Event] = "SMARTTERMINAL_TRANSACTION"
        End Sub

        Public Overrides Function ProcessResponse() As WebhookResponse
            Dim res As WebhookResponse = JsonConvert.DeserializeObject(Of WebhookResponse)(RawResponse)
            Return res
        End Function
    End Class
End Namespace