using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Entities;

namespace D7;

[TableIs("demo表","Demo",DbName = "Default")]
public class Demo
    : BaseEntity
{
    [FieldIs(ColumnIndex = 1,Increment=true,ColumnName = "Id",Key=true,NotForInsert = true,NotForUpdate = true)]
    public int Id { get; set; }


    [FieldIs(ColumnIndex = 1, ColumnName = "Identity", Key = true, NotForInsert = true, NotForUpdate = true)]
    public string Identity { get; set; }

    [FieldIs(ColumnIndex = 2,ColumnName = "Name",SupportSearch = true)]
    public string Name { get; set; }
    
    [FieldIs(ColumnIndex =3, ColumnName = "UpdateTime")]
    public string Update { get; set; }


}