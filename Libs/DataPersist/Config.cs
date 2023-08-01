using Ban3.Infrastructures.DataPersist.Enums;
using Ban3.Infrastructures.DataPersist.Models;
using Microsoft.Extensions.Configuration;

namespace Ban3.Infrastructures.DataPersist;

public class Config
{
    public static DB DB { get; set; }

    static Config()
    {
        

        DB =new DB
        {
            Database = Database.Sqlite,
            ConnectionString=Common.Config.AppConfiguration?.GetConnectionString("Default")+""
        };

    }
}