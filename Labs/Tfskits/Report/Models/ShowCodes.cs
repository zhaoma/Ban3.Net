using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

namespace Ban3.Labs.TeamFoundationCollector.Presentation.Report.Models
{
    public class ShowCodes
    {
        public Dictionary<int, string>? Lines { get; set; }

        public DiscussionProperties? Properties { get; set; }
    }
}
