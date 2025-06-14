using RepairService.Api.Interfaces;
using AutoService.Shared.Models;
using System.Data.SqlClient;
using RepairService.Api.Infrastructure;

namespace RepairService.Api.Repositories
{
    public class RepairInfoRepository : IRepairInfoRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public RepairInfoRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public RepairInfo GetById(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "SELECT RepairId, AssemblyId, AmountPrice, CoefDifficult FROM RepairInfos WHERE RepairId = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new RepairInfo
                            {
                                RepairId = reader.GetInt32(0),
                                AssemblyId = reader.GetInt32(1),
                                AmountPrice = reader.GetInt32(2),
                                CoefDifficult = reader.GetInt32(3)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public IEnumerable<RepairInfo> GetAll()
        {
            var repairInfos = new List<RepairInfo>();
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "SELECT RepairId, AssemblyId, AmountPrice, CoefDifficult FROM RepairInfos";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            repairInfos.Add(new RepairInfo
                            {
                                RepairId = reader.GetInt32(0),
                                AssemblyId = reader.GetInt32(1),
                                AmountPrice = reader.GetInt32(2),
                                CoefDifficult = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            return repairInfos;
        }

        public void Add(RepairInfo repairInfo)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "INSERT INTO RepairInfos (RepairId, AssemblyId, AmountPrice, CoefDifficult) VALUES (@RepairId, @AssemblyId, @AmountPrice, @CoefDifficult)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RepairId", repairInfo.RepairId);
                    command.Parameters.AddWithValue("@AssemblyId", repairInfo.AssemblyId);
                    command.Parameters.AddWithValue("@AmountPrice", repairInfo.AmountPrice);
                    command.Parameters.AddWithValue("@CoefDifficult", repairInfo.CoefDifficult);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(RepairInfo repairInfo)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "UPDATE RepairInfos SET AssemblyId = @AssemblyId, AmountPrice = @AmountPrice, CoefDifficult = @CoefDifficult WHERE RepairId = @RepairId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RepairId", repairInfo.RepairId);
                    command.Parameters.AddWithValue("@AssemblyId", repairInfo.AssemblyId);
                    command.Parameters.AddWithValue("@AmountPrice", repairInfo.AmountPrice);
                    command.Parameters.AddWithValue("@CoefDifficult", repairInfo.CoefDifficult);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "DELETE FROM RepairInfos WHERE RepairId = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<RepairInfo> SearchRepairInfos(string searchQuery)
        {
            var repairInfos = new List<RepairInfo>();
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = @"
                    SELECT RepairId, AssemblyId, AmountPrice, CoefDifficult 
                    FROM RepairInfos 
                    WHERE 
                        CAST(RepairId AS NVARCHAR(MAX)) LIKE @SearchQuery OR 
                        CAST(AssemblyId AS NVARCHAR(MAX)) LIKE @SearchQuery OR 
                        CAST(AmountPrice AS NVARCHAR(MAX)) LIKE @SearchQuery OR 
                        CAST(CoefDifficult AS NVARCHAR(MAX)) LIKE @SearchQuery";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            repairInfos.Add(new RepairInfo
                            {
                                RepairId = reader.GetInt32(0),
                                AssemblyId = reader.GetInt32(1),
                                AmountPrice = reader.GetInt32(2),
                                CoefDifficult = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            return repairInfos;
        }
    }
}
