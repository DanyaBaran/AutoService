using System.Data.SqlClient;

namespace RepairService.Api.Infrastructure
{
    public class DbConnectionFactory
    {
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(AppSettings.ConnectionString);
        }
    }
}
