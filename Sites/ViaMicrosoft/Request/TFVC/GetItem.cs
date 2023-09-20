using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
{
	public class GetItem
        :IRequest
	{

        public string Method() => "GET";

        public string Resource()
            => Enums.APIResource.Item.ToAPIResourceString();

        public string JsonBody() => null;


        public GetItem()
		{
		}

		/// <summary>
        /// Version control path of an individual item to return.
        /// </summary>
        [JsonProperty("path")]
		public string Path { get; set; } 

		/// <summary>
        /// If true, create a downloadable attachment.
        /// </summary>
        [JsonProperty("download")]
		public bool Download { get; set; }

		/// <summary>
        /// file name of item returned.
        /// </summary>
        [JsonProperty("fileName")]
		public string FileName { get; set; } 

		/// <summary>
        /// Set to true to include item content when requesting json. Default is false.
        /// </summary>
        [JsonProperty("includeContent")]
		public bool IncludeContent { get; set; }

		/// <summary>
        /// Version control path of a folder to return multiple items.
        /// </summary>
        [JsonProperty("scopePath")]
		public string ScopePath { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("versionDescriptor")]
        public TfvcVersionDescriptor VersionDescriptor { get; set; } 
    }
}

