namespace Ban3.Platforms.WeChatClient.Entries.Entries
{
    /// <summary>
    /// 
    /// </summary>
    public class QrsceneLimitInt
            : Qrcode
    {
        /// <summary>
        /// 
        /// </summary>
        public string action_name = "QR_LIMIT_SCENE";

        /// <summary>
        /// 
        /// </summary>
        public ActionInt action_info { get; set; }
    }
}