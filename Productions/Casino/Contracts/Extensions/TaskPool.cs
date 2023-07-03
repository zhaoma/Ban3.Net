using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ban3.Productions.Casino.Contracts.Extensions;

public class TaskPool<T>
{
    public List<T> Args { get; set; }

    public int MaxParallel { get; set; }

    public Action<T> Handle { get; set; }
    
    public TaskPool(){}

    public TaskPool(List<T> args,int maxParallel,Action<T> handle)
    {
        Args=args;
        MaxParallel=maxParallel;
        Handle = handle;

        args.ForEach(a=> _queue.Enqueue(a));
    }

    public void Execute()
    {
        if (Handle == null || Args == null || !Args.Any()) return;

        while (_queue.Count > 0)
        {
            while (_parallelCounter < MaxParallel)
            {
                Console.WriteLine($"parallelCounter={_parallelCounter};_taskList.Count={_taskList.Count}");
                Counter(plus:true);

                var a = _queue.Dequeue();
                var one = Task.Run(() => { Handle(a); }).ContinueWith((task) =>
                {
                    _taskList.Remove(task);
                    Console.WriteLine($"continue parallelCounter={_parallelCounter};_taskList.Count={_taskList.Count}");
                    Counter(plus: false);
                    Execute();
                });

                _taskList.Add(one);
            }

            Task.WaitAll(_taskList.ToArray());
        }
    }

    void Counter(bool plus)
    {
        lock (CounterLock)
        {
            _parallelCounter = plus ? _parallelCounter + 1 : _parallelCounter - 1;
        }
    }

    private List<Task> _taskList =new ();
    private static readonly object CounterLock = new();
    private int _parallelCounter = 0;
    private readonly Queue<T> _queue=new ();
}