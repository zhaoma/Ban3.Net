using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Entities;

namespace D7;

[TableIs("demo表","Demo",DbName = "Usemysql")]
public class Demo
    : BaseEntity
{
    [FieldIs(ColumnIndex = 1,Increment=true,ColumnName = "Id",Key=true,NotForInsert = true,NotForUpdate = true)]
    public int Id { get; set; }
    
    [FieldIs(ColumnIndex = 2,ColumnName = "Subject",SupportSearch = true)]
    public string Subject { get; set; }


    [FieldIs(ColumnIndex = 3, ColumnName = "Note", SupportSearch = true)]
    public string Note { get; set; }

    [FieldIs(ColumnIndex =11, ColumnName = "UpdateTime")]
    public DateTime UpdateTime { get; set; }
    
    [FieldIs(ColumnIndex = 12, ColumnName = "CreateTime",NotForUpdate = true)]
    public DateTime CreateTime { get; set; }
}