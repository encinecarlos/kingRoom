using kingsRoom.Application.Command.KingRoom;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace kingsRoom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private IMediator Mediator { get; }

        public RoomController(IMediator mediator)
        {
            Mediator = mediator;
        }

        public async Task<ActionResult<KingRoomCommand>> DefinekingRoom([FromBody] KingRoomRequest request, CancellationToken cancellationToken)
        {
            var response = await Mediator.Send(request, cancellationToken);

            return Ok(response);
        }
        
    }
}