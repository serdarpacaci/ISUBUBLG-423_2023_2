using IsubuBurada.KatalogService.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace IsubuBurada.KatalogService.Dtos
{
    public class KategoriDto
    {
        public string Id { get; set; }

        public string Ad { get; set; }
    }
}
