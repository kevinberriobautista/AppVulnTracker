namespace AppVulnTracker.Server.Modelos
{
    public class TestVulnerabilidadDTO
    {
        public int id_testvulnerabilidad { get; set; }
        public int id_usuario { get; set; }
        public int tipo { get; set; }
        public string url { get; set; }
        public string resultado { get; set; }
        public DateTime fecha { get; set; }

        public static implicit operator int(TestVulnerabilidadDTO? v)
        {
            throw new NotImplementedException();
        }
    }
}
