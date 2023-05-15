Imports System.IO
Imports System.Threading
Imports SmtpServer
Imports SmtpServer.Protocol
Imports SmtpServer.Storage

Public Class SampleMessageStore
    Inherits MessageStore
    Public Overrides Function SaveAsync(ByVal context As ISessionContext, ByVal transaction As IMessageTransaction, ByVal cancellationToken As CancellationToken) As Task(Of SmtpResponse)
        Dim _saveFolderPath As String = "C:\LOGS"
        Dim fileName = $"{Guid.NewGuid()}.txt"

        Using writer = New StreamWriter(Path.Combine(_saveFolderPath, fileName))
            writer.Write(transaction.Message)
        End Using

        Console.WriteLine("Saving mail message")
        Return Task(Of SmtpResponse).FromResult(SmtpResponse.Ok)
    End Function
End Class
