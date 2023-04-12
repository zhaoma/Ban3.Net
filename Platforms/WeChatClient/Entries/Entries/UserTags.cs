using System.Runtime.Serialization;

namespace Ban3.Platforms.WeChatClient.Entries.Entries
{
    /// <summary>
    /// 
    /// </summary>
    public class UserTags
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "count")]
        public int Count { get; set; }
    }
}