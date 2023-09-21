using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Sites.ViaMicrosoft.Request.Discussion;

public class GetShelvesetThreads
    : IRequest
{

    public string Method() => "GET";

    public string Resource()
        => Enums.APIResource.ShelvesetDiscussion.ToAPIResourceString(ShelvesetId, Owner);

    public string JsonBody() => null;

    public GetShelvesetThreads()
    {
    }

    public string ShelvesetId { get; set; }

    public string Owner { get; set; }
}