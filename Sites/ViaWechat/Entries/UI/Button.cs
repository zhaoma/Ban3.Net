using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ban3.Platforms.WeChatClient.Entries.UI
{
    /// <summary>
    /// 一级菜单数组，个数应为1~3个
    /// </summary>
    [Serializable]
    [DataContract]
    public class Button : MenuItem
    {
        /// <summary>
        /// 二级菜单数组，个数应为1~5个
        /// </summary>
        [DataMember(Name = "sub_button")]

        public List<Button>? SubButton { get; set; }
    }
}