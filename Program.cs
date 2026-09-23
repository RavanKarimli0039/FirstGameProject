using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FirstGameProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register controller services
            builder.Services.AddControllers();


            var app = builder.Build();

            // Enable default files (e.g., index.html) and static file serving from wwwroot
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Map Web API controller routes
            app.MapControllers();

            // Start the web server
            app.Run();
        }
    }
}