using IsubuBurada.Siparis.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuBurada.Siparis.Application.Commands.Dtos
{
    public class CreateSiparisDto : EntityDto<int>
    {

    }

    public class SiparisItemDto : EntityDto<int>
    {
        public Guid UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string FotografUrl { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
    }

    public class AddressDto : EntityDto<int>
    {
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string Mahalle { get; set; }
        public string Cadde { get; set; }
        public string BinaNo { get; set; }
        public string DaireNo { get; set; }
    }
}
