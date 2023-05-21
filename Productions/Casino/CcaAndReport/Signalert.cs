using Ban3.Productions.Casino.CcaAndReport.Implements;
using Ban3.Productions.Casino.Contracts.Interfaces;

namespace Ban3.Productions.Casino.CcaAndReport;

public class Signalert
{
    public static ICollector Collector  = new Collector();

    public static ICalculator Calculator = new Calculator();

    public static IAnalyzer Analyzer = new Analyzer();

    public static IReportor Reportor = new Reportor();
}