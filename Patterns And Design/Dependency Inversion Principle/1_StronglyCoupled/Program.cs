using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace _1_StronglyCoupled
{
    class Program
    {
        static void Main(string[] args)
        {
            IHost host = CreateBuilder(args).Build();
            Handler(host.Services, "Hello there");
            host.Run();

        }
        static IHostBuilder CreateBuilder(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args).
                 ConfigureServices((h, services) =>
                 {
                     services.AddScoped<IMessageWriter, MessageWriter>().
                     AddScoped<MessageWriter>();
                 });

            return host;
        }

        static void Handler(IServiceProvider services, string msg)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            MessageWriter messageWriter = provider.GetRequiredService<MessageWriter>();
            messageWriter.Write(msg);
        }
    }





}
