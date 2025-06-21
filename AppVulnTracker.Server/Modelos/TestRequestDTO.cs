namespace AppVulnTracker.Server.Modelos
{
    public class TestRequestDTO
    {
        public string url { get; set; }
        public int tipo { get; set; } // "xss", "sqli", etc.
        public int id_usuario { get; set; }
    }
}
