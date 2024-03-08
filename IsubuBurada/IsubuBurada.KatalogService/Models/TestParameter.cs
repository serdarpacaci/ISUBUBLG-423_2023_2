namespace IsubuBurada.KatalogService.Models
{
    public class TestParameter
    {
        public string TCKimlikNo { get; set; }
        public string OgrenciNo { get; set; }
        public int Yas { get; set; }
    }

    public class TestResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
