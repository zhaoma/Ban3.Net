using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ban3.Platforms.WeChatClient.Entries.UI
{
    /// <summary>
    /// 个性化菜单
    /// </summary>
    public class ConditionalMenu
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "button")]
        public List<Button>? Button { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MatchRule? Matchrule { get; set; }
    }
}
