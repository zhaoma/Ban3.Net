namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino;

public interface IStockCode
{
    string Code { get; set; }

    string Symbol { get; set; }

    string Name { get; set; }

    string ListDate { get; set; }
}