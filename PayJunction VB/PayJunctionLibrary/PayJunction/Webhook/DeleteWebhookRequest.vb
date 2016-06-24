Imports RestSharp

Namespace PayJunction.Webhook
    Class DeleteWebhookRequest
        Inherits Request(Of WebhookResponse)
        Public Overrides ReadOnly Property EndPoint() As String
            Get
                Return Convert.ToString("webhooks/") & WebhookID
            End Get
        End Property

        Public Overrides ReadOnly Property Method() As Method
            Get
                Return Method.DELETE
            End Get
        End Property

        Public Property WebhookID() As String
            Get
                Return m_WebhookID
            End Get
            Private Set
                m_WebhookID = Value
            End Set
        End Property
        Private m_WebhookID As String

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="url"></param>
        ''' <param name="secret">Empty if don't want webhook response validation else need to store and provide it while parsing response which is received on webhook. Max length 255</param>
        Public Sub New(webhookID__1 As String)
            WebhookID = webhookID__1
        End Sub

        Public Overrides Function ProcessResponse() As WebhookResponse
            Dim res As New WebhookResponse(Response.StatusCode)
            Return res
        End Function
    End Class
End Namespace
