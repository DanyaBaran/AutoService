using GarageService.Api.Interfaces;
using AutoService.Shared.Models;
using System.Data.SqlClient;
using GarageService.Api.Infrastructure;

namespace GarageService.Api.Repositories
{
    public class AssemblyRepository : IAssemblyRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public AssemblyRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Assembly GetById(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "SELECT IdAssembly, NameAssembly, PriceAssembly, Description FROM Assemblys WHERE IdAssembly = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Assembly
                            {
                                IdAssembly = reader.GetInt32(0),
                                NameAssembly = reader.GetString(1),
                                PriceAssembly = reader.GetInt32(2),
                                Description = reader.GetString(3)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public IEnumerable<Assembly> GetAll()
        {
            var assemblys = new List<Assembly>();
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "SELECT IdAssembly, NameAssembly, PriceAssembly, Description FROM Assemblys";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            assemblys.Add(new Assembly
                            {
                                IdAssembly = reader.GetInt32(0),
                                NameAssembly = reader.GetString(1),
                                PriceAssembly = reader.GetInt32(2),
                                Description = reader.GetString(3)
                            });
                        }
                    }
                }
            }
            return assemblys;
        }

        public void Add(Assembly assembly)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "INSERT INTO Assemblys (NameAssembly, PriceAssembly, Description) VALUES (@NameAssembly, @PriceAssembly, @Description)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NameAssembly", assembly.NameAssembly);
                    command.Parameters.AddWithValue("@PriceAssembly", assembly.PriceAssembly);
                    command.Parameters.AddWithValue("@Description", assembly.Description);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Assembly assembly)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "UPDATE Assemblys SET NameAssembly = @NameAssembly, PriceAssembly = @PriceAssembly, Description = @Description WHERE IdAssembly = @IdAssembly";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NameAssembly", assembly.NameAssembly);
                    command.Parameters.AddWithValue("@PriceAssembly", assembly.PriceAssembly);
                    command.Parameters.AddWithValue("@Description", assembly.Description);
                    command.Parameters.AddWithValue("@IdAssembly", assembly.IdAssembly);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "DELETE FROM Assemblys WHERE IdAssembly = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Assembly> SearchAssemblys(string searchQuery)
        {
            var assemblys = new List<Assembly>();
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = @"
                    SELECT IdAssembly, NameAssembly, PriceAssembly, Description 
                    FROM Assemblys 
                    WHERE
                        IdAssembly LIKE @SearchQuery OR
                        NameAssembly LIKE @SearchQuery OR 
                        PriceAssembly LIKE @SearchQuery OR
                        Description LIKE @SearchQuery";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            assemblys.Add(new Assembly
                            {
                                IdAssembly = reader.GetInt32(0),
                                NameAssembly = reader.GetString(1),
                                PriceAssembly = reader.GetInt32(2),
                                Description = reader.GetString(3)
                            });
                        }
                    }
                }
            }
            return assemblys;
        }
    }
}
