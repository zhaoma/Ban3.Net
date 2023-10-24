using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Casino;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

namespace Ban3.Infrastructures.GeneralImpl.Applications.Casino;

public class CollectStockCodeFromTushare:OneImplement, IStockCodesCollector
{
	private IInternetsHelper _internetsHelper;

	public CollectStockCodeFromTushare(IInternetsHelper internetsHelper)
	{
		_internetsHelper = internetsHelper;
    }

	public Task<bool> TryFetchStocks(out IEnumerable<IStock> stocks)
	{
		_internetsHelper.TryRequest()
	}
}

