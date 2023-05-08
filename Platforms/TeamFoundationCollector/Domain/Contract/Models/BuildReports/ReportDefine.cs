using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BuildReports
{
    public class ReportDefine
    {
        public string Id { get; set; }

        public string Subject { get; set; }

        public List<int> FocusDefinitions { get; set; }

        public List<string> Subscribed { get; set; }
    }
}
