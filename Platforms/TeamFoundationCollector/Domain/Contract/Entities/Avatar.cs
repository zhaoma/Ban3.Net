﻿using System;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/graph/avatars/get?view=azure-devops-rest-7.0#avatar
    /// </summary>
    public class Avatar
	{

        [JsonProperty("isAutoGenerated")]
        public bool IsAutoGenerated { get; set; }

        [JsonProperty("size")]
        public AvatarSize Size { get; set; }

        [JsonProperty("timeStamp")]
        public string TimeStamp { get; set; } = string.Empty;

        [JsonProperty("value")]
        public List<string>? Value { get; set; }

    }
}

