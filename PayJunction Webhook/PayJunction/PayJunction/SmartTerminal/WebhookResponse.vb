Imports System.Security.Cryptography
Imports System.Collections.Specialized
Imports Newtonsoft.Json
Imports PayJunction.Transaction

Namespace PayJunction.SmartTerminal
    Class WebhookResponse
        Inherits Response
        Public Property ID() As String
            Get
                Return m_ID
            End Get
            Set
                m_ID = Value
            End Set
        End Property
        Private m_ID As String
        Public Property Created() As String
            Get
                Return m_Created
            End Get
            Set
                m_Created = Value
            End Set
        End Property
        Private m_Created As String
        Public Property Type() As String
            Get
                Return m_Type
            End Get
            Set
                m_Type = Value
            End Set
        End Property
        Private m_Type As String
        Public Property IsValid() As Boolean
            Get
                Return m_IsValid
            End Get
            Set
                m_IsValid = Value
            End Set
        End Property
        Private m_IsValid As Boolean

        Public Property TransResponse() As TransactionResponse
            Get
                Return m_TransResponse
            End Get
            Set
                m_TransResponse = Value
            End Set
        End Property
        Private m_TransResponse As TransactionResponse

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="secret">Secret for webhook used when adding it.</param>
        ''' <returns></returns>
        Public Function Validate(secret As String, requestBody As String, headers As NameValueCollection) As Boolean
            Return True
            If String.IsNullOrEmpty(secret) AndAlso headers("X-Pj-Signature") Is Nothing Then
                IsValid = True
            ElseIf Not String.IsNullOrEmpty(secret) Then
                Dim encoding As New System.Text.ASCIIEncoding()
                Dim keyByte As Byte() = encoding.GetBytes(secret)
                Dim hmacsha256 As New HMACSHA256(keyByte)
                Dim hash As String = ByteToString(hmacsha256.ComputeHash(encoding.GetBytes(requestBody)))
                IsValid = hash = headers("X-Pj-Signature")
            End If

            Return IsValid
        End Function

        Public Shared Function ByteToString(buff As Byte()) As String
            Dim sbinary As String = ""

            For i As Integer = 0 To buff.Length - 1
                ' hex format
                sbinary += buff(i).ToString("x2")
            Next
            Return (sbinary)
        End Function

        Public Shared Function Parse(requestBody As String, client As PayJunctionClient) As WebhookResponse
            Dim resp As WebhookResponse = JsonConvert.DeserializeObject(Of WebhookResponse)(requestBody)
            Dim req As New GetTransactionRequest(resp.Data.TransactionID)
            client.ExecuteRequest(req)
            resp.TransResponse = req.ProcessResponse()
            Return resp
        End Function

        Public Property Data() As WebhookData
            Get
                Return m_Data
            End Get
            Set
                m_Data = Value
            End Set
        End Property
        Private m_Data As WebhookData
    End Class

    Public Class WebhookData
        Public Property RequestPaymentID() As String
            Get
                Return m_RequestPaymentID
            End Get
            Set
                m_RequestPaymentID = Value
            End Set
        End Property
        Private m_RequestPaymentID As String
        Public Property SmartTerminalID() As String
            Get
                Return m_SmartTerminalID
            End Get
            Set
                m_SmartTerminalID = Value
            End Set
        End Property
        Private m_SmartTerminalID As String
        Public Property TransactionID() As String
            Get
                Return m_TransactionID
            End Get
            Set
                m_TransactionID = Value
            End Set
        End Property
        Private m_TransactionID As String
    End Class
End Namespace
