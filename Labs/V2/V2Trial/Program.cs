using Autofac;

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.DependencyInjection;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Applications.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

var container = new ContainerBuilder().RegisterOnConfig().Build();

var c = container.Resolve<IStockEventsCollector>();

var got = await c.TryFetchEvents( new Stock { Symbol = "300757" }, d =>
{
    Console.WriteLine( d.ObjToJson() );
} );

Console.WriteLine( got );

Console.ReadKey();