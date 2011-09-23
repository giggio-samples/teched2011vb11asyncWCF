Imports System.Net
Imports System.Threading.Tasks
Imports System.Collections.ObjectModel

Public Class QuoteCalculatorService
    Implements IQuoteCalculatorService

    Public Async Function GetQuoteAsync(ByVal ticker As String) As Task(Of Quote) Implements IQuoteCalculatorService.GetQuoteAsync
        Dim price As Double
        Dim change As Double

        Dim quoteValues As String() = (Await New WebClient().DownloadStringTaskAsync("http://download.finance.yahoo.com/d/quotes.csv?s=" & ticker & "&f=l1c1n")).Split(",")
        Double.TryParse(quoteValues(0), price)
        Double.TryParse(quoteValues(1), change)

        Await Task.Delay(2000)

        Return New Quote() With {.Ticker = ticker, .Price = price, .Change = change}
    End Function

    Public Async Function GetQuotesAsync(ByVal tickers As String()) As Task(Of ReadOnlyCollection(Of Quote)) Implements IQuoteCalculatorService.GetQuotesAsync
        Return New ReadOnlyCollection(Of Quote)(
            Await Task.WhenAll(From ticker In tickers Select GetQuoteAsync(ticker)))
    End Function

End Class
