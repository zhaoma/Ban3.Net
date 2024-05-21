//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Implements.Alpha.Extensions;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Infrastructures.Contracts.Applications;
using Ban3.Infrastructures.Contracts.Entries;
using Ban3.Infrastructures.Contracts.Entries.CalendarServer;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums;
using Ban3.Infrastructures.Contracts.Materials.Calendars;
using System.Net.NetworkInformation;

namespace Ban3.Implements.Alpha.Support;

/// <summary>
/// 
/// </summary>
public class Program
{
    private static ICasinoServer _server;

    static void Main(string[] args)
    {
        ("args: -full:               execute base task.\n" +
        "      -one [code partern]: execute one task.\n" +
        "      -any:                collect all price with delay.\n" +
        "      -summary:            generate summary report.\n\n").WriteColorLine(ConsoleColor.DarkRed);

        Settings.Init();

        _server = Settings.Resolve<ICasinoServer>();

        if (args != null && args.Length > 0)
        {
            switch (args[0].ToLower())
            {
                case "-full":
                    _server.BaseTask();
                    var stocks = _server.LoadStocks();
                    _server.DailyTask(stocks);
                    _server.GenerateSummary(stocks);
                    break;

                case "-one":
                    if (args.Length > 1)
                    {
                        var stock = _server.LoadStocks().FindLast(o => o.Code.Contains(args[1]));
                        if (stock != null)
                        {
                            $"Parse {stock.Symbol}->{stock.Name}".WriteColorLine(ConsoleColor.DarkYellow);
                            _server.OnesTask(stock);
                        }
                    }
                    break;

                case "-any":
                    var all = _server.LoadStocks();
                    foreach (var stock in all)
                    {
                        $"Parse {stock.Symbol}->{stock.Name}".WriteColorLine(ConsoleColor.DarkYellow);
                        _server.OnesTask(stock);
                        (1, 2).RandomDelay();
                    }
                    _server.GenerateSummary(_server.LoadStocks());
                    break;

                case "-summary":
                    _server.GenerateSummary(_server.LoadStocks());
                    break;

                default:
                    //"Unsupported args input..".WriteColorLine(ConsoleColor.DarkYellow);

                    var summary = _server.LoadSummary().Latest();
                    Console.WriteLine(summary.Records.Count());
                    break;
            }
        }

        var r = new Calendar
        {
            Id="CalendarId",
            GroupId="GroupId",
            Color=Infrastructures.Contracts.Enums.CalendarServer.CalendarColor.LightBlue,
            HexColor="#003399",
            Etag="Etag",
            ChangeKey="ChangeKey"
        };

        Console.WriteLine(r.ObjToJson());
        Console.WriteLine();
        Console.WriteLine("GOOGLE-g");
     var g=   r as ICalendarOnGoogle;

        Console.WriteLine();
        Console.WriteLine(g.ObjToJson());
        Console.WriteLine();
        Console.WriteLine("MICROSOFT");
        Console.WriteLine();
        Console.WriteLine(((ICalendarOnMicrosoft)r).ObjToJson());

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        var a = new Attendee { 
            Type =Infrastructures.Contracts.Enums.CalendarServer.AttendeeType.Required,
            EmailAddress =new EmailAddress {
            Name="zhaoma@hotail.com"
            },
        Status=new ResponseStatus { 
        Time=DateTime.Now,
        Response=Infrastructures.Contracts.Enums.CalendarServer.ResponseType.Organizer
        }
        };
        Console.WriteLine(a.ObjToJson());

        Console.ReadKey();
    }
}