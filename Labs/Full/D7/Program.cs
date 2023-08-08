using System.Configuration.Internal;
using System.Diagnostics;
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

var x = new Demo
{
    Id = 1,
    Subject = "THIS IS SUBJECT",
    Note = "I'm Note.",
    UpdateTime = DateTime.Now,
    CreateTime = DateTime.Now
};


var sw = new Stopwatch();
sw.Start();

var xxx = new Demo2();
xxx.EntityStrategy().ObjToJson().WriteColorLine(ConsoleColor.DarkCyan);


var xx = Enumerable.Range(1, 20)
    .Select(o => new Demo
    {
        Subject = $"{o}:sub",
        Note = "NNOO",
        UpdateTime = DateTime.Now,
        CreateTime = DateTime.Now
    })
    .ToList();

//var r=xx.Insert(out var yy,false);
//$"{r}:".WriteColorLine(ConsoleColor.Red);

var a = await x.CreateAsync();
(a.Id + "").WriteColorLine(ConsoleColor.Red);

var r = new Demo { Id = 124156 }.Delete();
Console.WriteLine(r + "affected");

var r2 = new Demo().Delete("Id<=10000");
Console.WriteLine(r2 + "affected");

var r158 = new Demo { Id = 124158 }.Retrieve();
r158.ObjToJson().WriteColorLine(ConsoleColor.DarkBlue);
if (r158 != null)
{
    r158.Subject = "NEW SUBJETC HERE";
    r158.UpdateTime = DateTime.Now;
    Console.WriteLine($"{r158.Update()} affected.");
}


//new Action(() =>
//{
//    x = x.Insert();

//    x.ObjToJson().WriteColorLine(ConsoleColor.DarkRed);

//}).Times(30000);

sw.Stop();
$"{sw.Elapsed.Seconds} s elapsed.".WriteColorLine(ConsoleColor.DarkBlue);
