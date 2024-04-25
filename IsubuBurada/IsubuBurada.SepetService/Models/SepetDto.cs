namespace IsubuBurada.SepetService.Models
{
    public class SepetDto
    {
        public string UserId { get; set; }

        public List<SepetItemDto> Urunler { get; set; }
        public decimal SepetTutari => Urunler
            .Where(x => x.SeciliMi)
            .Sum(x => x.Adet * x.Fiyat);

        public SepetDto()
        {
            Urunler = new List<SepetItemDto>();
        }

    }
}
