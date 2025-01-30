using Microsoft.Data.Sqlite;
using TaskManager.Model.DTOs;
using TaskManager.Model.Helpers;

namespace TaskManager.Model.Repository
{
    public class PrioritiesRepository : IPrioritiesRepository
    {
        private readonly IDatabaseHelper _databaseHelper;

        public PrioritiesRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public async Task<IEnumerable<PriorityDto>> GetAll()
        {
            var priorities = new List<PriorityDto>();

            try
            {
                using (var connection = _databaseHelper.GetConnection())
                {
                    await connection.OpenAsync();

                    const string query = "SELECT Id, Name FROM Priorities";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                priorities.Add(new PriorityDto
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching priorities: {ex.Message}", ex);
            }

            return priorities;
        }
    }
}
