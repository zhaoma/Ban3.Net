//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-25
//  ————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.GeneralImpl.Entries.Hybird;
using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

namespace Ban3.Infrastructures.GeneralImpl.Request;

/// 
public class EastmoneyRequest
{
    /// 
    public static InternetResource ResourceForHoldersA( int page = 1, int ps = 300 ) => new()
    {
        Method = HttpMethod.Post,
        Url = $"http://dcfm.eastmoney.com//em_mutisvcexpandinterface/api/js/get?type=NSHDDETAILLA&token=70f12f2f4f091e459a279469fe49eca5&cmd=&st=NDATE,SCODE,RANK&sr=1&p={page}&ps={ps}" +
              "&js={\"pages\":(tp),\"data\":(x)}"
    };

    /// 
    public static InternetResource ResourceForHoldersB( int page = 1, int ps = 300 ) => new()
    {
        Method = HttpMethod.Post,
        Url = $"http://dcfm.eastmoney.com//em_mutisvcexpandinterface/api/js/get?type=HDDETAILLA&token=70f12f2f4f091e459a279469fe49eca5&cmd=&st=NDATE,SCODE,RANK&sr=1&p={page}&ps={ps}" +
              "&js={\"pages\":(tp),\"data\":(x)}"
    };
}