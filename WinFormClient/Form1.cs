using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormClient.Models;

namespace WinFormClient
{
    public partial class Form1 : Form
    {
        private IHubProxy stockTickerHubProxy;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var hubConnection = new HubConnection("http://localhost:65495/");
            this.stockTickerHubProxy = hubConnection.CreateHubProxy("StockTickerHub");
            this.stockTickerHubProxy.On<Stock>("UpdateStockPrice", stock => this.showMsg($"Stock update for { stock.Symbol} new price {stock.Price.ToString("C0")}"));
            this.stockTickerHubProxy.On("notify", () => { this.showMsg("Notified!"); });
            hubConnection.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.stockTickerHubProxy.Invoke("BroadcastStockPrice", new Stock() { Symbol = "MSFT" });
        }

        private void showMsg(string str) => MessageBox.Show(str);
    }
}
