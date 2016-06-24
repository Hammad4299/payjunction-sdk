Imports PayJunction
Imports PayJunction.SmartTerminal
Imports PayJunction.Transaction

Module Module1
    Class Program
        Public Shared Sub TestWebhook()
            'Need to perform error checking and Response.IsSuccessful for validations in actual code
            Dim client As New PayJunction.PayJunctionClient("e3c70907-6c5e-44e6-beef-8a39aae97fab", "rk3groupapi", "password1", PayJunction.PaymentClientMode.Test)
            Dim req As Request(Of PayJunction.Webhook.WebhookResponse) = New PayJunction.Webhook.AddWebhookRequest("https://payjunk.requestcatcher.com/", "")
            Dim resp As PayJunction.Webhook.WebhookResponse = Nothing
            If client.ExecuteRequest(req) Then
                resp = req.ProcessResponse()
            End If

            If resp.IsSuccessful AndAlso resp.Errors.Count = 0 Then
                'Printing response data
                Console.WriteLine(resp.Created)
                Console.WriteLine(resp.Events(0))
                Console.WriteLine(resp.Url)
                Console.WriteLine(resp.WebhookID + vbLf & vbLf)

                req = New PayJunction.Webhook.UpdateWebhookRequest("https://newpayjunk.requestcatcher.com/", "", resp.WebhookID)
                'req = new PayJunction.Webhook.UpdateWebhookRequest("https://requestb.in/10muni81", "", "e0ccff07-0161-48a5-a039-0cb31937c566");
                If client.ExecuteRequest(req) Then
                    resp = req.ProcessResponse()
                End If
            End If

            If resp.IsSuccessful AndAlso resp.Errors.Count = 0 Then
                req = New PayJunction.Webhook.DeleteWebhookRequest(resp.WebhookID)

                If client.ExecuteRequest(req) Then
                    resp = req.ProcessResponse()
                End If
            End If
        End Sub

        Public Shared Sub TestTransaction()
            Dim client As New PayJunction.PayJunctionClient("e3c70907-6c5e-44e6-beef-8a39aae97fab", "pj-ql-01", "pj-ql-01p", PayJunction.PaymentClientMode.Test)
            Dim req As New PayJunction.Transaction.NewTransactionRequest("4444333322221111", "2020", "01", "45")
            req.RequestMode = NewTransactionRequest.Mode.Charge
            req.InvoiceNumber = New Random().[Next]().ToString()
            If client.ExecuteRequest(req) Then
                Dim res As TransactionResponse = req.ProcessResponse()
                If res.Errors.Count = 0 AndAlso res.Response.Approved Then
                    Console.WriteLine("Approved")
                End If
            End If
        End Sub

        Public Shared Sub TestSmartTerminal()
            Dim client As New PayJunction.PayJunctionClient("e3c70907-6c5e-44e6-beef-8a39aae97fab", "rk3groupapi", "password1", PayJunction.PaymentClientMode.Test)
            Dim req As Request(Of SmartTerminalTransactionResponse) = New PayJunction.SmartTerminal.SmartTerminalTransactionRequest("11485", "343", "b0636439-df4e-42cd-881c-94f41be8b9d9")
            If client.ExecuteRequest(req) Then
                Dim resp As SmartTerminalTransactionResponse = req.ProcessResponse()
                If resp.Errors.Count = 0 Then
                    Console.WriteLine(resp.RequestPaymentId)
                End If
            End If
        End Sub
    End Class

    Public Sub Main(args As String())
        Program.TestTransaction()
        Program.TestWebhook()
        Program.TestSmartTerminal()
        Return
    End Sub
End Module

