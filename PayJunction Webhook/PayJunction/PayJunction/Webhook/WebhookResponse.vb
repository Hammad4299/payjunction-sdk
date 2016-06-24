Imports System.Net

Namespace PayJunction.Webhook
    Class WebhookResponse
        Inherits Response
        Public Property WebhookID() As String
            Get
                Return m_WebhookID
            End Get
            Set
                m_WebhookID = Value
            End Set
        End Property
        Private m_WebhookID As String
        Public Property Events() As List(Of String)
            Get
                Return m_Events
            End Get
            Set
                m_Events = Value
            End Set
        End Property
        Private m_Events As List(Of String)
        Public Property Url() As String
            Get
                Return m_Url
            End Get
            Set
                m_Url = Value
            End Set
        End Property
        Private m_Url As String
        Public Property Created() As String
            Get
                Return m_Created
            End Get
            Set
                m_Created = Value
            End Set
        End Property
        Private m_Created As String
        Public Property IsSuccessful() As Boolean
            Get
                Return m_IsSuccessful
            End Get
            Set
                m_IsSuccessful = Value
            End Set
        End Property
        Private m_IsSuccessful As Boolean

        Public Sub New()
            Me.New(HttpStatusCode.NoContent)
        End Sub

        Public Sub New(code As HttpStatusCode)
            IsSuccessful = (code = HttpStatusCode.NoContent)
        End Sub
    End Class
End Namespace
