global using fairSlots.Client.Services.GameService;
global using fairSlots.Shared;
using fairSlots.Client;
using fairSlots.Client.Services.PlayerService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace fairSlots.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddHttpClient("fairSlots.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            builder.Services.AddHttpClient("fairSlots.AnonymousAPI", client => {
                client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            });

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("fairSlots.ServerAPI"));
            builder.Services.AddScoped<IGameService, GameService>();
            builder.Services.AddScoped<IPlayerService, PlayerService>();

            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}