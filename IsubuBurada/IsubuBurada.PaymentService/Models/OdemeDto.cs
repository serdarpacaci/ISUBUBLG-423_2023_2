namespace IsubuBurada.PaymentService.Models
{
    public class OdemeDto
    {
        public string CardName { get; set; }
        public string CardNumarasi { get; set; }
        public string Ay { get; set; }
        public string Yil { get; set; }
        public string Cv2 { get; set; }
        public decimal ToplamTutar { get; set; }

        public SiparisDto Siparis { get; set; }
    }
}
