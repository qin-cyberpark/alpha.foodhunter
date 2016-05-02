using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(FoodHunterAlpha.SignalRConfig))]
namespace FoodHunterAlpha
{
    public class SignalRConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}