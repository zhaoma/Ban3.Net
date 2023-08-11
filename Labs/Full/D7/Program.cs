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

