using Microsoft.Data.Sqlite;
using System.Data.Common;
using TaskManager.Model.DTOs;

namespace TaskManager.Model.Helpers
{
    public class FilterHelper
    {
        public static (string query, string countQuery, List<DbParameter> parameters) BuildTaskQuery(TaskFilter filters)
        {
            var query = "SELECT * FROM Tasks WHERE 1=1";
            var countQuery = "SELECT COUNT(*) FROM Tasks WHERE 1=1";
            var parameters = new List<DbParameter>();

            // Add filter conditions to query and countQuery if they exist in the filters
            if (filters.UserId.HasValue)
            {
                query += " AND UserId = @UserId";
                countQuery += " AND UserId = @UserId";
                parameters.Add(new SqliteParameter("@UserId", filters.UserId.Value));
            }

            if (filters.StateId.HasValue)
            {
                query += " AND StateId = @StateId";
                countQuery += " AND StateId = @StateId";
                parameters.Add(new SqliteParameter("@StateId", filters.StateId.Value));
            }

            if (filters.PriorityId > 0)
            {
                query += " AND PriorityId = @PriorityId";
                countQuery += " AND PriorityId = @PriorityId";
                parameters.Add(new SqliteParameter("@PriorityId", filters.PriorityId));
            }

            if (filters.DueDateStart.HasValue)
            {
                query += " AND DueDate >= @DueDateStart";
                countQuery += " AND DueDate >= @DueDateStart";
                parameters.Add(new SqliteParameter("@DueDateStart", filters.DueDateStart.Value));
            }

            if (filters.DueDateEnd.HasValue)
            {
                query += " AND DueDate <= @DueDateEnd";
                countQuery += " AND DueDate <= @DueDateEnd";
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
