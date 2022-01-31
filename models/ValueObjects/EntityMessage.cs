namespace kingsRoom.models.ValueObjects
{
    public abstract class EntityMessage
    {
        public int statuscode { get; set; }
        public string? Message { get; set; }
    }
}