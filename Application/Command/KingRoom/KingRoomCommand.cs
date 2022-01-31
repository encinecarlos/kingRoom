using System.Net;
using kingsRoom.models;
using kingsRoom.Services;
using MediatR;

namespace kingsRoom.Application.Command.KingRoom
{
    public class KingRoomCommand : IRequestHandler<KingRoomRequest, KingRoomResponse>
    {
        private readonly RoomService _RoomService;

        public KingRoomCommand(RoomService roomService)
        {
            _RoomService = roomService;
        }

        public async Task<KingRoomResponse> Handle(KingRoomRequest request, CancellationToken cancellationToken)
        {
            var result = new KingRoomResponse();

            try
            {
                var number = new Random();

                var numberRoom = number.Next(1, 100).ToString();

                var newRoom = new Rooms
                {
                    Id = Guid.NewGuid().ToString(),
                    DaysToNextUse = 30,
                    Isrepeated = false,
                    IsUsed = true,
                    RoomNumber = numberRoom
                };

                await _RoomService.CreateAsync(newRoom);

                // if (storedRoomnumber is null)
                // {

                //     var room = new Rooms
                //     {
                //         Id = Guid.NewGuid().ToString(),
                //         DaysToNextUse = 30,
                //         Isrepeated = false,
                //         IsUsed = true,
                //         RoomNumber = numberRoom
                //     };

                //     await _RoomService.CreateAsync(room);

                //     result.Message = "Room not found!";
                //     result.statuscode = 204;

                //     return await Task.FromResult(result);
                // }

                // var storedRoomnumber = await _RoomService.GetRoomByNumber(numberRoom);

                // if (storedRoomnumber.RoomNumber == numberRoom)
                // {
                //     result.Message = "This room has used";
                //     result.statuscode = 200;

                //     return await Task.FromResult(result);
                // }

                result.SelectedRoom = numberRoom;
                result.statuscode = (int)HttpStatusCode.OK;
                result.Message = "Success";

                return await Task.FromResult(result);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}