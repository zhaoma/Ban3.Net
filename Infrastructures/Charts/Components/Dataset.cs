//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/16 13:25
//  function:	Dataset.cs
//  reference:	https://echarts.apache.org/en/option.html#dataset
//  ————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Cogs;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Components;

public class DataSet
{
    /// 
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string? Id { get; set; }

    /// <summary>
    /// 原始数据。一般来说，原始数据表达的是二维表。可以用如下这些格式表达二维表：
    /// 二维数组，其中第一行/列可以给出 维度名，也可以不给出，
    /// 按行的 key-value 形式（对象数组），其中键（key）表明了 维度名
    /// 按列的 key-value 形式，每一项表示二维表的 “一列”：
    /// </summary>
    [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
    public object? Source { get; set; }

    /// <summary>
    /// 使用 dimensions 定义 series.data 或者 dataset.source 的每个维度的信息。
    /// </summary>
    [JsonProperty("dimensions", NullValueHandling = NullValueHandling.Ignore)]
    public object? Dimensions { get; set; }

    /// <summary>
    /// dataset.source 第一行/列是否是 维度名 信息。可选值：
    /// null/undefined/'auto'：默认，自动探测。
    /// true：第一行/列是维度名信息。
    /// false：第一行/列直接开始是数据。
    /// number: 维度名行/列数，也就是数据行/列的开始索引。
    /// 例如：sourceHeader: 2 意味着前两行/列为维度名，从第三行/列开始为数据。
    /// </summary>
    [JsonProperty("sourceHeader", NullValueHandling = NullValueHandling.Ignore)]
    public object? SourceHeader { get; set; }

    /// <summary>
    /// 数据变换
    /// </summary>
    [JsonProperty("transform", NullValueHandling = NullValueHandling.Ignore)]
    public Transform? Transform { get; set; }

    /// <summary>
    /// 指定 dataset.transform 以哪个 dataset 作为输入。
    /// 如果 dataset.transform 被指定了，
    /// 但是 fromDatasetIndex 和 fromDatasetId 都没有被指定，
    /// 那么默认会使用 fromDatasetIndex: 0.
    /// </summary>
    [JsonProperty("fromDatasetIndex", NullValueHandling = NullValueHandling.Ignore)]
    public int? FromDatasetIndex { get; set; }

    /// <summary>
    /// 指定 dataset.transform 以哪个 dataset 作为输入。
    /// </summary>
    [JsonProperty("fromDatasetId", NullValueHandling = NullValueHandling.Ignore)]
    public int? FromDatasetId { get; set; }

    /// <summary>
    /// 如果一个 dataset.transform 会产出多个结果 data ，我们可以使用 fromTransformResult 获得特定的结果。
    /// 大多数场景下，transform 只会产出一个结果，所以大多数情况下 fromTransformResult 并不需要指定。
    /// 当不指定 fromTransformResult 时，默认使用 fromTransformResult: 0。
    /// </summary>
    [JsonProperty("fromTransformResult", NullValueHandling = NullValueHandling.Ignore)]
    public int? FromTransformResult { get; set; }
}

