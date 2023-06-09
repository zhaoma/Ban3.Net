using System.Diagnostics;
using Ban3.Infrastructures.Consoles;
using Ban3.Productions.Casino.CcaAndReport;

namespace Ban3.Labs.Casino.CcarAgent;

internal class Program
{
    static async Task Main(string[] args)
    {
        var controlCode = args.Any() ? args[0] .ToLower(): string.Empty;
        
        Sw.Start();
        switch (controlCode)
        {
            case "--prepare":
                await Signalert.ExecuteFullyJob();
                break;

            case "--daily":
                Signalert.ExecuteDailyJob();
                break;

            case "--realtime":
                Signalert.ExecuteRealtimeJob();
                break;

            default:
                $"args:  \r\n--prepare                 prepare all data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--daily :                      prepare ones daily data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--realtime :               refresh realtime".WriteColorLine(ConsoleColor.DarkYellow);

                break;
        }
        Sw.Stop();

        $"{Sw.ElapsedMilliseconds} ms spent @{controlCode}".WriteColorLine(ConsoleColor.DarkYellow);
    }

    private static readonly Stopwatch Sw= new ();
}