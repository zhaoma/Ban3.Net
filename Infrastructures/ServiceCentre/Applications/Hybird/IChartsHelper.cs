using System;
using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

public interface IChartsHelper
{
    Task<bool> CreateDiagram<T>(T data,out IChartsDiagram chartsDiagram);
}

