using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Interfaces;

namespace Ban3.Labs.TeamFoundationCollector.Presentation.Support;

public class Daily:ITraceIt
{
    public int Fibonacci(int n)
    {
        Printxx("n**10");

        Thread.Sleep(500);
        return n * 10;
    }
    
    public static string A()
    {
        Thread.Sleep(1000);
        return "WaLLLi";
    }

    private void Printxx(string s)
    {
        Console.WriteLine(s);

        Thread.Sleep(200);
        File.Delete(Path.Combine(Environment.CurrentDirectory,"xxxxx.json"));
    }
}