using kingsRoom.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace kingsRoom.Services
{
    public class RoomService
    {
        private readonly IMongoCollection<Rooms> _RoomsCollection;

        public RoomService(IOptions<KingRoomDatabaseSettings> dbSettings)
        {
            var dbclient = new MongoClient(dbSettings.Value.BaseUrl);

            var database = dbclient.GetDatabase(dbSettings.Value.DatabaseName);

            _RoomsCollection = database.GetCollection<Rooms>(dbSettings.Value.roomcollection);
        }

        public async Task<Rooms> GetRoomByNumber(string roomNumber) =>
            await _RoomsCollection.Find(r => r.RoomNumber == roomNumber).FirstOrDefaultAsync();

        public async Task CreateAsync(Rooms room) => await _RoomsCollection.InsertOneAsync(room);
    }
}