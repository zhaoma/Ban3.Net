using  Ban3.Infrastructures.EventBus.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace  Ban3.Infrastructures.EventBus.Factories
{
    internal static class AggregateFactory<T>
    {
        private static readonly Func<T> _constructor = CreateTypeConstructor();

        private static Func<T> CreateTypeConstructor()
        {
            try
            {
                var newExpr = Expression.New(typeof(T));
                var func = Expression.Lambda<Func<T>>(newExpr);
                return func.Compile();
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        public static T CreateAggregate()
        {
            if (_constructor == null)
                throw new MissingParameterLessConstructorException(typeof(T));
            return _constructor();
        }
    }
}
