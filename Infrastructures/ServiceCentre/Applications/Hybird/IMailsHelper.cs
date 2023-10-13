using System;
using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

public interface IMailsHelper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mailServer"></param>
    /// <param name="mail"></param>
    /// <returns></returns>
    Task<bool> SendMail(IMailServer mailServer, IMail mail);
}

