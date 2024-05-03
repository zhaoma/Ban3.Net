﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Applications;

namespace Ban3.Implements.Alpha.Support;

/// <summary>
/// 
/// </summary>
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("HELLO");

        Settings.Init();

        var casino=Settings.Resolve<ICasinoServer>();

        var stocks=casino.LoadStocks();

        var now = DateTime.Now;
        casino.DailyTask(stocks);

        Console.WriteLine($"{DateTime.Now.Subtract(now).TotalMinutes} minutes elapsed.");
    }
}