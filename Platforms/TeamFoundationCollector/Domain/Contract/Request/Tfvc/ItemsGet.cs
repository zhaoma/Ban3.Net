using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ban3.Platforms.TeamFoundationCollector.Infrastructrue.Common.Enums;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc
{
    public class ItemsGet
    {
        public string Path { get; set; }

        public bool Download { get; set; }

        public string FileName { get; set; }

        public bool IncludeContent { get; set; }

        public VersionControlRecursionType RecursionLevel { get; set; }

        public string ScopePath { get; set; }

        public SubCondition.VersionDescriptor VersionDescriptor { get; set; }
    }
}
