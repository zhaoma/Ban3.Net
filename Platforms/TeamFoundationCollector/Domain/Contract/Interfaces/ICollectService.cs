using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

public interface ICollectService
{
    Functions.IBuild Build { get; set; }

    Functions.ICore Core { get; set; }
    Functions.IDiscussion Discussion { get; set; }
    Functions.IPipelines Pipelines { get; set; }
    Functions.ITfvc Tfvc { get; set; }


}

