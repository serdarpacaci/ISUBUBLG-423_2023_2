namespace IsubuBurada.SepetService.Models
{
    public class SepetItemDto
    {
        public Guid Id { get; set; }
        public string UrunAdi { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public bool SeciliMi { get; set; }
    }
}
