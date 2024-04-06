using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace SuperDuperMarket.Services.Gateway.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("ocelot.json");
            builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true);

            builder.Services.AddOcelot();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            await app.UseOcelot();

            app.Run();
        }
    }
}