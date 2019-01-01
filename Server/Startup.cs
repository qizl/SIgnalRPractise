using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Server.Startup))]
namespace Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var hubconfiguration = new HubConfiguration();
            //app.MapSignalR("/signalr", hubconfiguration);

            app.MapSignalR();
        }
    }
}