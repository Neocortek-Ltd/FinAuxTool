namespace FinAuxTool.Console;
using Core.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile(Path.GetFullPath("../../../appsettings.json"))
            .AddEnvironmentVariables();
        
        var configuration = builder.Build();
        
        var host = Host.CreateDefaultBuilder(args).
            ConfigureServices((hostContext, services) =>
            {
                ConfigureServices(hostContext, services, configuration);
            })
            .Build();
        
        host.Services.GetRequiredService<App>().Run();
    }
    
    private static void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services, IConfigurationRoot configuration)
    {
        // Adding all services used for dependency injection below. 
        
        services.AddSingleton<IFinYearUK, FinYearUK>(sp =>
        {
            var finYearArg = configuration.GetValue<short>("finYearArg");
            return new FinYearUK(finYearArg); 
        });
        
        services.AddScoped<App>();
    }
}