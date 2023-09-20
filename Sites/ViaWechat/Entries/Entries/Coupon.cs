using System.Runtime.Serialization;

namespace Ban3.Platforms.WeChatClient.Entries.Entries
{
    /// <summary>
    /// 
    /// </summary>
    public class Coupon
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "card")]
        public Card? Card { get; set; }
    }
}
