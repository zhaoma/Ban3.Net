using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace  Ban3.Infrastructures.EventBus.Messages
{
    public interface ICancellableHandler<in T> where T : IMessage
    {
        /// <summary>
        ///  Handles a message
        /// </summary>
        /// <param name="message">Message being handled</param>
        /// <param name="token">Cancellation token from sender/publisher.</param>
        /// <returns>Task that represents handling of message</returns>
        Task Handle(T message, CancellationToken token = default);
    }
}
