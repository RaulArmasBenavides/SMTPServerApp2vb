Imports System.Threading
Imports SmtpServer
Imports SmtpServer.Mail
Imports SmtpServer.Storage

Public Class SampleMailboxFilter
    Implements IMailboxFilter
    Implements IMailboxFilterFactory


    Private Function IMailboxFilter_CanAcceptFromAsync(context As ISessionContext, from As IMailbox, size As Integer, cancellationToken As CancellationToken) As Task(Of MailboxFilterResult) Implements IMailboxFilter.CanAcceptFromAsync
        If String.Equals(from.Host, "bw2.com") Then
            Console.WriteLine("El correo remitente es bw2.com ACEPTADO")
            Return Task.FromResult(MailboxFilterResult.Yes)
        End If

        Return Task.FromResult(MailboxFilterResult.NoPermanently)
    End Function

    Private Function IMailboxFilter_CanDeliverToAsync(context As ISessionContext, [to] As IMailbox, from As IMailbox, cancellationToken As CancellationToken) As Task(Of MailboxFilterResult) Implements IMailboxFilter.CanDeliverToAsync
        If String.Equals([to].Host, "bw2.com") Then
            Console.WriteLine("El correo destinatario es bw2.com ACEPTADO")
            Return Task.FromResult(MailboxFilterResult.Yes)
        End If

        Return Task.FromResult(MailboxFilterResult.Yes)
    End Function

    Private Function IMailboxFilterFactory_CreateInstance(context As ISessionContext) As IMailboxFilter Implements IMailboxFilterFactory.CreateInstance
        Console.WriteLine("CreateInstance Method")
        Return New SampleMailboxFilter()
    End Function
End Class