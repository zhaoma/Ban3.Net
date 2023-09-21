using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Entities;

namespace Ban3.Sites.ViaMicrosoft.Models;

[TableIs("RefererMapping", "RefererMapping", true, false)]
public class RefererMapping
    : BaseEntity
{
    public string Id { get; set; }

    public string IdentityId { get; set; }

    public string RefererModule { get; set; }

    public string RefererId { get; set; }

    public string MappingModule { get; set; }

    public string MappingId { get; set; }

    public string CreatedTime { get; set; }
}