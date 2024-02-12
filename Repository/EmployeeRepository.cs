using Dapper;
using MySql.Data.MySqlClient;
using TestNetCore_Castor.Entities;


namespace TestNetCore_Castor.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public EmployeeRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected async Task<MySqlConnection> OpenConnectionAsync()
        {
            var connection = new MySqlConnection(_connectionString.ConnectionString);
            await connection.OpenAsync();
            return connection;
        }

        public async Task<bool> Insert(Employee employee)
        {
            using (var db = await OpenConnectionAsync())
            {
                var query = @"
                INSERT INTO Employee (Identification, Name, Photo, HireDate, PositionId)
                VALUES (@Identification, @Name, @Photo, @HireDate, @PositionId);
                SELECT LAST_INSERT_ID();";

                var lastInsertId = await db.ExecuteScalarAsync<int>(query, new
                {
                    Identification = employee.Identification,
                    Name = employee.Name,
                    Photo = employee.Photo,
                    HireDate = employee.HireDate,
                    PositionId = employee.PositionId
                });

                return lastInsertId > 0;
            }
        }


        public async Task<bool> UpdateEmployeeById(int id, Employee employee)
        {
            using (var db = await OpenConnectionAsync())
            {
                var query = @"
        UPDATE Employee 
        SET Identification = @Identification, 
            Name = @Name, 
            Photo = @Photo, 
            HireDate = @HireDate, 
            PositionId = @PositionId
        WHERE Id = @Id;";

                var result = await db.ExecuteAsync(query, new
                {
                    Identification = employee.Identification,
                    Name = employee.Name,
                    Photo = employee.Photo,
                    HireDate = employee.HireDate,
                    PositionId = employee.PositionId,
                    Id = id
                });

                return result > 0;
            }
        }


        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                using (var db = await OpenConnectionAsync())
                {
                    var query = @"
               SELECT Id, Identification, Photo,Name, HireDate, PositionId FROM Employee LIMIT 0, 1000;";

                    return (await db.QueryAsync<Employee>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EmployeeRepository.GetAllEmployees: {ex.Message}");
                return null;
            }
        }

        public async Task<Employee> GetById(int id)
        {
            try
            {
                using (var db = await OpenConnectionAsync())
                {
                    var query = @"
                SELECT Id, Identification, Name, Photo, HireDate, PositionId
                FROM Employee
                WHERE Id = @Id;";

                    return await db.QueryFirstOrDefaultAsync<Employee>(query, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EmployeeRepository.GetById: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteEmployeeById(int id)
        {
            try
            {
                using (var db = await OpenConnectionAsync())
                {
                    var query = @"
                    DELETE FROM Employee
                    WHERE Id = @Id;";

                    var result = await db.ExecuteAsync(query, new { Id = id });
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in EmployeeRepository.DeleteEmployeeById: {ex.Message}");
                return false;
            }
        }

    }
}