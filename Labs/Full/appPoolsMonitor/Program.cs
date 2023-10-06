using System.DirectoryServices;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;

namespace appPoolsMonitor;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Monitor start ... ");

        new Action(CheckPools)
            .CreateTimer(3000);

        while (Console.ReadKey().Key != ConsoleKey.X)
        {
            Console.WriteLine("X for exit.");
        }
    }

     private static DirectoryEntry pools = null;

    static void CheckPools()
    {
        try
        {
             pools ??= new DirectoryEntry(@"IIS://localhost/W3SVC/AppPools");
             var enumer = pools.Children.GetEnumerator();

            while (enumer.MoveNext())
            {
               using var pool = (DirectoryEntry)enumer.Current;

                var state = (pool.Properties["AppPoolState"].Value + "").ToInt();

                if (state != 2)
                {
                    pool.Invoke("Start", null);
                    pool.CommitChanges();

                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}:{pool.Name} stopped,and start success.".WriteColorLine(ConsoleColor.DarkRed);
                }
                else
                {
                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}:{pool.Name} running ok.".WriteColorLine(ConsoleColor.DarkGreen);
                }
            }
        }
        catch (Exception ex)
        {
            $"support windows only.{ex.Message}".WriteColorLine(ConsoleColor.DarkBlue);
        }
    }
}

