using Autofac;

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.DependencyInjection;
using Ban3.Infrastructures.ServiceCentre.Applications.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

var container = new ContainerBuilder().RegisterOnConfig().Build();

var collectCodes = container.Resolve<IStockCodesCollector>();

IEnumerable<IStock> result = new List<IStock>();
var got = await collectCodes.TryFetchStocks( r => result = r );

Console.WriteLine( got );
Console.WriteLine( result.ObjToJson() );