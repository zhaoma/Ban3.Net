﻿using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities.TFVC
{
	public class ItemContent
	{
		public ItemContent()
		{
		}

        [JsonProperty("contentType")]
		public string ContentType { get; set; } 

        [JsonProperty("content")]
		public string Content { get; set; } 
	}
}
