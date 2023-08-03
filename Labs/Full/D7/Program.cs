using System.Net.Mail;
using Ban3.Infrastructures.Common.Models;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Infrastructures.Common;
using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Extensions;
using Ban3.Infrastructures.NetMail;
using D7;
using Org.BouncyCastle.Asn1.Cms;

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

/*
 *
 *
x.Table().ObjToJson().WriteColorLine(ConsoleColor.DarkRed);

x.Fields().ObjToJson().WriteColorLine(ConsoleColor.DarkCyan);

x.DB().ObjToJson().WriteColorLine(ConsoleColor.DarkMagenta);

x.SqlForInsert().WriteColorLine(ConsoleColor.DarkRed);

x.SqlForUpdate().WriteColorLine(ConsoleColor.DarkBlue);


x.KeyValue().ToString().WriteColorLine(ConsoleColor.DarkYellow);

 *
 *
 */

var x=new Demo{Id=1,Identity = "ABC",Name="AQ"};

// direct c

x=x.Insert();

// insert in transaction

using var tran= x.DB()!.Transaction();

try
{
    x.Insert(tran);

    tran.Commit();
}
catch (Exception)
{
    tran.Rollback();
}