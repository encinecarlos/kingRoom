using kingsRoom.models.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace kingsRoom.models
{
    public class Rooms
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string? Id { get; set; }
        public string? RoomNumber { get; set; }
        public bool Isrepeated { get; set; }
        public bool IsUsed { get; set; }
        public int DaysToNextUse { get; set; }
    }
}