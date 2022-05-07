using Microsoft.AspNetCore.SignalR;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace O2NextGen.SmallTalk.SignalrHub.Hubs
{
    public interface IChatHub {
        //Task UpdateMessages(string recipientId);
        
    }
    
    [Authorize]
    public class ChatHub : Hub, IChatHub
    {
        public override async Task OnConnectedAsync()
        {
            // var httpContext = Context.GetHttpContext();
            // if (httpContext != null)
            // {
            //     var jwtToken = httpContext.Request.Query["access_token"];
            //     var handler = new JwtSecurityTokenHandler();
            //     if (!string.IsNullOrEmpty(jwtToken))
            //     {
            //         var token = handler.ReadJwtToken(jwtToken);
            //         var tokenS = token as JwtSecurityToken;
            //
            //         // replace email with your claim name
            //         var jti = tokenS.Claims.First(claim => claim.Type == "email").Value;
            //         if (jti != null && jti != "")
            //         {
            //             await Groups.AddToGroupAsync(Context.ConnectionId, jti);
            //         }
            //     }
            // }
            await Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
            Console.WriteLine($"Connect... session, {Context.User.Identity.Name}");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
            Console.WriteLine($"Disconnect... session, {Context.User.Identity.Name}");
            await base.OnDisconnectedAsync(ex);
        }

        #region UserState

        public async Task SendStateUser()
        {
            Console.WriteLine($"SendStateUser... session, {Context.User.Identity.Name}");
           await Clients.All.SendAsync("OnUserUpdateState", Context.User.Identities.GetEnumerator().Current);
            //await Groups..All.SendAsync("OnUpdateMessage");
        }

        #endregion
        // string username;
        // public async Task NewUserAsync(string username)
        // {
        //     await Groups.AddToGroupAsync(Context.ConnectionId, username);
        //     this.username = username;
        //     await base.OnConnectedAsync();
        // }
        //
        // public override Task OnConnectedAsync()
        // {
        //      
        //     return base.OnConnectedAsync();
        // }
        // public async Task UpdateMessages(string recipientId)
        // {
        //    await Clients.Group(recipientId).SendAsync("OnUpdateMessage");
        //     //await Groups..All.SendAsync("OnUpdateMessage");
        // }

        //public override async Task OnConnectedAsync()
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
        //    await base.OnConnectedAsync();
        //}

        //public override async Task OnDisconnectedAsync(Exception ex)
        //{
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
        //    await base.OnDisconnectedAsync(ex);
        //}
    }
}
