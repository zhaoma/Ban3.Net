using System;

namespace  Ban3.Infrastructures.EventBus.Exceptions
{
    public class ResolvedHandlerMethodNotFoundException : ArgumentNullException
    {
        public ResolvedHandlerMethodNotFoundException(string paramName)
            : base($"Could not execute Handle method on type {paramName}")
        {
        }
    }
}