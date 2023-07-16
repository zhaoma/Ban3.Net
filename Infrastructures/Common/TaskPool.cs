using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace Ban3.Infrastructures.Common;

public class TaskPool<T>
{
    static readonly ILog Logger = LogManager.GetLogger($"TaskPool.{typeof(T)}");

    public List<T>? Args { get; set; }

    public int MaxParallel { get; set; }

    public Action<T>? Handle { get; set; }

    public TaskPool() { }

    public TaskPool(List<T> args, int maxParallel, Action<T> handle)
    {
        Args = args;
        MaxParallel = maxParallel;
        Handle = handle;

        args.ForEach(a => _queue.Enqueue(a));
    }

    public void Execute()
    {
        if (Handle == null || Args == null || !Args.Any()) return;

        Tasks = new Task[Math.Min(_queue.Count, MaxParallel)];
        for (var i = 0; i < Tasks.Length; i++)
        {
            if (LoadOne(i,out var t))
            {
                Tasks[i] = t!;
            }
        }

        Task.WaitAll(Tasks);
    }

    bool LoadOne(int index,out Task? t) 
    {
        if (_queue.Count > 0&&Handle!=null)
        {
            var q = _queue.Dequeue();
            t = Task.Run(() => {
                    Console.WriteLine($"CurrentThread:[{Thread.CurrentThread.ManagedThreadId}],Queue remain [{_queue.Count}]");
                    Handle(q); })
                .ContinueWith((task) =>{
                    Console.WriteLine("continue");
                    if (LoadOne(index,out var q))
                    {
                        Tasks[index] = q!;

                    }
	            });
            return true;
        }

        t = null;
        return false;
    }

    private static Task[] Tasks;
    private readonly Queue<T> _queue = new();
}