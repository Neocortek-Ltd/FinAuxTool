namespace FinAuxTool.Console;
using Core.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

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
        services.AddSingleton<IAllFinYears, AllFinYears>(sp =>
        {
            // The GetValue method seems to not be able to read an array of any type from a JSON file! Hence the detour via a comma-separated string + Split.
            var finYearsArgRaw = configuration.GetValue<string>("finYearsArg") ?? throw new NullReferenceException(); 
            var finYearsArg = finYearsArgRaw.Split(',').Select(short.Parse).ToArray(); // Select(short.Parse) here is a so-called 'method group' and equivalent to 'Select(s => short.Parse(s))'. 
            
            return new AllFinYears(finYearsArg); 
        });

        services.AddScoped<App>();
    }
}