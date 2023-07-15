using System;

namespace  Ban3.Infrastructures.EventBus.Exceptions
{
    public class HandlerNotResolvedException : ArgumentNullException
    {
        public HandlerNotResolvedException(string paramName)
            : base($"Type {paramName} was resolved to null from service locator")
        {
        }
    }
}
