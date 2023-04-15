using System;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
	public class Variable
	{
		[JsonProperty("isSecret")]
		public bool IsSecret { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}

