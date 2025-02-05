using Microsoft.Data.Sqlite;
using TaskManager.Model.DTOs;
using TaskManager.Model.Entities;
using TaskManager.Model.Helpers;

namespace TaskManager.Model.Repository
{
    public class TasksRepository : ITasksRepository
    {
        private readonly IDatabaseHelper _databaseHelper;

        public TasksRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public async Task<IEnumerable<Tasks>> GetAll(TaskFilter filters)
        {
            try
            {
                var (query, countQuery, parameters) = FilterHelper.BuildTaskQuery(filters);

                using (var connection = _databaseHelper.GetConnection())
                {
                    await connection.OpenAsync();

                    var items = new List<Tasks>();

                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters.ToArray());

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var task = new Tasks
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Username = reader.GetString(reader.GetOrdinal("Username")), 
                                    UserId = reader.GetInt32(reader.GetOrdinal("UserId")), 
                                    StateName = reader.GetString(reader.GetOrdinal("StateName")), 
                                    StateId = reader.GetInt32(reader.GetOrdinal("StateId")), 
                                    PriorityName = reader.GetString(reader.GetOrdinal("PriorityName")),
                                    PriorityId = reader.GetInt32(reader.GetOrdinal("PriorityId")),
                                    DueDate = reader.GetDateTime(reader.GetOrdinal("DueDate")),
                                    Description = reader.GetString(reader.GetOrdinal("Description")),
                                    Notes = reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.GetString(reader.GetOrdinal("Notes"))
                                };

                                items.Add(task);
                            }
                        }
                    }

                    using (var countCommand = new SqliteCommand(countQuery, connection))
                    {
                        foreach (var parameter in parameters)
                        {
                            if (parameter.ParameterName != "@Take" && parameter.ParameterName != "@Skip")
                            {
                                countCommand.Parameters.Add(parameter);
                            }
                        }

                        var totalCount = Convert.ToInt32(await countCommand.ExecuteScalarAsync());
                        return items;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching filtered tasks: {ex.Message}", ex);
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = _databaseHelper.GetConnection())
            {
                const string query = "DELETE FROM Tasks WHERE id = @Id";
                using (var command = new SqliteCommand(query, connection))
                {
                    await connection.OpenAsync();
                    command.Parameters.AddWithValue("@Id", id);
                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        public async Task<Tasks> GetById(int id)
        {
            using (var connection = _databaseHelper.GetConnection())
            {
                const string query = "SELECT Id FROM Tasks WHERE Id = @Id";
                using (var command = new SqliteCommand(query, connection))
                {
                    await connection.OpenAsync();
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Tasks();
                        }
                    }
                }
            }

            throw new KeyNotFoundException($"Task with ID {id} was not found.");
        }

        public async Task<bool> Insert(Tasks entity)
        {
            using (var connection = _databaseHelper.GetConnection())
            {
                const string query = @"
                    INSERT INTO Tasks (Description, UserId, StateId, PriorityId, DueDate, Notes) 
                    VALUES (@Description, @UserId, @StateId, @PriorityId, @DueDate, @Notes)";
                using (var command = new SqliteCommand(query, connection))
                {
                    await connection.OpenAsync();
                    command.Parameters.AddWithValue("@Description", entity.Description);
                    command.Parameters.AddWithValue("@UserId", entity.UserId);
                    command.Parameters.AddWithValue("@StateId", entity.StateId);
                    command.Parameters.AddWithValue("@PriorityId", entity.PriorityId);
                    command.Parameters.AddWithValue("@DueDate", entity.DueDate);
                    command.Parameters.AddWithValue("@Notes", (object)entity.Notes ?? DBNull.Value);

                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        public async Task<bool> Update(Tasks entity)
        {
            using (var connection = _databaseHelper.GetConnection())
            {
                const string query = @"
                    UPDATE Tasks
                    SET Description = @Description, UserId = @UserId, StateId = @StateId, PriorityId = @PriorityId, DueDate = @DueDate, Notes = @Notes
                    WHERE Id = @Id";
                using (var command = new SqliteCommand(query, connection))
                {
                    await connection.OpenAsync();
                    command.Parameters.AddWithValue("@Id", entity.Id);
                    command.Parameters.AddWithValue("@Description", entity.Description);
                    command.Parameters.AddWithValue("@UserId", entity.UserId);
                    command.Parameters.AddWithValue("@StateId", entity.StateId);
                    command.Parameters.AddWithValue("@PriorityId", entity.PriorityId);
                    command.Parameters.AddWithValue("@DueDate", entity.DueDate);
                    command.Parameters.AddWithValue("@Notes", (object)entity.Notes ?? DBNull.Value);

                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        public async Task<IEnumerable<Tasks>> GetAll()
        {
            var tasks = new List<Tasks>();

            using (var connection = _databaseHelper.GetConnection())
            {
                const string query = "SELECT * FROM Tasks";
                using (var command = new SqliteCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            tasks.Add(new Tasks
                            {
                                Id = reader.GetInt32(0),
                                Description = reader.GetString(1),
                                UserId = reader.GetInt32(2),
                                StateId = reader.GetInt32(3),
                                PriorityId = reader.GetInt16(4),
                                DueDate = reader.GetDateTime(5),
                                Notes = reader.IsDBNull(6) ? null : reader.GetString(6),
                                CreationDate = reader.GetDateTime(7)
                            });
                        }
                    }
                }
            }

            return tasks;
        }

    }
}
