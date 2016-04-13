﻿using Microsoft.AspNet.SignalR;

namespace ForumR.Hubs
{
    public class ForumHub : Hub
    {
        public void JoinGroup(string name)
        {
            Groups.Add(Context.ConnectionId, name);
        }
    }
}
