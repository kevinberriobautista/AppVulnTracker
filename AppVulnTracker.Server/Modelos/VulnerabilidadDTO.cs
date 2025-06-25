namespace AppVulnTracker.Server.Modelos
{
    public class VulnerabilidadDTO
    {
        public int id_vulnerabilidad { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int severidad { get; set; }
        public int estado { get; set; }
        public string activoAfectado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public int id_reportador { get; set; } // ID del usuario que reporta la vulnerabilidad
        public int id_revisor { get; set; } // ID del usuario que revisa la vulnerabilidad
    }
}
