using System.Collections.Generic;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.TfvcReports;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial class Helper
{
    public static void AppendChangesets(this IdentitySummary identitySummary,
        List<CompositeChangeset> changesets)
    {
        identitySummary.Changesets ??= new Dictionary<string, CompositeChangeset>();

        changesets.ForEach(o =>
        {
            var key = o.Id + "";
            if (identitySummary.Changesets.ContainsKey(key))
            {
                identitySummary.Changesets[key] = o;
            }
            else
            {
                identitySummary.Changesets.Add(key,o);
            }
        });
    }

    public static void AppendShelvesets(this IdentitySummary identitySummary,
        List<CompositeShelveset> shelvesets)
    {
        identitySummary.Shelvesets = identitySummary.Shelvesets ?? new Dictionary<string, CompositeShelveset>();

        shelvesets.ForEach(o =>
        {
            var key = o.Id.MD5String();
            if (identitySummary.Shelvesets.ContainsKey(key))
            {
                identitySummary.Shelvesets[key] = o;
            }
            else
            {
                identitySummary.Shelvesets.Add(key, o);
            }
        });
    }
}