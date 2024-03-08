using MongoDB.Bson.Serialization.Attributes;

namespace IsubuBurada.KatalogService.Models
{
    public class Urun
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Ad { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal Fiyat { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime EklenmeTarihi { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime? GuncellenmeTarihi { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string KategoriId { get; set; }

        [BsonIgnore]
        public Kategori KategoriFk { get; set; }
    }
}
