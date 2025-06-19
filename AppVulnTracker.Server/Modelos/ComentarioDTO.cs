namespace AppVulnTracker.Server.Modelos
{
    public class Comentario
    {
        public int id_comentario { get; set; }
        public int id_vulnerabilidad { get; set; } // ID de la vulnerabilidad a la que pertenece el comentario
        public int id_autor { get; set; } // ID del usuario que hizo el comentario
        public string contenido { get; set; } // Contenido del comentario   
        public DateTime fechaCreacion { get; set; } // Fecha de creación del comentario
    }
}
