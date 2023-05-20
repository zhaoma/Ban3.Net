using System.Collections.Generic;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Sites.ViaTushare.Response;

public class GetStockBasicResult
{
    public List<StockBasic> Data { get; set; } = new();
}