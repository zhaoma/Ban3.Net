//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Contracts.Applications;

namespace Ban3.Implements.Alpha.Support;

/// <summary>
/// 
/// </summary>
public class Program
{
    static void Main(string[] args)
    {
        Settings.Init();

        var now = DateTime.Now;

        var casino = Settings.Resolve<ICasinoServer>();

        casino.BaseTask();

        Console.WriteLine($"{DateTime.Now.Subtract(now).TotalSeconds.ToInt()} [BaseTask] seconds elapsed.");

        now = DateTime.Now;

        var stocks = casino.LoadStocks();

        casino.DailyTask(stocks);

        Console.WriteLine($"{DateTime.Now.Subtract(now).TotalSeconds.ToInt()} [DailyTask] seconds elapsed.");

        now = DateTime.Now;

        casino.GenerateSummary(stocks);

        Console.WriteLine($"{DateTime.Now.Subtract(now).TotalSeconds.ToInt()} [GenerateSummary] seconds elapsed.");

    }
}