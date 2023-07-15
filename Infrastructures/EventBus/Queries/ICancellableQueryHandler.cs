using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace  Ban3.Infrastructures.EventBus.Queries
{
    public interface ICancellableQueryHandler<in T, TResponse> where T : IQuery<TResponse>
    {
        /// <summary>
        ///  Handles a query
        /// </summary>
        /// <param name="message">Query being handled</param>
        /// <param name="token">Cancellation token from sender/publisher.</param>
        /// <returns>Task of return type that represents handling of message</returns>
        Task<TResponse> Handle(T message, CancellationToken token = default);
    }
}
