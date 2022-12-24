using FinAuxTool.Core.Model;
using FinAuxTool.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FinAuxTool.Console;

internal static class Program
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
        services.AddSingleton<AllFinYears>(_ =>
        {
            // The GetValue method seems to NOT be able to read an array of any type from a JSON file! Hence the detour via a comma-separated string + Split.
            var finYearsRaw = configuration.GetValue<string>("finYearsArg") ?? throw new NullReferenceException(); 
            var finYears = finYearsRaw.Split(',').Select(int.Parse).ToArray(); // Select(int.Parse) here is a so-called 'method group' and equivalent to 'Select(s => int.Parse(s))'. 
            
            return new AllFinYears(finYears); 
        });

        services.AddSingleton<TestUsingDi>(); // Remove again when I'm done testing D.I. framework

        services.AddScoped<App>();
    }
}