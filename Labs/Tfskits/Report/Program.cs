namespace Ban3.Labs.TeamFoundationCollector.Presentation.Report;

public class Program
{
    public static void Main(string[] args)
    {
        ScheduleTimer();

        #region web app run

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        app.UseStaticFiles();

        app.UseRouting();
        
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();

        #endregion
    }

    /// <summary>
    /// create a timer call process support.exe to sync data when web app starting.
    /// </summary>
    static void ScheduleTimer()
    {
        Console.WriteLine("CREATE TIMER.");
        _jobTimer = new System.Timers.Timer
        {
            AutoReset = true,
            Interval = 1000 * 60 * 30,
            Enabled = true
        };
        _jobTimer.Elapsed += (s, e) =>
        {
            _jobTimer.Enabled = false;
            var cmd = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "support.exe");
            Console.WriteLine(cmd);

            if (_handler == null)
            {
                var args = Infrastructures.Common.Config.AppConfiguration["Support:Args"] + "";
                if (args == "")
                    args = "--key SSME";
                _handler = new Infrastructures.PlatformInvoke.Handles.ProcessHandlerAsync(cmd,
                    args.Split(' '));

                _handler.ReceivedData += (s) => { Console.WriteLine($"Support resp:{s}"); };
                _handler.ReceivedError += (s) => { Console.WriteLine($"Support error:{s}"); };

                _handler.Exited += JobCallback;
            }

            _handler?.Execute();
        };
    }

    static void JobCallback()
    {
        Console.WriteLine("RESTART TIMER.");
        if (_jobTimer != null)
        {
            _jobTimer.Enabled = true;
            _jobTimer.Start();
        }
    }

    private static Infrastructures.PlatformInvoke.Handles.ProcessHandlerAsync? _handler;
    private static System.Timers.Timer? _jobTimer;
}