
namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces
{
    public interface IRequest
    {
        /// <summary>
        /// HttpMethod Code
        /// </summary>
        string Method { get; set; }

        /// <summary>
        /// Azure api version
        /// </summary>
        string ApiVersion { get; set; }

        /// <summary>
        /// Request Path (parameters parsed)
        /// </summary>
        /// <returns></returns>
        string RequestPath();

        /// <summary>
        /// Request Query String
        /// </summary>
        /// <returns></returns>
        string RequestQuery();

        /// <summary>
        /// Request Body Data
        /// </summary>
        /// <returns></returns>
        string RequestBody();
    }
}
