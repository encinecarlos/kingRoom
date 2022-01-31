using kingsRoom.models.ValueObjects;

namespace kingsRoom.Application.Command.KingRoom
{
    public class KingRoomResponse : EntityMessage
    {
        public string? SelectedRoom { get; set; }
    }
}