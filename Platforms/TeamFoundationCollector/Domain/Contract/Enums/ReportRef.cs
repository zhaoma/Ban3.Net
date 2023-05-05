using System.ComponentModel;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

public enum ReportRef
{
    [Description("All")]
    All,

    [Description("Changeset")]
    Changeset,

    [Description("Shelveset")]
    Shelveset
}