using System.Runtime.CompilerServices;

namespace FinAuxTool.Console;
using System;
using Core.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args).ConfigureServices(ConfigureServices).Build();
        host.Services.GetRequiredService<App>().Run();
    }
    
    private static void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
    {
        services.AddSingleton<IFinYearUK, FinYearUK>(sp => new FinYearUK(2022));
        services.AddScoped<App>();
    }
}