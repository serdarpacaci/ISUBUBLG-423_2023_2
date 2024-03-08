namespace IsubuBurada.KatalogService.Dtos
{
    public class UrunDto
    {
        public string Id { get; set; }

        public string Ad { get; set; }

        public decimal Fiyat { get; set; }

        public DateTime EklenmeTarihi { get; set; }

        public DateTime? GuncellenmeTarihi { get; set; }

        public string KategoriId { get; set; }

    }
}
