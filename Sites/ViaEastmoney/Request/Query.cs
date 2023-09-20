using Ban3.Infrastructures.NetHttp.Entries;

namespace Ban3.Sites.ViaEastmoney.Request;

public class Query
	:TargetResource
{
	/// 
	public Entries.QueryCondition? Condition { get; set; }

    ///
    public Query()
	{
		Url = $"https://datacenter-web.eastmoney.com/api/data/v1/get?{Condition?.QueryString()}";
	}
}

