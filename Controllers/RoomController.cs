using kingsRoom.Application.Command.KingRoom;
using Microsoft.AspNetCore.Mvc;

namespace kingsRoom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        public ActionResult<KingRoomCommand> DefinekingRoom()
        {
            var response = new KingRoomCommand();

            return Ok(response);
        }
        
    }
}