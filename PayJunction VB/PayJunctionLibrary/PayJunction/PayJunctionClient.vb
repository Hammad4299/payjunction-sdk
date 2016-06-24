Imports RestSharp
Imports RestSharp.Authenticators

Namespace PayJunction
    Class PayJunctionClient
        Private Shared EndPointBaseUrl As Dictionary(Of PaymentClientMode, String)

        Protected Property APIKey() As String
            Get
                Return m_APIKey
            End Get
            Set
                m_APIKey = Value
            End Set
        End Property
        Private m_APIKey As String
        Protected Property UserID() As String
            Get
                Return m_UserID
            End Get
            Set
                m_UserID = Value
            End Set
        End Property
        Private m_UserID As String
        Protected Property Password() As String
            Get
                Return m_Password
            End Get
            Set
                m_Password = Value
            End Set
        End Property
        Private m_Password As String
        Protected Property Mode() As PaymentClientMode
            Get
                Return m_Mode
            End Get
            Set
                m_Mode = Value
            End Set
        End Property
        Private m_Mode As PaymentClientMode

        Shared Sub New()
            EndPointBaseUrl = New Dictionary(Of PaymentClientMode, String)()
            EndPointBaseUrl.Add(PaymentClientMode.Test, "https://api.payjunctionlabs.com/")
            EndPointBaseUrl.Add(PaymentClientMode.Live, "https://api.payjunction.com/")
        End Sub

        Protected Overridable ReadOnly Property BaseEndpoint() As String
            Get
                Return EndPointBaseUrl(Mode)
            End Get
        End Property

        Public Sub New(appKey As String, apiUser As String, apiPassword As String, mode As PaymentClientMode)
            Me.APIKey = appKey
            Me.UserID = apiUser
            Me.Password = apiPassword
            Me.Mode = mode
        End Sub

        ''' <summary>
        ''' Executes request. Check request object after execution to see response.
        ''' </summary>
        ''' <param name="request">Request to process</param>
        Public Function ExecuteRequest(Of T As Response)(request As PayJunction.Request(Of T)) As Boolean
            If request.IsValid() Then
                Dim client As New RestSharp.RestClient(BaseEndpoint)
                Dim req As New RestSharp.RestRequest(request.EndPoint, request.Method)
                req.AddHeader("X-PJ-Application-Key", APIKey)
                For Each s As String In request.Headers.Keys
                    If Not String.IsNullOrWhiteSpace(request.Headers(s)) Then
                        req.AddHeader(s, request.Headers(s))
                    End If
                Next

                For Each s As String In request.Params.Keys
                    If Not String.IsNullOrWhiteSpace(request.Params(s)) Then
                        req.AddParameter(s, request.Params(s))
                    End If
                Next
                client.Authenticator = New HttpBasicAuthenticator(UserID, Password)
                Dim resp As IRestResponse = client.Execute(req)
                Console.WriteLine(vbLf & vbLf & "Raw Json Received" & vbLf)
                Console.WriteLine(resp.Content)
                Console.WriteLine(vbLf & vbLf)
                request.RawResponse = resp.Content
                request.Response = resp
                Return True
            End If

            Return False
        End Function
    End Class
End Namespace
