using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
            //Clients.Caller.addNewMessageToPage(name, $"my connectionid is {Context.ConnectionId}");
            //Clients.Others.addNewMessageToPage(name, message);

            //Clients.Client(Context.ConnectionId).addNewMessageToPage(name, message);
            //Clients.Clients(new string[] { "c0521887-2585-44d9-9de2-456d5ec2d1fb", "b9583d06-6303-4126-bf32-6e5d61371889" }).addNewMessageToPage(name, message);

        }

        public void SendToGroup(string groupName, string message)
        {
            Clients.Group(groupName).addNewMessageToPage($"{Context.ConnectionId}", message);
        }

        public Task JoinGroup(string groupName)
        {
            return Groups.Add(Context.ConnectionId, groupName);
        }
        public Task LeaveGroup(string groupName)
        {
            return Groups.Remove(Context.ConnectionId, groupName);
        }
    }
}