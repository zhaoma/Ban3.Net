using Microsoft.AspNetCore.StaticFiles;

namespace Ban3.Implements.Alpha.Report;

public class Program
{
    public static void Main(string[] args)
    {

        #region  web app run

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("allAllow", policy =>
            {
                policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

        });

        var app = builder.Build();
        app.UseStaticFiles();
        var extSupports = new Dictionary<string, string> { { ".lr", "application/json" } };
        app.UseStaticFiles(new StaticFileOptions
        {
            ContentTypeProvider = new FileExtensionContentTypeProvider(extSupports)
        });

        app.UseRouting();
        app.UseCors("allAllow");

        //app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();

        #endregion
    }
}
