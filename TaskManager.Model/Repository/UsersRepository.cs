using Microsoft.Data.Sqlite;
using TaskManager.Model.DTOs;
using TaskManager.Model.Helpers;

namespace TaskManager.Model.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDatabaseHelper _databaseHelper;
        public UsersRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = new List<UserDto>();

            try
            {
                using (var connection = _databaseHelper.GetConnection())
                {
                    await connection.OpenAsync();

                    const string query = "SELECT Id, Name FROM Users";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                users.Add(new UserDto
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching users: {ex.Message}", ex);
            }

            return users;
        }
    }
}
