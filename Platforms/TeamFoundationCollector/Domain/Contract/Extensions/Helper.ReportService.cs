using System;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial class Helper
{
    public static bool SendMail(this IReportService _,List<string>? to,List<string>? cc,string? mailBody)
    {
        return true;
    }
}

