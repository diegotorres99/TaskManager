using Microsoft.Data.Sqlite;
using TaskManager.Model.DTOs;
using TaskManager.Model.Helpers;

namespace TaskManager.Model.Repository
{
    public class StateRepository : IStatesRepository
    {
        private readonly IDatabaseHelper _databaseHelper;

        public StateRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public async Task<IEnumerable<StateDto>> GetAll()
        {
            var states = new List<StateDto>();

            try
            {
                using (var connection = _databaseHelper.GetConnection())
                {
                    await connection.OpenAsync();

                    const string query = "SELECT Id, Name FROM States";

                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                states.Add(new StateDto
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
                throw new Exception($"Error fetching states: {ex.Message}", ex);
            }

            return states;
        }
    }
}
