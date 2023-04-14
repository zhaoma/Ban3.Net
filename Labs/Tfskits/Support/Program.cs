using System.Text.Json.Serialization;
using Ban3.Infrastructures.NetHttp;
using Ban3.Infrastructures.NetHttp.Entries;

var host = new Ban3.Infrastructures.NetHttp.Entries.TargetHost
{
    BaseUrl = "https://tfs-cr.healthcare.siemens.com:8090",
    AuthenticationType = "NTLM",
    UserName = "zhifeng.zhao.ext@siemens-healthineers.com",
    Password = "100Pi=314.15926!!!"
};

var url =
    $"{host.BaseUrl}/tfs/CT/_apis/tfvc/items/$/CTS/Development/ICS/SHA.SERV/CT.Serv/Tst/BE.Impl/XrayPath/XrayPathConfig.cs?versionType=Latest&versionOptions=None";

var resource=new TargetResource
{
    Url=url
};

/*

host.Send(resource).ContinueWith(task =>
{
    var result = task.Result.Content.ReadAsStringAsync().Result;
    Console.WriteLine(result);
});

Console.ReadKey();

*/

var result = host.Request(resource);
Console.WriteLine(result.Content.ReadAsStringAsync().Result);
