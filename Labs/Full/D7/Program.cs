using System.Net.Mail;
using Ban3.Infrastructures.Common.Models;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Infrastructures.Common;
using Ban3.Infrastructures.NetMail;

//Console.WriteLine($"SettingsStandby={Ban3.Infrastructures.Common.Config.SettingsStandby}");

//var ints = Enumerable.Range(1, 1000).ToList();

////ints.ObjToJson().WriteColorLine(ConsoleColor.DarkGreen);
//Console.WriteLine();

//var tp = new TaskPool<int>(
//    ints,
//    20,
//    (i) =>
//    {
//        $"{i}".WriteColorLine(ConsoleColor.DarkYellow);
//        (2, 4).RandomDelay();
//    });

//tp.Execute();



var server=new Ban3.Infrastructures.NetMail.Entries.TargetServer
{
    EnableSsl=true,
    Password = "10000Pi=31415.926",
    ServerEndpoint = "smtp.office365.com",
    ServerPort = 587,
    UserName = "zhaoma@hotmail.com"
};

var r=server.Send(
    new List<string>{"zhaoma@hotmail.com","zhifeng.zhao.ext@siemens-healthineers.com" },
    new List<string> { "13585512315@139.com" },
        "send from 139",
    "It's from 139.com mailserver"
);

Console.WriteLine(r);