using Ban3.Platforms.TeamFoundationCollector.Infrastructrue.Common.Enums;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

public class ItemContent
{
    public string Content { get; set; }

    public ItemContentType ContentType { get; set; }
}