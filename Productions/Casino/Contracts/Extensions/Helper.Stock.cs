using Ban3.Productions.Casino.Contracts.Enums;

namespace Ban3.Productions.Casino.Contracts.Extensions;

public static partial class Helper
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static StockGroup GetStockGroup(this string code)
    {
        if (code.Length < 6)
            return (StockGroup)0;
        string str = code.Substring(0, 3);
        if (str == "000")
            return StockGroup.SZA;
        if (str == "002" || str == "003")
            return StockGroup.SZZ;
        if (str == "300" || str == "301")
            return StockGroup.SZC;
        return str == "688" ? StockGroup.SHK : StockGroup.SHA;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static string GetStockPrefix(this string code)
    {
        switch (code.GetStockGroup())
        {
            case StockGroup.SZA:
            case StockGroup.SZZ:
            case StockGroup.SZC:
                return "sz";
            default:
                return "sh";
        }
    }

    public static string GetStockNumPrefix(this string code)
        => code.GetStockPrefix() == "sz" ? "1" : "0";
}