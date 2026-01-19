using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AutoMarket.Models
{
    public class Avis
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public int AnnonceId { get; set; }

        
        public string Auteur { get; set; } = string.Empty;

        
        public int Note { get; set; }

        public string Commentaire { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
