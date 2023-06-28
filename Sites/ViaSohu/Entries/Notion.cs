using System.Collections.Generic;

namespace Ban3.Sites.ViaSohu.Entries
{
    public class Notion
    {
        public int NotionId { get; set; }

        public string Subject { get; set; } = string.Empty;

        public List<string> Stocks { get; set; }
    }
}
