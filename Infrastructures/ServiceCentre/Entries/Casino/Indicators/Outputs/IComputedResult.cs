namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

public interface IComputedResult : IStockRecord
{

    IAmount Amount { get; set; }

    IBias Bias { get; set; }

    ICci Cci { get; set; }

    IDmi Dmi { get; set; }

    IEne Ene { get; set; }

    IKd Kd { get; set; }

    IMa Ma { get; set; }

    IMacd Macd { get; set; }
}

