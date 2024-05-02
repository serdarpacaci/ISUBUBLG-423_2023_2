using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsubuBurada.Siparis.Domain
{
    [Table("Siparis")]
    public class Siparis : Entity<int>
    {
        public string UserId { get; set; }

        public Address Adres { get; set; }

        public DateTime SiparisTarihi { get; set; }
        public decimal SiparisTutari { get; set; }

        public List<SiparisUrunBilgi> SiparisUrunleri { get; set; }

    }
}
