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
            //var redisScaleoutConfiguration = new RedisScaleoutConfiguration("192.168.0.1", 6379, null, "chat/signalr") { Database = 0 };
            //GlobalHost.DependencyResolver.UseRedis(redisScaleoutConfiguration);

            //var hubconfiguration = new HubConfiguration();
            //app.MapSignalR("/signalr", hubconfiguration);

            app.MapSignalR();
        }
    }
}