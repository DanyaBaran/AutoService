using System.Data.SqlClient;
using AutoService.Shared.Models;
using RepairService.Api.Interfaces;
using RepairService.Api.Infrastructure;

namespace RepairService.Api.Repositories
{
    public class RepairRepository : IRepairRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public RepairRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        private Repair MapReaderToRepair(SqlDataReader reader)
        {
            return new Repair
            {
                IdRepair = reader.GetInt32(reader.GetOrdinal("IdRepair")),
                EmployeeId = reader.GetInt32(reader.GetOrdinal("EmployeesId")),
                CarId = reader.GetInt32(reader.GetOrdinal("CarId")),
                ContactOwner = reader.IsDBNull(reader.GetOrdinal("ContactOwner")) ? null : reader.GetString(reader.GetOrdinal("ContactOwner")),
                DateBegin = reader.GetDateTime(reader.GetOrdinal("DateBegin")),
                DateEnd = reader.IsDBNull(reader.GetOrdinal("DateEnd"))
                            ? (DateTime?)null
                            : reader.GetDateTime(reader.GetOrdinal("DateEnd"))
            };
        }

        public Repair GetById(int id)
        {
            Repair repair = null;
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "SELECT IdRepair, EmployeesId, CarId, ContactOwner, DateBegin, DateEnd FROM Repairs WHERE IdRepair = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            repair = MapReaderToRepair(reader);
                        }
                    }
                }
            }
            return repair;
        }

        public IEnumerable<Repair> GetAll()
        {
            var repairs = new List<Repair>();
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "SELECT IdRepair, EmployeesId, CarId, ContactOwner, DateBegin, DateEnd FROM Repairs";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            repairs.Add(MapReaderToRepair(reader));
                        }
                    }
                }
            }
            return repairs;
        }

        public void Add(Repair repair)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "INSERT INTO Repairs (EmployeesId, CarId, ContactOwner, DateBegin, DateEnd) VALUES (@EmployeeId, @CarId, @ContactOwner, @DateBegin, @DateEnd)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", repair.EmployeeId);
                    command.Parameters.AddWithValue("@CarId", repair.CarId);
                    command.Parameters.AddWithValue("@ContactOwner", repair.ContactOwner);
                    command.Parameters.AddWithValue("@DateBegin", repair.DateBegin);
                    if (repair.DateEnd.HasValue)
                    {
                        command.Parameters.AddWithValue("@DateEnd", repair.DateEnd.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@DateEnd", DBNull.Value);
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Repair repair)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "UPDATE Repairs SET EmployeesId = @EmployeeId, CarId = @CarId, ContactOwner = @ContactOwner, DateBegin = @DateBegin, DateEnd = @DateEnd WHERE IdRepair = @IdRepair";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", repair.EmployeeId);
                    command.Parameters.AddWithValue("@CarId", repair.CarId);
                    command.Parameters.AddWithValue("@ContactOwner", repair.ContactOwner);
                    command.Parameters.AddWithValue("@DateBegin", repair.DateBegin);
                    if (repair.DateEnd.HasValue)
                    {
                        command.Parameters.AddWithValue("@DateEnd", repair.DateEnd.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@DateEnd", DBNull.Value);
                    }
                    command.Parameters.AddWithValue("@IdRepair", repair.IdRepair);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "DELETE FROM Repairs WHERE IdRepair = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Repair> SearchRepairs(string searchQuery)
        {
            var repairs = new List<Repair>();
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = @"
                    SELECT IdRepair, EmployeesId, CarId, ContactOwner, DateBegin, DateEnd
                    FROM Repairs
                    WHERE 
                        ContactOwner LIKE @SearchQuery OR 
                        CAST(EmployeesId AS NVARCHAR(MAX)) LIKE @SearchQuery OR 
                        CAST(CarId AS NVARCHAR(MAX)) LIKE @SearchQuery OR 
                        CONVERT(NVARCHAR, DateBegin, 104) LIKE @SearchQuery OR 
                        CONVERT(NVARCHAR, DateEnd, 104) LIKE @SearchQuery";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            repairs.Add(new Repair
                            {
                                IdRepair = reader.GetInt32(0),
                                EmployeeId = reader.GetInt32(1),
                                CarId = reader.GetInt32(2),
                                ContactOwner = reader.GetString(3),
                                DateBegin = reader.GetDateTime(4),
                                DateEnd = reader.GetDateTime(5)
                            });
                        }
                    }
                }
            }
            return repairs;
        }
    }
}
