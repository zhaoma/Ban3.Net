using System.Threading.Tasks;
using Ban3.Infrastructures.NetHttp;
using Ban3.Sites.ViaEastmoney.Request;
using Ban3.Sites.ViaEastmoney.Response;

namespace Ban3.Sites.ViaEastmoney;

/// 
public static class Helper
{
    /// <summary>
    /// 下载所有标的代码
    /// </summary>
    /// <returns></returns>
    public static async Task<DownloadAllCodesResult> DownloadAllCodes()
    {
        var request = new DownloadAllCodes();
        return await new Infrastructures.NetHttp.Entries.TargetHost
        {
            Anonymous = true
        }.RequestGeneric<DownloadAllCodesResult>(request);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query"></param>
    /// <returns></returns>
    public static async Task<QueryResult<T>> Query<T>(this Query query)
        => await new Infrastructures.NetHttp.Entries.TargetHost
        {
            Anonymous = true
        }.RequestGeneric<QueryResult<T>>(query);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="reportName"></param>
    /// <param name="pageNumber"></param>
    /// <returns></returns>
    public static async Task<QueryResult<T>> Query<T>(this Enums.ReportName reportName, int pageNumber) {
        var query = new Query
        {
            Condition = new Entries.QueryCondition
            {
                ReportName = reportName,
                PageNumber = pageNumber

            }
        };
        return await query.Query<T>();
    }
}