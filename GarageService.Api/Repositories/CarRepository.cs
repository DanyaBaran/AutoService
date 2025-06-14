using GarageService.Api.Interfaces;
using AutoService.Shared.Models;
using System.Data.SqlClient;
using GarageService.Api.Infrastructure;

namespace GarageService.Api.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public CarRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Car GetById(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "SELECT IdCar, NameMark, NameModel, DateReleaseCar FROM Cars WHERE IdCar = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Car
                            {
                                IdCar = reader.GetInt32(0),
                                NameMark = reader.GetString(1),
                                NameModel = reader.GetString(2),
                                DateReleaseCar = reader.GetDateTime(3)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public IEnumerable<Car> GetAll()
        {
            var cars = new List<Car>();
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "SELECT IdCar, NameMark, NameModel, DateReleaseCar FROM Cars";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cars.Add(new Car
                            {
                                IdCar = reader.GetInt32(0),
                                NameMark = reader.GetString(1),
                                NameModel = reader.GetString(2),
                                DateReleaseCar = reader.GetDateTime(3)
                            });
                        }
                    }
                }
            }
            return cars;
        }

        public void Add(Car car)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "INSERT INTO Cars (NameMark, NameModel, DateReleaseCar) VALUES (@NameMark, @NameModel, @DateReleaseCar)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NameMark", car.NameMark);
                    command.Parameters.AddWithValue("@NameModel", car.NameModel);
                    command.Parameters.AddWithValue("@DateReleaseCar", car.DateReleaseCar);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Car car)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "UPDATE Cars SET NameMark = @NameMark, NameModel = @NameModel, DateReleaseCar = @DateReleaseCar WHERE IdCar = @IdCar";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NameMark", car.NameMark);
                    command.Parameters.AddWithValue("@NameModel", car.NameModel);
                    command.Parameters.AddWithValue("@DateReleaseCar", car.DateReleaseCar);
                    command.Parameters.AddWithValue("@IdCar", car.IdCar);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "DELETE FROM Cars WHERE IdCar = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Car> SearchCars(string searchQuery)
        {
            var cars = new List<Car>();
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = @"
                    SELECT IdCar, NameMark, NameModel, DateReleaseCar 
                    FROM Cars 
                    WHERE
                        IdCar LIKE @SearchQuery OR
                        NameMark LIKE @SearchQuery OR 
                        NameModel LIKE @SearchQuery OR
                        CONVERT(NVARCHAR, DateReleaseCar, 104) LIKE @SearchQuery";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cars.Add(new Car
                            {
                                IdCar = reader.GetInt32(0),
                                NameMark = reader.GetString(1),
                                NameModel = reader.GetString(2),
                                DateReleaseCar = reader.GetDateTime(3)
                            });
                        }
                    }
                }
            }
            return cars;
        }
    }
}
