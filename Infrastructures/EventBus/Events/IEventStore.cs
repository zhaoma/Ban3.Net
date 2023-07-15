﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace  Ban3.Infrastructures.EventBus.Events
{
    /// <summary>
    /// Defines the methods needed from the event store.
    /// </summary>
    public interface IEventStore
    {
        /// <summary>
        /// Save events
        /// </summary>
        /// <param name="events">Events to be saved</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task of save operation</returns>
        Task Save(IEnumerable<IEvent> events, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets events for an aggregate
        /// </summary>
        /// <param name="aggregateId">Guid of the aggregate to be retrieved</param>
        /// <param name="fromVersion">All events after this should be returned. -1 if from start</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns>Task with events for aggregate</returns>
        Task<IEnumerable<IEvent>> Get(Guid aggregateId, int fromVersion, CancellationToken cancellationToken = default);
    }
}
