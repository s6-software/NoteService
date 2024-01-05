using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Models
{
    public class Block
    {
        public string type { get; set; } = null!;
        public object data { get; set; } = null!;
    }
    public class Note
        {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public List<Block> Blocks { get; set; } = new List<Block>();
    }
}
