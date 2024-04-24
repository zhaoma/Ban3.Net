//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;

/// <summary>
/// 买卖线
/// W1:=(2*CLOSE+HIGH+LOW)/4;
/// W2:=EMA(W1,4);
/// W3:=EMA(W2,4);
/// W4:=EMA(W3,4);
/// Buy:(W4-REF(W4,1))/REF(W4,1)*100,COLORRED;
/// Sell:MA(RG,2),COLORGREEN;
/// </summary>
public interface IMX : IIndicatorValue
{
    decimal Buy { get; set; }

    decimal Sell { get; set; }
}
