using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Attributes;

/// <summary>
/// 资源的属性定义(路径),Not in use
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class ResourceDeclareAttribute
    : Attribute
{
    public ResourceDeclareAttribute(
        Type request,
        Type response
        )
    {
        Request =request;
        Response = response;
    }

    public Type Request { get; set; }

    public Type Response { get; set; }
}
