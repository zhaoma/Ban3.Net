using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Request.Discussion
{
    public class GetChangesetThreads
    :IRequest
    {

        public string Method() => "GET";

        public string Resource()
            => Enums.APIResource.ChangesetDiscussion.ToAPIResourceString(ChangesetId);

        public string JsonBody() => null;

        public GetChangesetThreads(){}

        public int ChangesetId { get; set; }
    }
}
