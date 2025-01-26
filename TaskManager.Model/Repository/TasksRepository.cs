using Microsoft.Data.Sqlite;
using System.Data;
using TaskManager.Model.DTOs;
using TaskManager.Model.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManager.Model.Repository
{
    public class TasksRepository : IGenericRepository<TaskDto>
    {
        private readonly IDatabaseHelper _databaseHelper;

        public TasksRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = _databaseHelper.GetConnection())
            {
                const string query = "DELETE FROM Tasks WHERE id = @Id";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        public async Task<IEnumerable<TaskDto>> GetAll()
        {
            var tasks = new List<TaskDto>();

            using (var connection = _databaseHelper.GetConnection())
            {
                const string query = "SELECT Id, Description, UserId, StateId, Priority, DueDate, Notes, CreationDate FROM Tasks";
                using (var command = new SqliteCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            tasks.Add(new TaskDto
                            {
                                Id = reader.GetInt32(0),
                                Description = reader.GetString(1),
                                UserId = reader.GetInt32(2),
                                StateId = reader.GetInt32(3),
                                Priority = reader.GetString(4),
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

        public async Task<TaskDto> GetById(int id)
        {
            using (var connection = _databaseHelper.GetConnection())
            {
                const string query = "SELECT Id, Description, UserId, StateId, Priority, DueDate, Notes, CreationDate FROM Tasks WHERE Id = @Id";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new TaskDto
                            {
                                Id = reader.GetInt32(0),
                                Description = reader.GetString(1),
                                UserId = reader.GetInt32(2),
                                StateId = reader.GetInt32(3),
                                Priority = reader.GetString(4),
                                DueDate = reader.GetDateTime(5),
                                Notes = reader.IsDBNull(6) ? null : reader.GetString(6),
                                CreationDate = reader.GetDateTime(7)
                            };
                        }
                    }
                }
            }

            throw new KeyNotFoundException($"Task with ID {id} was not found.");
        }

        public async Task<(IEnumerable<object> Items, int TotalCount)> GetOrderTasksAsync(int skip, int take, string sortField, bool sortAscending)
        {
            if (string.IsNullOrEmpty(sortField))
            {
                throw new ArgumentException("Sort field cannot be null or empty.");
            }

            var tasks = new List<TaskDto>();
            string sortOrder = sortAscending ? "ASC" : "DESC";
            string query = $@"
                SELECT Id, Description, UserId, StateId, Priority, DueDate, Notes, CreationDate
                FROM Tasks
                ORDER BY {sortField} {sortOrder}
                LIMIT @Take OFFSET @Skip;

                SELECT COUNT(*) FROM Tasks;
            ";

            using (var connection = _databaseHelper.GetConnection())
            {
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Take", take);
                    command.Parameters.AddWithValue("@Skip", skip);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            tasks.Add(new TaskDto
                            {
                                Id = reader.GetInt32(0),
                                Description = reader.GetString(1),
                                UserId = reader.GetInt32(2),
                                StateId = reader.GetInt32(3),
                                Priority = reader.GetString(4),
                                DueDate = reader.GetDateTime(5),
                                Notes = reader.IsDBNull(6) ? null : reader.GetString(6),
                                CreationDate = reader.GetDateTime(7)
                            });
                        }

                        // Move to the second result set for the count
                        if (await reader.NextResultAsync() && await reader.ReadAsync())
                        {
                            var totalCount = reader.GetInt32(0);
                            return (tasks, totalCount);
                        }
                    }
                }
            }

            return (tasks, 0);
        }

        public async Task<bool> Insert(TaskDto entity)
        {
            using (var connection = _databaseHelper.GetConnection())
            {
                const string query = @"
                    INSERT INTO Tasks (Description, UserId, StateId, Priority, DueDate, Notes) 
                    VALUES (@Description, @UserId, @StateId, @Priority, @DueDate, @Notes)";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Description", entity.Description);
                    command.Parameters.AddWithValue("@UserId", entity.UserId);
                    command.Parameters.AddWithValue("@StateId", entity.StateId);
                    command.Parameters.AddWithValue("@Priority", entity.Priority);
                    command.Parameters.AddWithValue("@DueDate", entity.DueDate);
                    command.Parameters.AddWithValue("@Notes", (object)entity.Notes ?? DBNull.Value);

                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        public async Task<bool> Update(TaskDto entity)
        {
            using (var connection = _databaseHelper.GetConnection())
            {
                const string query = @"
                    UPDATE Tasks
                    SET Description = @Description, UserId = @UserId, StateId = @StateId, Priority = @Priority, DueDate = @DueDate, Notes = @Notes
                    WHERE Id = @Id";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", entity.Id);
                    command.Parameters.AddWithValue("@Description", entity.Description);
                    command.Parameters.AddWithValue("@UserId", entity.UserId);
                    command.Parameters.AddWithValue("@StateId", entity.StateId);
                    command.Parameters.AddWithValue("@Priority", entity.Priority);
                    command.Parameters.AddWithValue("@DueDate", entity.DueDate);
                    command.Parameters.AddWithValue("@Notes", (object)entity.Notes ?? DBNull.Value);

                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }
    }
}
