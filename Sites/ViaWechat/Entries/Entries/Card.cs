using System.Runtime.Serialization;

namespace Ban3.Platforms.WeChatClient.Entries.Entries
{

    /// <summary>
    /// 
    /// </summary>
    public class Card
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "card_type")]
        public string card_type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "cash")]
        public Cash cash { get; set; }
    }
}