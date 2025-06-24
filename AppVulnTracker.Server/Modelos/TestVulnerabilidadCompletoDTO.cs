namespace AppVulnTracker.Server.Modelos
{
    public class TestVulnerabilidadCompletoDTO
    {
        public int id_testvulnerabilidad { get; set; }
        public int id_usuario { get; set; }
        public int tipo { get; set; }
        public string url { get; set; }
        public string resultado { get; set; }
        public DateTime fecha { get; set; }
        public string nombre_usuario { get; set; }
        public string nombre_tipo { get; set; }
    }
}
