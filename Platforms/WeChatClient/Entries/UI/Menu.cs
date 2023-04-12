using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ban3.Platforms.WeChatClient.Entries.UI
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Menu
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "button")]
        public List<Button> Button { get; set; }
    }
}