Namespace PayJunction
    Public Class ResponseError
        Public Property Message() As String
            Get
                Return m_Message
            End Get
            Set
                m_Message = Value
            End Set
        End Property
        Private m_Message As String

        Public Property Type() As String
            Get
                Return m_Type
            End Get
            Set
                m_Type = Value
            End Set
        End Property
        Private m_Type As String

        Public Property Parameter() As String
            Get
                Return m_Parameter
            End Get
            Set
                m_Parameter = Value
            End Set
        End Property
        Private m_Parameter As String
    End Class
End Namespace
