using System;

namespace  Ban3.Infrastructures.EventBus.Exceptions
{
    public class EventsOutOfOrderException : System.Exception
    {
        public EventsOutOfOrderException(Guid id)
            : base($"EventStore gave events for aggregate {id} out of order")
        { }
    }
}