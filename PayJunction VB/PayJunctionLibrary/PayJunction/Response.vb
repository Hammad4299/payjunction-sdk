Namespace PayJunction
    MustInherit Class Response
        Public Property Errors() As List(Of ResponseError)
            Get
                Return m_Errors
            End Get
            Set
                m_Errors = Value
            End Set
        End Property
        Private m_Errors As List(Of ResponseError)

        Public Sub New()
            Errors = New List(Of ResponseError)()
        End Sub
    End Class
End Namespace