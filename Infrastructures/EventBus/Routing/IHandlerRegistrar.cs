using  Ban3.Infrastructures.EventBus.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace  Ban3.Infrastructures.EventBus.Routing
{
    public interface IHandlerRegistrar
    {
        /// <summary>
        /// Register the a handler for a given message.
        /// </summary>
        /// <typeparam name="T">Message type to register a handler for</typeparam>
        /// <param name="handler">Function to handle message type</param>
        void RegisterHandler<T>(Func<T, CancellationToken, Task> handler) where T : class, IMessage;
    }
}
