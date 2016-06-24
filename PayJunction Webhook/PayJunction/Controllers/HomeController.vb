Imports System.IO
Imports PayJunction.SmartTerminal

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Dim inputStream = Request.InputStream
        inputStream.Position = 0
        Dim body As String = Nothing
        Using reader = New StreamReader(inputStream)
            body = reader.ReadToEnd()
        End Using
        Dim f As StreamWriter

        Try
            Dim client As New PayJunction.PayJunctionClient("e3c70907-6c5e-44e6-beef-8a39aae97fab", "rk3groupapi", "password1", PayJunction.PaymentClientMode.Test)
            Dim resp As WebhookResponse = WebhookResponse.Parse(body, client)
            f = New StreamWriter("e:\" + resp.Data.RequestPaymentID)
            f.WriteLine(resp.TransResponse.Status.ToString())
            f.WriteLine(resp.Data.RequestPaymentID)
            f.WriteLine(resp.Data.SmartTerminalID)
            f.WriteLine(Request.Headers.ToString())
            f.WriteLine(resp.Validate("password1", body, Request.Headers).ToString())
            f.Close()
        Catch ex As Exception
            f.WriteLine(ex.Message)
        End Try
        Return View()

    End Function
End Class