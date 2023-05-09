using System;
using System.Collections.Generic;
using System.Text;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BuildReports
{
    public class ReportDefine
    {
        public string Id { get; set; }

        public string Subject { get; set; }

        public List<IReportSection> Sections { get; set; }

        public List<string> Subscribed { get; set; }

        public List<string>? CC { get; set; }
    }
}
