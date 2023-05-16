Module Module1

    Sub Main()
        Dim t10 = Fibonacci(10)

        Console.WriteLine($"#.10={t10}")

        Console.ReadKey()
    End Sub

    Function Fibonacci(ByVal n As Integer) As Integer
        If (n <= 1) Then
            Return n
        End If

        Return Fibonacci(n - 1) + Fibonacci(n - 2)

    End Function

End Module
