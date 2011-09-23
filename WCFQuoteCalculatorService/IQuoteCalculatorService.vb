'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: IQuoteCalculatorService.cs
'
'--------------------------------------------------------------------------

Imports System.Collections.ObjectModel

<ServiceContract()>
Public Interface IQuoteCalculatorService

    '<OperationContract()>
    'Function GetQuote(ByVal ticker As String) As Quote

    <OperationContract(AsyncPattern:=True)>
    Function BeginGetQuote(ByVal ticker As String, ByVal callback As AsyncCallback, ByVal state As Object) As IAsyncResult
    Function EndGetQuote(ByVal result As IAsyncResult) As Quote

    '<OperationContract()>
    'Function GetQuotes(ByVal tickers As String()) As ReadOnlyCollection(Of Quote)

    <OperationContract(AsyncPattern:=True)>
    Function BeginGetQuotes(ByVal tickers As String(), ByVal callback As AsyncCallback, ByVal state As Object) As IAsyncResult
    Function EndGetQuotes(ByVal result As IAsyncResult) As ReadOnlyCollection(Of Quote)

End Interface

<DataContract()>
Public Class Quote

    <DataMember()>
    Public Property Ticker() As String

    <DataMember()>
    Public Property Price() As Double

    <DataMember()>
    Public Property Change() As Double

End Class