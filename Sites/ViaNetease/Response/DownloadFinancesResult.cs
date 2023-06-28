//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/9/25 08:08
//  function:	DownloadFinancesResult.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;
using Ban3.Sites.ViaNetease.Entries;

namespace Ban3.Sites.ViaNetease.Response;

public class DownloadFinancesResult
{
    /// 
    public List<StockFinance> Data { get; set; } = new();
}

