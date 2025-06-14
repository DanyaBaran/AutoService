using RepairService.Api.Interfaces;
using AutoService.Shared.Models;
using System.Data.SqlClient;
using RepairService.Api.Infrastructure;

namespace RepairService.Api.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        public EmployeeRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Employee GetById(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "SELECT IdEmployee, Name, Address, Phone, EmploymentDate, Salary FROM Employees WHERE IdEmployee = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Employee
                            {
                                IdEmployee = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Address = reader.GetString(2),
                                Phone = reader.GetString(3),
                                EmploymentDate = reader.GetDateTime(4),
                                Salary = reader.GetInt32(5)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = new List<Employee>();
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "SELECT IdEmployee, Name, Address, Phone, EmploymentDate, Salary FROM Employees";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                IdEmployee = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Address = reader.GetString(2),
                                Phone = reader.GetString(3),
                                EmploymentDate = reader.GetDateTime(4),
                                Salary = reader.GetInt32(5)
                            });
                        }
                    }
                }
            }
            return employees;
        }

        public void Add(Employee employee)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "INSERT INTO Employees (Name, Address, Phone, EmploymentDate, Salary) VALUES (@Name, @Address, @Phone, @EmploymentDate, @Salary)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Phone", employee.Phone);
                    command.Parameters.AddWithValue("@EmploymentDate", employee.EmploymentDate);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Employee employee)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "UPDATE Employees SET Name = @Name, Address = @Address, Phone = @Phone, EmploymentDate = @EmploymentDate, Salary = @Salary WHERE IdEmployee = @IdEmployee";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Address", employee.Address);
                    command.Parameters.AddWithValue("@Phone", employee.Phone);
                    command.Parameters.AddWithValue("@EmploymentDate", employee.EmploymentDate);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@IdEmployee", employee.IdEmployee);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = "DELETE FROM Employees WHERE IdEmployee = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Employee> SearchEmployees(string searchQuery)
        {
            var employees = new List<Employee>();
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Open();
                string query = @"
                    SELECT IdEmployee, Name, Address, Phone, EmploymentDate, Salary 
                    FROM Employees 
                    WHERE 
                        Name LIKE @SearchQuery OR 
                        Address LIKE @SearchQuery OR
                        Phone LIKE @SearchQuery OR 
                        CONVERT(NVARCHAR, EmploymentDate, 104) LIKE @SearchQuery OR
                        Salary LIKE @SearchQuery";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                IdEmployee = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Address = reader.GetString(2),
                                Phone = reader.GetString(3),
                                EmploymentDate = reader.GetDateTime(4),
                                Salary = reader.GetInt32(5)
                            });
                        }
                    }
                }
            }
            return employees;
        }
    }
}
