Namespace PayJunction.Transaction
    Class TransactionResponse
        Inherits Response
        Public Class ResponseData
            Public Property Message() As String
                Get
                    Return m_Message
                End Get
                Set
                    m_Message = Value
                End Set
            End Property
            Private m_Message As String
            Public Property Approved() As Boolean
                Get
                    Return m_IsApproved
                End Get
                Set
                    m_IsApproved = Value
                End Set
            End Property
            Private m_IsApproved As Boolean
            Public Property Code() As String
                Get
                    Return m_Code
                End Get
                Set
                    m_Code = Value
                End Set
            End Property
            Private m_Code As String
        End Class

        Public Property TransactionID() As Integer
            Get
                Return m_TransactionID
            End Get
            Set
                m_TransactionID = Value
            End Set
        End Property
        Private m_TransactionID As Integer
        Public Property TerminalID() As Integer
            Get
                Return m_TerminalID
            End Get
            Set
                m_TerminalID = Value
            End Set
        End Property
        Private m_TerminalID As Integer
        Public Property AmountBase() As String
            Get
                Return m_AmountBase
            End Get
            Set
                m_AmountBase = Value
            End Set
        End Property
        Private m_AmountBase As String
        Public Property AmountTax() As String
            Get
                Return m_AmountTax
            End Get
            Set
                m_AmountTax = Value
            End Set
        End Property
        Private m_AmountTax As String
        Public Property Action() As String
            Get
                Return m_Action
            End Get
            Set
                m_Action = Value
            End Set
        End Property
        Private m_Action As String
        Public Property AmountShipping() As String
            Get
                Return m_AmountShipping
            End Get
            Set
                m_AmountShipping = Value
            End Set
        End Property
        Private m_AmountShipping As String
        Public Property AmountTotal() As String
            Get
                Return m_AmountTotal
            End Get
            Set
                m_AmountTotal = Value
            End Set
        End Property
        Private m_AmountTotal As String
        Public Property Status() As String
            Get
                Return m_Status
            End Get
            Set
                m_Status = Value
            End Set
        End Property
        Private m_Status As String
        Public Property InvoiceNumber() As String
            Get
                Return m_InvoiceNumber
            End Get
            Set
                m_InvoiceNumber = Value
            End Set
        End Property
        Private m_InvoiceNumber As String
        Public Property Created() As String
            Get
                Return m_Created
            End Get
            Set
                m_Created = Value
            End Set
        End Property
        Private m_Created As String
        Public Property Modified() As String
            Get
                Return m_Modified
            End Get
            Set
                m_Modified = Value
            End Set
        End Property
        Private m_Modified As String
        Public Property Response() As ResponseData
            Get
                Return m_Response
            End Get
            Set
                m_Response = Value
            End Set
        End Property
        Private m_Response As ResponseData
    End Class
End Namespace