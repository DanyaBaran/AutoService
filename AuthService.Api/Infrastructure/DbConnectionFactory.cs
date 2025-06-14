using System.Data.SqlClient;

namespace AuthService.Api.Infrastructure
{
    public class DbConnectionFactory
    {
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(AppSettings.ConnectionString);
        }
    }
}
