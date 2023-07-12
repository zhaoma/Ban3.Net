namespace Ban3.Labs.Casino.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //ScheduleTimer();

            #region  web app run

            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            #endregion
        }

        /// <summary>
        /// create timer for schedule sync process
        /// Operation is not supported on this platform.
        /// </summary>
        static void ScheduleTimer()
        {
            Console.WriteLine("CREATE TIMER.");
            _jobTimer = new System.Timers.Timer
            {
                AutoReset = true,
                Interval = 1000 * 60 * 60 * 3,
                Enabled = true
            };

            _jobTimer.Elapsed += (_, _) =>
            {
                _jobTimer.Enabled = false;
                var cmd = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ca.exe");
                Console.WriteLine(cmd);

                if (_handler == null)
                {
                    var args = Infrastructures.Common.Config.AppConfiguration["Ca:Args"] + "";
                    if (args == "")
                        args = "--daily";
                    _handler = new Infrastructures.PlatformInvoke.Handles.ProcessHandlerAsync(cmd,
                        args.Split(' '));

                    _handler.ReceivedData += info => { Console.WriteLine($"info:{info}"); };
                    _handler.ReceivedError += error => { Console.WriteLine($"error:{error}"); };

                    _handler.Exited += JobCallback;
                }

                _handler.Execute();
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
}