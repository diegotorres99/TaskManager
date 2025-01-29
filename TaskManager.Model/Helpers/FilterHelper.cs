using Microsoft.Data.Sqlite;
using System.Data.Common;
using TaskManager.Model.DTOs;

namespace TaskManager.Model.Helpers
{
    public class FilterHelper
    {
        public static (string query, string countQuery, List<DbParameter> parameters) BuildTaskQuery(TaskFilter filters)
        {
            var query = @"SELECT 
                    Tasks.*, 
                    Users.Name AS Username,
                    States.Name AS StateName, 
                    Priorities.Name AS PriorityName
                  FROM Tasks 
                  INNER JOIN Users ON Tasks.UserId = Users.id
                  INNER JOIN States ON Tasks.StateId = States.id
                  INNER JOIN Priorities ON Tasks.PriorityId = Priorities.id
                  WHERE 1=1";

            var countQuery = @"SELECT COUNT(*) 
                       FROM Tasks 
                       INNER JOIN Users ON Tasks.UserId = Users.id
                       INNER JOIN States ON Tasks.StateId = States.id
                       INNER JOIN Priorities ON Tasks.PriorityId = Priorities.id
                       WHERE 1=1";

            var parameters = new List<DbParameter>();

            // Add filter conditions
            if (filters.UserId.HasValue)
            {
                query += " AND Tasks.UserId = @UserId";
                countQuery += " AND Tasks.UserId = @UserId";
                parameters.Add(new SqliteParameter("@UserId", filters.UserId.Value));
            }

            if (filters.StateId.HasValue)
            {
                query += " AND Tasks.StateId = @StateId";
                countQuery += " AND Tasks.StateId = @StateId";
                parameters.Add(new SqliteParameter("@StateId", filters.StateId.Value));
            }

            if (filters.PriorityId > 0)
            {
                query += " AND Tasks.PriorityId = @PriorityId";
                countQuery += " AND Tasks.PriorityId = @PriorityId";
                parameters.Add(new SqliteParameter("@PriorityId", filters.PriorityId));
            }

            if (filters.DueDateStart.HasValue)
            {
                query += " AND Tasks.DueDate >= @DueDateStart";
                countQuery += " AND Tasks.DueDate >= @DueDateStart";
                parameters.Add(new SqliteParameter("@DueDateStart", filters.DueDateStart.Value));
            }

            if (filters.DueDateEnd.HasValue)
            {
                query += " AND Tasks.DueDate <= @DueDateEnd";
                countQuery += " AND Tasks.DueDate <= @DueDateEnd";
                parameters.Add(new SqliteParameter("@DueDateEnd", filters.DueDateEnd.Value));
            }

            // Add sorting logic
            query += $" ORDER BY {filters.SortField} {(filters.SortAscending ? "ASC" : "DESC")}";

            // Apply pagination
            query += " LIMIT @Take OFFSET @Skip";
            parameters.Add(new SqliteParameter("@Take", filters.Take));
            parameters.Add(new SqliteParameter("@Skip", filters.Skip));

            return (query, countQuery, parameters);
        }

    }
}
