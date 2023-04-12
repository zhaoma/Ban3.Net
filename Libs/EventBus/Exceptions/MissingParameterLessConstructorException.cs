using System;

namespace  Ban3.Infrastructures.EventBus.Exceptions
{
    public class MissingParameterLessConstructorException : System.Exception
    {
        public MissingParameterLessConstructorException(Type type)
            : base($"{type.FullName} has no constructor without parameters. This can be either public or private")
        { }
    }
}