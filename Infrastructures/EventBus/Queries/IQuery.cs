﻿using  Ban3.Infrastructures.EventBus.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Ban3.Infrastructures.EventBus.Queries
{
    public interface IQuery<TReturn> : IMessage
    {
    }
}
