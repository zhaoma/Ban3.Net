using Ban3.Infrastructures.Common.Attributes;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.WorkItemTracking;

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

    public static IDiscussion Discussion;

    public static IPipelines Pipelines;

    public static ITfvc Tfvc;

    public static void PrepareForce()
    {
        Core.PrepareTeams(true);
        Discussion.PrepareThreads();

    }

    public static async void SendMail(SendMail request)
    {
         await ServerResource.WorkItemTrackingSendMail
            .ExecuteVoid(request);
    }

    public static void Sync()
    {

    }
}