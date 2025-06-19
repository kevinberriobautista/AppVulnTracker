using AppVulnTracker.Server.Modelos;

namespace AppVulnTracker.Server.Sql
{
    public class ArchivoAdjuntoSQL
    {
        // Muestra toda la informacion del archivo adjunto
        public string VerArchivo()
        {
            return $"select * from archivosadjuntos;";
        }

        // Muestra toda la informacion del archivo adjunto seleccionado
        public string MostrarArchivoPorId(int id_archivo)
        {
            return $"select * from archivosadjuntos where id_cliente = '{id_archivo}';";
        }

        // Crea un archivo adjunto
        public string CrearArchivo(ArchivoAdjuntoDTO archivo)
        {
            return $"insert into archivosadjuntos (id_vulnerabilidad, rutaArchivo, nombreArchivo, fechaSubida) values ('{archivo.id_vulnerabilidad}', " +
                $"'{archivo.rutaArchivo}', '{archivo.nombreArchivo}', '{archivo.fechaSubida:yyyy-MM-dd}');SELECT LAST_INSERT_ID();";
        }
    }
}
