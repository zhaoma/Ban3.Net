/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            Datatables结果
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Common.Responses.DataTables
{
    /// <summary>
    /// DataTables数据结果
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 与请求一致
        /// </summary>
        [JsonProperty("draw")]
        public int Draw { get; set; }

        /// <summary>
        /// Total records, before filtering (i.e. the total number of records in the database)
        /// </summary>
        [JsonProperty("recordsTotal")]
        public int RecordsTotal { get; set; }

        /// <summary>
        /// Total records, after filtering (i.e. the total number of records after filtering has been applied - 
        /// not just the number of records being returned in this result set)
        /// </summary>
        [JsonProperty("recordsFiltered")]
        public int RecordsFiltered { get; set; }

        /// <summary>
        /// The data in a 2D array
        /// Fill this structure with the plain table data
        /// represented as string.
        /// </summary>
        [JsonProperty("data")]
        public List<List<string>> Data { get; set; }
    }
}