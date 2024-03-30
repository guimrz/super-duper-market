using Ocelot.Middleware;
using Ocelot.DependencyInjection;

namespace SuperDuperMarket.Services.Gateway.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("ocelot.json");
            builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json");

            builder.Services.AddOcelot();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            await app.UseOcelot();
            
            app.Run();
        }
    }
}
