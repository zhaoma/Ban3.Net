//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-25
//  ————————————————————————————————————————————————————————————————————————————

using System;
using System.Threading.Tasks;

using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

namespace Ban3.Infrastructures.GeneralImpl.Applications.Hybird;

///
public class ChartsUtilizeApacheECharts : OneImplement, IChartsHelper
{
    private IStoragesHelper _storagesHelper;

    ///
    public ChartsUtilizeApacheECharts( IStoragesHelper storagesHelper )
    {
        _storagesHelper = storagesHelper;
    }

    ///
    public async Task<bool> TryCreate<T>( T data, Action<string, IChartsDiagram> action )
    {
        return await Task.FromResult( true );
    }

    ///
    public async Task<IChartsDiagram> TryLoad( string key )
        => await _storagesHelper.TryLoad<IChartsDiagram>( key );
}