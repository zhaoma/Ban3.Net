using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response;

public class BaseResponse
    : IResponse
{
    public bool Success { get; set; }

}