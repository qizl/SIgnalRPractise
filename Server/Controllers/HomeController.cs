using Microsoft.AspNet.SignalR;
using Server.Hubs;
using Server.Models;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string msg = null, int win = 0)
        {
            ViewBag.Title = "Home Page";

            if (!string.IsNullOrEmpty(msg))
                GlobalHost.ConnectionManager.GetHubContext<ChatHub>().Clients.All.addNewMessageToPage("from server", msg);
            if (win != 0)
            {
                switch (win)
                {
                    case 1:
                        GlobalHost.ConnectionManager.GetHubContext<StockTickerHub>().Clients.All.Notify(); break;
                    case 2:
                        GlobalHost.ConnectionManager.GetHubContext<StockTickerHub>().Clients.All.UpdateStockPrice(new Stock() { Price = 12, Symbol = "safd" }); break;
                }
            }

            return View();
        }
    }
}
