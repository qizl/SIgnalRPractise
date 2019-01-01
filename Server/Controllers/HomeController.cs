using Microsoft.AspNet.SignalR;
using Server.Hubs;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string msg = null)
        {
            ViewBag.Title = "Home Page";

            if (!string.IsNullOrEmpty(msg))
                GlobalHost.ConnectionManager.GetHubContext<ChatHub>().Clients.All.addNewMessageToPage("from server", msg);

            return View();
        }
    }
}
