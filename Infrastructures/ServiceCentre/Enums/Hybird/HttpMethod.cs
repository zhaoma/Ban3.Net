// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

/// <summary>
/// http请求方法
/// </summary>
public enum HttpMethod
{
    /*HTTP1.0*/

    /// <summary>
    /// HEAD方法请求一个与GET请求的响应相同的响应，但没有响应体.
    /// </summary>
    [Description( "HEAD" )]
    Head,

    /// <summary>
    /// GET方法请求一个指定资源的表示形式. 使用GET的请求应该只被用于获取数据.
    /// </summary>
    [Description( "GET" )]
    Get,

    /// <summary>
    /// POST方法用于将实体提交到指定的资源，通常导致状态或服务器上的副作用的更改. 
    /// </summary>
    [Description( "POST" )]
    Post,

    /*HTTP1.1*/

    /// <summary>
    /// OPTIONS方法用于描述目标资源的通信选项。
    /// </summary>
    [Description( "OPTIONS" )]
    Options,

    /// <summary>
    /// PUT方法用请求有效载荷替换目标资源的所有当前表示。
    /// </summary>
    [Description( "PUT" )]
    Put,

    /// <summary>
    /// PATCH方法用于对资源应用部分修改。
    /// </summary>
    [Description( "PATCH" )]
    Patch,

    /// <summary>
    /// DELETE方法删除指定的资源。
    /// </summary>
    [Description( "DELETE" )]
    Delete,

    /// <summary>
    /// TRACE方法沿着到目标资源的路径执行一个消息环回测试。
    /// </summary>
    [Description( "TRACE" )]
    Trace,

    /// <summary>
    /// CONNECT方法建立一个到由目标资源标识的服务器的隧道。
    /// </summary>
    [Description( "CONNECT" )]
    Connect
}