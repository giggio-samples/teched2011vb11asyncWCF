Imports System.Net
Imports System.Collections.ObjectModel

Public Class QuoteCalculatorService
    Implements IQuoteCalculatorService

    Public Function GetQuote(ByVal ticker As String) As Quote Implements IQuoteCalculatorService.GetQuote
        Dim price As Double
        Dim change As Double

        Dim quoteValues As String() = New WebClient().DownloadString("http://download.finance.yahoo.com/d/quotes.csv?s=" & ticker & "&f=l1c1n").Split(",")
        Double.TryParse(quoteValues(0), price)
        Double.TryParse(quoteValues(1), change)

        System.Threading.Thread.Sleep(2000)

        Return New Quote() With {.Ticker = ticker, .Price = price, .Change = change}
    End Function

    Public Function GetQuotesAsync(ByVal tickers As String()) As ReadOnlyCollection(Of Quote) Implements IQuoteCalculatorService.GetQuotes
        Return New ReadOnlyCollection(Of Quote)((From ticker In tickers Select GetQuote(ticker)).ToList())
    End Function

End Class
