using MongoDB.Bson.Serialization.Attributes;

namespace TestMongoCRUDwithDotNet8.Models
{
    public class Address
    {
        [BsonElement("PresentAddress")]
        public string PresentAddress { get; set; }

        [BsonElement("PermanentAddress")]
        public string PermanentAddress { get; set; }
    }
}
