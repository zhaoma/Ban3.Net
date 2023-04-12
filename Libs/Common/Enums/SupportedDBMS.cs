/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            支持的数据库
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;

namespace Ban3.Infrastructures.Common.Enums
{
    /// <summary>
    /// 支持的数据库
    /// </summary>
    public enum SupportedDBMS
    {
        //Oracla,not supported
        /// <summary>
        /// mysql
        /// </summary>
        MySQL,
        /// <summary>
        /// MSSQL
        /// </summary>
        MicrosoftSQLserver,
        /// <summary>
        /// SQLite
        /// </summary>
        SQLite
    }
}

