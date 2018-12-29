using Microsoft.AspNet.SignalR;
using SignalRPractise.Hubs;
using System.Web.Mvc;

namespace SignalRPractise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chat() => View();

        public void SendMsg(string msg) => GlobalHost.ConnectionManager.GetHubContext<ChatHub>().Clients.All.addNewMessageToPage("from browser", msg);

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}