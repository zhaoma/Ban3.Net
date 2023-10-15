using System;
namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino;

/// <summary>
/// 
/// </summary>
public interface IStockSeed : IStockCode, IStockRecord
{
    decimal Factor { get; set; }
}

