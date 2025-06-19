namespace AppVulnTracker.Server.Modelos
{
    public class ArchivoAdjuntoDTO
    {
        public int id_archivo { get; set; } // ID del archivo adjunto
        public int id_vulnerabilidad { get; set; } // ID de la vulnerabilidad a la que pertenece el archivo adjunto
        public string rutaArchivo { get; set; } // Ruta del archivo adjunto en el servidor
        public string nombreArchivo { get; set; } // Nombre del archivo adjunto
        public DateTime fechaSubida { get; set; } // Fecha de subida del archivo adjunto
    }
}
