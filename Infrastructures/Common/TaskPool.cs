//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using log4net;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.Common;

/// <summary>
/// 任务池
/// </summary>
/// <typeparam name="T"></typeparam>
public class TaskPool<T>
{
    static readonly ILog Logger = LogManager.GetLogger( $"TaskPool.{typeof( T )}" );

    /// <summary>
    /// 参数
    /// </summary>
    public List<T>? Args { get; set; }

    /// <summary>
    /// 并发数
    /// </summary>
    public int MaxParallel { get; set; }

    /// <summary>
    /// 行为动作
    /// </summary>
    public Action<T>? Handle { get; set; }

    /// 
    public TaskPool() {}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <param name="maxParallel"></param>
    /// <param name="handle"></param>
    public TaskPool( List<T> args, int maxParallel, Action<T> handle )
    {
        Args = args;
        MaxParallel = maxParallel;
        Handle = handle;

        args.ForEach( a => _queue.Enqueue( a ) );
    }

    /// <summary>
    /// 启动
    /// </summary>
    public void Execute()
    {
        if( Handle == null || Args == null || !Args.Any() ) return;

        _tasks = new Task[Math.Min( _queue.Count, MaxParallel )];
        for( var i = 0; i < _tasks.Length; i++ )
        {
            if( LoadOne( i, out var t ) )
            {
                _tasks[ i ] = t!;
            }
        }

        //Task.WaitAll(Tasks);
        while( _queue.Count > 0 )
        {
            //Console.WriteLine($"queue remain {_queue.Count}");
        }
    }

    bool LoadOne( int index, out Task? t )
    {
        if( _queue.Count > 0 && Handle != null )
        {
            var q = _queue.Dequeue();
            t = Task.Run( () =>
                     {
                         Console.WriteLine( $"CurrentThread:[{Thread.CurrentThread.ManagedThreadId}],Queue remain [{_queue.Count}]" );
                         Handle( q );
                     } )
                    .ContinueWith( ( task ) =>
                     {
                         Console.WriteLine( "continue" );
                         if( LoadOne( index, out var q ) )
                         {
                             _tasks![ index ] = q!;
                         }
                     } );
            return true;
        }

        t = null;
        return false;
    }

    private Task[]? _tasks;
    private readonly Queue<T> _queue = new();
}