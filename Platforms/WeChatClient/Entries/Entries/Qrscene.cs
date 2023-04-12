namespace Ban3.Platforms.WeChatClient.Entries.Entries
{
    /// <summary>
    /// 
    /// </summary>
    public class Qrscene
            : Qrcode
    {
        private int _expire_seconds = 2592000;

        /// <summary>
        /// 
        /// </summary>
        public int expire_seconds
        {
            get
            {
                return _expire_seconds;
            }
            set
            {
                _expire_seconds = value;
            }
        }

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