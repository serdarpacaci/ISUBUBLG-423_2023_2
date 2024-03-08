namespace IsubuBurada.KatalogService.Dtos
{
    public class CreateOrEditUrunDto
    {
        public string? Id { get; set; }

        public string Ad { get; set; }

        public decimal Fiyat { get; set; }
        public string KategoriId { get; set; }
    }
}
