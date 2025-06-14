using System.Data.SqlClient;

namespace GarageService.Api.Infrastructure
{
    public class DbConnectionFactory
    {
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(AppSettings.ConnectionString);
        }
    }
}
