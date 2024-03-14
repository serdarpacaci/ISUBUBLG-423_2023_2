using System.ComponentModel.DataAnnotations;

namespace IsubuBurada.IdentityServer.Models
{
    public class KullaniciKayitDto
    {
        [Required]
        public string KullaniciAdi { get; set; }

        [Required]
        [EmailAddress]
        public string EPosta { get; set; }

        [Required]
        public string Sifre { get; set; }
    }
}
