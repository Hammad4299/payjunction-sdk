Imports RestSharp

Namespace PayJunction
    MustInherit Class Request(Of T As Response)
        Public Property Params() As Dictionary(Of [String], [String])
            Get
                Return m_Params
            End Get
            Set
                m_Params = Value
            End Set
        End Property
        Private m_Params As Dictionary(Of [String], [String])
        Public Property Headers() As Dictionary(Of [String], [String])
            Get
                Return m_Headers
            End Get
            Set
                m_Headers = Value
            End Set
        End Property
        Private m_Headers As Dictionary(Of [String], [String])

        Public MustOverride ReadOnly Property Method() As RestSharp.Method

        Public Property RawResponse() As String
            Get
                Return m_RawResponse
            End Get
            Set
                m_RawResponse = Value
            End Set
        End Property
        Private m_RawResponse As String

        Public Property Response() As IRestResponse
            Get
                Return m_Response
            End Get
            Set
                m_Response = Value
            End Set
        End Property
        Private m_Response As IRestResponse

        ''' <summary>
        ''' Can be used to check whether all required params and headers are entered by API Library user.
        ''' </summary>
        ''' <returns></returns>
        Public Function IsValid() As Boolean
            Return True
        End Function

        Public MustOverride Function ProcessResponse() As T

        Public Sub New()
            Params = New Dictionary(Of String, String)()
            Headers = New Dictionary(Of String, String)()
        End Sub

        Public MustOverride ReadOnly Property EndPoint() As String
    End Class
End Namespace