Imports System.Threading.Tasks
Imports ClientApp.WCFService

Module ClientApp

    Sub Main()
        Console.WriteLine("Wait for the stock prices to be printed out or hit ENTER to exit...")

        Dim tickers As String() = {"MSFT", "C", "YHOO", "GOOG", "GE", "FOO"}
        While True
            Dim watch = New Stopwatch
            watch.Start()
            Dim task = ComputeStockPricesAsync(tickers)
            task.Wait()
            watch.Stop()
            Console.WriteLine("All the stock prices have been obtained, press enter to obtain again, any other key to exit.")
            Console.WriteLine("Total time: " & Convert.ToDouble(watch.ElapsedMilliseconds) / 1000)
            If Console.ReadKey.Key <> ConsoleKey.Enter Then
                Exit While
            End If
        End While
    End Sub

    Async Function ComputeStockPricesAsync(ByVal tickers As String()) As Task
        Dim quotes = Await New QuoteCalculatorServiceClient().GetQuotesAsync(tickers)
        For Each quote In quotes
            Console.WriteLine("Ticker: " + quote.Ticker)
            Console.WriteLine(vbTab & "Price: " + If(Not quote.Price.Equals(0.0), quote.Price.ToString(), "Unknown"))
            Console.WriteLine(vbTab & "Change of the day: " + If(Not quote.Change.Equals(0.0), quote.Change.ToString(), "Unknown"))
            Console.WriteLine()
        Next
    End Function

End Module