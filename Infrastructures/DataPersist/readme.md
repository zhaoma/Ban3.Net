# Ban3
我与小孩们常呆在三班，所以用了这么个名字，只是个代号不是么：）

## _最后修改_
2023-08-08
-- 检查了同步与异步的CRUD, 看起来还好

## Features

- CRUD
-- 同步
-- 异步
- 示例脚本

[TableIs("demo表","Demo",DbName = "UseSqlite")]
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

var x = new Demo
{
    Id = 1,
    Subject = "THIS IS SUBJECT",
    Note = "I'm Note.",
    UpdateTime = DateTime.Now,
    CreateTime = DateTime.Now
};

var y=x.Create();

//var a = await x.CreateAsync();
//(a.Id + "").WriteColorLine(ConsoleColor.Red);

var r158 = new Demo { Id = 124158 }.Retrieve();
r158.ObjToJson().WriteColorLine(ConsoleColor.DarkBlue);

y.UpdateTime = DateTime.Now;
Console.WriteLine($"{r158.Update()} affected.");

var r1 = new Demo { Id = 124156 }.Delete();
Console.WriteLine(r1 + "affected");

var r2 = new Demo().Delete("Id<=10000");
Console.WriteLine(r2 + "affected");

etc.

## 为何来费空间

少一些重复，多一些持续更新或是清理:)

## License

MIT

**Free Software, Hell Yeah!**