using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace  Ban3.Infrastructures.EventBus.Commands
{
    public interface ICommandSender
    {
        Task Send<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand;
    }
}
