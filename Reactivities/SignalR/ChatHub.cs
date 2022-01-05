using MediatR;
using Microsoft.AspNetCore.SignalR;
using Reactivities.Application.Comments;
using System;
using System.Threading.Tasks;

namespace Reactivities.SignalR
{
    public class ChatHub : Hub
    {
        private readonly IMediator _mediator;

        public ChatHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SendComment(Create.Command command)
        {
            var comment = await _mediator.Send(command);

            await Clients.Group(command.ActivityId.ToString())
                .SendAsync("ReceiveComment", comment.Value);
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var activitiyId = httpContext.Request.Query["activityId"];
            await Groups.AddToGroupAsync(Context.ConnectionId, activitiyId);
            var result = await _mediator.Send(new List.Query { ActivityId = Guid.Parse(activitiyId) });
            await Clients.Caller.SendAsync("LoadComments", result.Value);
        }
    }
}
