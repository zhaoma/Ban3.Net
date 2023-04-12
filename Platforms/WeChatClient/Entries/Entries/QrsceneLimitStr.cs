namespace Ban3.Platforms.WeChatClient.Entries.Entries
{
    /// <summary>
    /// 
    /// </summary>
    public class QrsceneLimitStr
            : Qrcode
    {
        /// <summary>
        /// action_name
        /// </summary>
        public string action_name = "QR_LIMIT_STR_SCENE";

        /// <summary>
        /// action_info
        /// </summary>
        public ActionStr action_info { get; set; }
    }
}