//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/12/27 11:00
//  function:	SubscriptionInfo.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using System;
namespace  Ban3.Infrastructures.EventBus.Events
{
	public class SubscriptionInfo
    {
        public bool IsDynamic { get; }
        public Type HandlerType { get; }

        private SubscriptionInfo(bool isDynamic, Type handlerType)
        {
            IsDynamic = isDynamic;
            HandlerType = handlerType;
        }

        public static SubscriptionInfo Dynamic(Type handlerType)
        {
            return new SubscriptionInfo(true, handlerType);
        }
        public static SubscriptionInfo Typed(Type handlerType)
        {
            return new SubscriptionInfo(false, handlerType);
        }
    }
}

