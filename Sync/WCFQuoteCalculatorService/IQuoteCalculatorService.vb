Imports System.Collections.ObjectModel
Imports System.Threading.Tasks

<ServiceContract()>
Public Interface IQuoteCalculatorService

    <OperationContract>
    Function GetQuote(ByVal ticker As String) As Quote

    <OperationContract>
    Function GetQuotes(ByVal tickers As String()) As ReadOnlyCollection(Of Quote)

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