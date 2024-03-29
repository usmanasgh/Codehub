using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Blazor;
using BlazorWebAssemblyApp.Client.Services;

namespace BlazorWebAssemblyApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTkxMzc2QDMxMzkyZTM0MmUzME1Va0VnTi9qKzZCa2xZS0FXamVUa3BDK3ladjNtOHRSRGpMQm9KeThpL1U9");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //MUA : Below service for AddHttpClient
            builder.Services.AddHttpClient<IUserService, UserService>(user =>
            {
                user.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            });

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //builder.Services.AddSyncfusionBlazor(); // MUA: Addedd reference dependancies.
            builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });

            await builder.Build().RunAsync();
        }
    }
}
