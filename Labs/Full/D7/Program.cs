using Ban3.Infrastructures.Common.Models;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Infrastructures.Common;

//Console.WriteLine($"SettingsStandby={Ban3.Infrastructures.Common.Config.SettingsStandby}");

var ints = Enumerable.Range(1, 1000).ToList();

//ints.ObjToJson().WriteColorLine(ConsoleColor.DarkGreen);
Console.WriteLine();

var tp = new TaskPool<int>(
    ints,
    20,
    (i) =>
    {
        $"{i}".WriteColorLine(ConsoleColor.DarkYellow);
        (2, 4).RandomDelay();
    });

tp.Execute();



