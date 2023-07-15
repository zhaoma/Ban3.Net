using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Ban3.Infrastructures.EventBus.Queries
{
    public interface IQueryHandler<in T, TResponse> where T : IQuery<TResponse>
    {
        /// <summary>
        ///  Handles a query
        /// </summary>
        /// <param name="query">Query being handled</param>
        /// <returns>Task that represents handling of message</returns>
        Task<TResponse> Handle(T query);
    }
}
