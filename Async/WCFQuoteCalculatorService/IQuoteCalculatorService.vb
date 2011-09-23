Imports System.Collections.ObjectModel
Imports System.Threading.Tasks

<ServiceContract()>
Public Interface IQuoteCalculatorService

    <OperationContract(AsyncPattern:=True)>
    Function GetQuoteAsync(ByVal ticker As String) As Task(Of Quote)

    <OperationContract(AsyncPattern:=True)>
    Function GetQuotesAsync(ByVal tickers As String()) As Task(Of ReadOnlyCollection(Of Quote))

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