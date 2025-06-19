using System.Data;
using MySql.Data.MySqlClient;

namespace AppVulnTracker.Server.Utilidades
{
    public class AplicationDbContext
    {
        public readonly IConfiguration _configuration;
        public readonly IDbConnection _connection;
        public AplicationDbContext(IConfiguration configuration)
        {

            _configuration = configuration;
            _connection = CreateConnection();
        }

        private IDbConnection CreateConnection()
        {
            IDbConnection connection = null;
            var connectionString = _configuration.GetConnectionString("conexion");

            connection = new MySqlConnection(connectionString);

            return connection;
        }
    }
}
