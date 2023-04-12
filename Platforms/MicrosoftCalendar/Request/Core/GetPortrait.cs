using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Request.Core
{
    public class GetPortrait
            : IRequest
    {
        public string Method() => "GET";

        public string Resource()
            => Enums.APIResource.Portrait.ToAPIResourceString( Id );

        [JsonProperty( "id" )]
        public string Id { get; set; }

        public string JsonBody() => null;
    }
}