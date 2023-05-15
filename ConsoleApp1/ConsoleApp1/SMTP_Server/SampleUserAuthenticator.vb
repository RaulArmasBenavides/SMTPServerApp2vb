Imports System.Threading
Imports SmtpServer
Imports SmtpServer.Authentication

Public Class SampleUserAuthenticator
    Implements IUserAuthenticator
    Implements IUserAuthenticatorFactory

    Public Function CreateInstance(context As ISessionContext) As IUserAuthenticator Implements IUserAuthenticatorFactory.CreateInstance
        Return Nothing
    End Function

    Private Function IUserAuthenticator_AuthenticateAsync(context As ISessionContext, user As String, password As String, cancellationToken As CancellationToken) As Task(Of Boolean) Implements IUserAuthenticator.AuthenticateAsync
        Return Nothing
    End Function
End Class