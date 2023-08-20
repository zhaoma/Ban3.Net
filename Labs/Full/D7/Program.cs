using System.Configuration.Internal;
using System.Diagnostics;
using System.Net.Mail;
using System.Reflection;
using Ban3.Infrastructures.Common.Models;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Infrastructures.Common;
using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Extensions;
using Ban3.Infrastructures.NetMail;
using Ban3.Infrastructures.PlatformInvoke;
using Ban3.Infrastructures.PlatformInvoke.Entries;

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
/*

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
