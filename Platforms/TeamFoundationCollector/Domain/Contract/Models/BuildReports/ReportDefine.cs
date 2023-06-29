using System;
using System.Collections.Generic;
using System.Text;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BuildReports
{
    public class ReportDefine
    {
        public string Id { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public List<ReportSection> Sections { get; set; } = new();

        public List<string> Subscribed { get; set; } = new();

        public List<string>? CC { get; set; }
    }
}
