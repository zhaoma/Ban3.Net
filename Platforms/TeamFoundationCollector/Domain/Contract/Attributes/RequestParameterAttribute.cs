using System;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Attributes;

/// <summary>
/// Not in use
/// </summary>
public class RequestParameterAttribute
	:Attribute
{
    public RequestParameterType Type{get;set;}

    public string QueryKey{get;set;}=string.Empty;

    public RequestParameterAttribute(){
    
    }

    public RequestParameterAttribute(RequestParameterType _type,string queryKey=""){
    Type=_type;
    QueryKey=queryKey;
    }
}

