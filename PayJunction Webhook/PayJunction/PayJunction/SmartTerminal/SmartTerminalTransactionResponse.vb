Namespace PayJunction.SmartTerminal
    Class SmartTerminalTransactionResponse
        Inherits Response
        ''' <summary>
        ''' Store permanently to compare response status with webhook response.
        ''' </summary>
        Public Property RequestPaymentId() As String
            Get
                Return m_RequestPaymentId
            End Get
            Set
                m_RequestPaymentId = Value
            End Set
        End Property
        Private m_RequestPaymentId As String
    End Class
End Namespace