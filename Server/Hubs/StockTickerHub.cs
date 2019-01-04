using Microsoft.AspNet.SignalR;
using Server.Models;

namespace Server.Hubs
{
    public class StockTickerHub : Hub
    {
        public void BroadcastStockPrice(Stock stock)
        {
            Clients.All.UpdateStockPrice(stock);
        }

        public void NotifyAllClients()
        {
            Clients.All.Notify();
        }
    }
}