using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using StockOperate = Ban3.Infrastructures.Indicators.Outputs.StockOperate;

namespace Ban3.Infrastructures.Indicators;

/// <summary>
/// 数据保存与加载
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 保存策略汇总
    /// </summary>
    /// <param name="ps"></param>
    /// <returns></returns>
    public static Dictionary<string, ProfileSummary>? Save(this Dictionary<string, ProfileSummary>? ps)
    {
        "ps".DataFile<ProfileSummary>()
        .SaveFileOnDemand(ps, out _);
        return ps;
	}

    /// <summary>
    /// 加载策略汇总
    /// </summary>
    /// <returns></returns>
    public static Dictionary<string, ProfileSummary>? LoadProfileSummaries()
        => "ps".DataFile<ProfileSummary>()
            .ReadFileAs<Dictionary<string, ProfileSummary>>();

    /// <summary>
    /// 保存买卖点
    /// </summary>
    /// <param name="dots"></param>
    /// <param name="filter"></param>
    /// <returns></returns>
    public static Dictionary<string, List<DotInfo>>? SaveFor(this Dictionary<string, List<DotInfo>>? dots,
        FocusFilter filter)
    {
        filter.Identity.DataFile<DotInfo>()
            .SaveFileOnDemand(dots, out _);

        return dots;
    }

    /// <summary>
    /// 加载买卖点
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public static Dictionary<string, List<DotInfo>>? LoadDots(this FocusFilter filter)
        => filter.Identity.DataFile<DotInfo>()
            .ReadFileAs<Dictionary<string, List<DotInfo>>>();
    
    /// <summary>
    /// LineOfPoint 保存
    /// </summary>
    /// <param name="lineOfPoint"></param>
    /// <param name="stock"></param>
    /// <param name="cycle"></param>
    /// <returns></returns>
    public static LineOfPoint? SaveFor(this LineOfPoint? lineOfPoint, Stock stock, StockAnalysisCycle cycle)
        => lineOfPoint.SaveEntity(_ => stock.FileNameWithCycle(cycle));

    /// <summary>
    /// LineOfPoint 获取
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="cycle"></param>
    /// <returns></returns>
    public static LineOfPoint? LoadLineOfPoint(Stock stock, StockAnalysisCycle cycle)
        => stock.FileNameWithCycle(cycle).LoadEntity<LineOfPoint>();

    /// <summary>
    /// StockSets 保存
    /// </summary>
    /// <param name="sets"></param>
    /// <param name="stock"></param>
    /// <returns></returns>
    public static List<StockSets>? SaveFor(this List<StockSets>? sets, Stock stock)
        => sets.SaveEntities(stock.Code);

    /// <summary>
    /// StockSets获取
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    public static List<StockSets>? LoadStockSets(this Stock stock)
        => stock.Code.LoadEntities<StockSets>();

    /// <summary>
    /// 个股StockSets中用日期获取
    /// </summary>
    /// <param name="sets"></param>
    /// <param name="tradeDate"></param>
    /// <returns></returns>
    public static List<string>? GetSetKeys(this List<StockSets>? sets, string tradeDate)
        => sets?
            .Last(o => o.MarkTime.ToYmd().Equals(tradeDate))?
            .SetKeys?
            .ToList();

    /// <summary>
    /// 保存榜单
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static List<ListRecord>? Save(this List<ListRecord>? list)
        => list.SaveEntities("latest");

    /// <summary>
    /// 加载榜单
    /// </summary>
    /// <returns></returns>
    public static List<ListRecord>? LoadList()
        => "latest".LoadEntities<ListRecord>();

    /// <summary>
    /// StockOperate 保存
    /// </summary>
    /// <param name="operates"></param>
    /// <param name="stock"></param>
    /// <param name="profile"></param>
    /// <returns></returns>
    public static List<StockOperate>? SaveFor(this List<StockOperate>? operates, Stock stock, Profile profile)
        => operates.SaveEntities(stock.FileNameWithProfile(profile));

    /// <summary>
    /// StockOperate 获取
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="profile"></param>
    /// <returns></returns>
    public static List<StockOperate>? LoadOperates(this Stock stock, Profile profile)
        => stock.FileNameWithProfile(profile).LoadEntities<StockOperate>();

    /// <summary>
    /// StockOperationRecord 保存
    /// </summary>
    /// <param name="operates"></param>
    /// <param name="stock"></param>
    /// <param name="profile"></param>
    /// <returns></returns>
    public static List<StockOperationRecord>? SaveFor(
        this List<StockOperationRecord>? operates,
        Stock stock,
        Profile profile)
        => operates.SaveEntities(stock.FileNameWithProfile(profile));

    /// <summary>
    /// StockOperationRecord 获取
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="profile"></param>
    /// <returns></returns>
    public static List<StockOperationRecord>? LoadOperateRecords(this Stock stock, Profile profile)
        => stock.FileNameWithProfile(profile).LoadEntities<StockOperationRecord>();

    /// <summary>
    /// 图表保存
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="stock"></param>
    /// <param name="cycle"></param>
    /// <returns></returns>
    public static Diagram SaveFor(this Diagram diagram, Stock stock, StockAnalysisCycle cycle)
        => diagram.SaveEntity(_ => stock.FileNameWithCycle(cycle));

    /// <summary>
    /// 图表获取
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="cycle"></param>
    /// <returns></returns>
    public static Diagram LoadDiagram(this Stock stock, StockAnalysisCycle cycle)
        => stock.FileNameWithCycle(cycle).LoadEntity<Diagram>()!;

    /// <summary>
    /// 起名保存Diagram
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="diagramName"></param>
    /// <returns></returns>
    public static Diagram SaveFor(this Diagram diagram, string diagramName)
        => diagram.SaveEntity(_ => diagramName);

    /// <summary>
    /// 获取Diagram
    /// </summary>
    /// <param name="diagramName"></param>
    /// <returns></returns>
    public static Diagram LoadDiagram(this string diagramName)
        => diagramName.LoadEntity<Diagram>()!;
}