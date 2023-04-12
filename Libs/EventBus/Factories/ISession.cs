using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace  Ban3.Infrastructures.EventBus.Factories
{
    public interface ISession
    {
        /// <summary>
        /// Add aggregate to session
        /// </summary>
        /// <typeparam name="T">Type of aggregate</typeparam>
        /// <param name="aggregate">Aggregate object to be added</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns></returns>
        Task Add<T>(T aggregate, CancellationToken cancellationToken = default) where T : AggregateRoot;

        /// <summary>
        /// Get aggregate from session.
        /// </summary>
        /// <typeparam name="T">Type of aggregate</typeparam>
        /// <param name="id">Id of aggregate</param>
        /// <param name="expectedVersion">Expected saved version.</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns></returns>
        Task<T> Get<T>(Guid id, int? expectedVersion = null, CancellationToken cancellationToken = default) where T : AggregateRoot;

        /// <summary>
        /// Save changes in all aggregates in session
        /// </summary>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns></returns>
        Task Commit(CancellationToken cancellationToken = default);
    }
}
