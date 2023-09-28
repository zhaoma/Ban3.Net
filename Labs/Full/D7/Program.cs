using System.Configuration.Internal;
using System.Diagnostics;
using System.Net.Mail;
using System.Reflection;
using Ban3.Infrastructures.Common.Models;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Common;
using Ban3.Infrastructures.Consoles;

var s = 98.9D.IsLimit(90, 10);
Console.WriteLine(s);


//var a=Ban3.Sites.ViaSohu.Helper.DownloadAllNotions();

//a.ObjToJson().WriteColorLine(ConsoleColor.Red);

//for (var i = 1; i < 100; i++)
//{
//    $"{i}:{new Random().NextDateTime(DateTime.Now, DateTime.Now.AddYears(3))}".WriteColorLine(ConsoleColor.Red);
//}

//Console.WriteLine("301178".StockGroup());

//"301178".StockGroup().EnumDescription().WriteColorLine(ConsoleColor.Blue);

/*

Console.WriteLine(nameof(Ban3.Infrastructures.Common.Enums.Sort.Ascending));
Console.WriteLine(Ban3.Infrastructures.Common.Enums.Sort.Ascending.EnumDescription());
var ks =
    "AMOUNT.UP.DAILY;BIAS.LT.DAILY;DMI.MDI.DAILY;KD.MDI.DAILY;MACD.MDI.DAILY;MACD.N.DAILY;AMOUNT.UP.WEEKLY;BIAS.LT.WEEKLY;DMI.MDI.WEEKLY;DMI.DC.WEEKLY;KD.MDI.WEEKLY;KD.DC.WEEKLY;MACD.PDI.WEEKLY;MACD.N.WEEKLY;AMOUNT.UP.MONTHLY;BIAS.GE.MONTHLY;DMI.PDI.MONTHLY;ENE.LOWER.MONTHLY;KD.MDI.MONTHLY;MACD.MDI.MONTHLY;MACD.N.MONTHLY"
        .Split(';').ToList();

var dic = ks.SetsKeysSummary();

dic.ObjToJson().WriteColorLine(ConsoleColor.Red);


var plainText = "admin888";

var key = System.Text.Encoding.UTF8.GetBytes("pswdKEY23##@@1977");

var a1=Ban3.Infrastructures.Common.Enums.HashType.SHA1.GetHashedString(System.Text.Encoding.UTF8.GetBytes(plainText),key);

$"a1[SHA1]={a1}.{a1.Length}".WriteColorLine(ConsoleColor.Red);

var a2 = Ban3.Infrastructures.Common.Enums.HashType.SHA256.GetHashedString(System.Text.Encoding.UTF8.GetBytes(plainText), key);

$"a2[SHA256]={a2}.{a2.Length}".WriteColorLine(ConsoleColor.Red);

var a3 = Ban3.Infrastructures.Common.Enums.HashType.SHA384.GetHashedString(System.Text.Encoding.UTF8.GetBytes(plainText), key);

$"a3[SHA384]={a3}.{a3.Length}".WriteColorLine(ConsoleColor.Red);

var a4 = Ban3.Infrastructures.Common.Enums.HashType.SHA512.GetHashedString(System.Text.Encoding.UTF8.GetBytes(plainText), key);

$"a4[SHA512]={a4}.{a4.Length}".WriteColorLine(ConsoleColor.Red);

var b = plainText.MD5String();
$"b[MD5]={b}.{b.Length}".WriteColorLine(ConsoleColor.Blue);

var c= Ban3.Infrastructures.Common.Enums.HashType.MD5.GetHashedString(System.Text.Encoding.UTF8.GetBytes(plainText), key);

$"c[HASHMD5]={c}.{c.Length}".WriteColorLine(ConsoleColor.Red);

var d = Ban3.Infrastructures.Common.Enums.HashType.MD5.GetHashedString(System.Text.Encoding.UTF8.GetBytes(plainText), null);

$"d[HASHMD9]={d}.{d.Length}".WriteColorLine(ConsoleColor.Red);

var e = Ban3.Infrastructures.Common.Enums.HashType.MD5.GetHashedString(System.Text.Encoding.UTF32.GetBytes( plainText),null);

$"e[HASHMD7]={e}.{e.Length}".WriteColorLine(ConsoleColor.Red);


Console.ReadKey();
AppDomain.CurrentDomain.AssemblyResolve += delegate(object sender, ResolveEventArgs e)
{
    $"request {e.Name}".WriteColorLine(ConsoleColor.Red);
    return Assembly.LoadFile($"{Config.GetValue("Assemblies:RootFolder")}\\{e.Name.Split(',').First().AssemblyName()}");
};

var af = new AssemblyFile
{
    FullPath = "D:\\CTS\\Development\\ICS\\SHA.SERV\\bin\\Debug\\CT.Serv.Tst.BE.Algorithms.Impl.dll"
};

var r = af.Analyze(out var cs);

cs.ObjToJson().WriteColorLine(ConsoleColor.DarkYellow);

*/
