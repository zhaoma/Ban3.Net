using Ban3.Infrastructures.DataPersist.Attributes;
using D7;

namespace D7;

[TableIs(name:"DE2",tableName: "Demo2", DbName = "UseSqlite")]
public class Demo2
:Demo
{

    [FieldIs(ColumnIndex = 4, ColumnName = "desc", SupportSearch = true)]
    public string Desc { get; set; }   
}