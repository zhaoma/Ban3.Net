//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Net;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CommunicationServer;

/// <summary>
/// 
/// </summary>
public class Address
{
    public static EndPoint _endPoint { get; set; }

    public string IP { get; set; }

    public int Port { get; set; }

     
}
