using HemenBiletProje.Models;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HemenBiletProje.Repositories
{
    public class UserRepository
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=FlightReservationDB;Integrated Security=True;";

        // Login işlemi
        public async Task<User> LoginAsync(string username, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", username);
                command.Parameters.AddWithValue("@Password", password);

                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    reader.Read();
                    return new User
                    {
                        UserId = reader.GetInt32(reader.GetOrdinal("Id")),
                        UserName = reader.GetString(reader.GetOrdinal("UserName")),
                        Password = reader.GetString(reader.GetOrdinal("Password"))
                    };
                }
            }

            return null;
        }

        // Kullanıcı kaydetme işlemi
        public async Task<bool> RegisterAsync(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Users (UserName, Password) VALUES (@UserName, @Password)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Phone", user.Phone);

                await connection.OpenAsync();
                var result = await command.ExecuteNonQueryAsync();

                return result > 0;
            }
        }
    }
}
