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
}