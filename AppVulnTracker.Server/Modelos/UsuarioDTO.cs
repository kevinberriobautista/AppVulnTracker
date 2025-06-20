namespace AppVulnTracker.Server.Modelos
{
    public class UsuarioDTO
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public int rol { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string token { get; set; }
    }
}
