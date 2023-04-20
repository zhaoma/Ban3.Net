using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract;

public class DevOps
{
    static DevOps()
    {
        //check server status
        if (string.IsNullOrEmpty(Config.Host.BaseUrl))
            throw new Exception("plz init appSettings.json first.");
    }

    public static IReportService Report;

    public static IBuild Build;

    public static ICore Core;

    public static IPipelines Pipelines;

    public static ITfvc Tfvc;
}

public record Types { 
Dictionary<string,Dictionary<string,int>> Dics { get; set; }
}