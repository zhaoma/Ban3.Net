using System.Collections.Generic;

namespace Ban3.Infrastructures.WxsConfig.Entries
{
    public class CheckResult
    {
        public string WxsFile { get; set; }

        public List<string> NotFound { get; set; }
    }
}
