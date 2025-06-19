using AppVulnTracker.Server.Modelos;

namespace AppVulnTracker.Server.Sql
{
    public class ComentarioSQL
    {
        // Muestra toda la informacion del comentario
        public string VerComentario()
        {
            return $"select * from comentarios;";
        }

        // Muestra toda la informacion del comentario seleccionado
        public string MostrarComentarioPorId(int id_comentario)
        {
            return $"select * from comentarios where id_comentario = '{id_comentario}';";
        }

        // Crear comentario
        public string CrearComentario(ComentarioDTO comentario)
        {
            return $"insert into comentarios (id_vulnerabilidad, id_autor, contenido, fechaCreacion) values ('{comentario.id_vulnerabilidad}', '{comentario.id_autor}', " +
                $"'{comentario.contenido}', '{comentario.fechaCreacion:yyyy-MM-dd});SELECT LAST_INSERT_ID();";
        }
    }
}
