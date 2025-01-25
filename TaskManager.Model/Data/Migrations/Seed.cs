using System.Data.Entity;
using System.Text.Json;
using TaskManager.Model.Entities;

namespace TaskManager.Model.Data.Migrations
{
    public class Seed
    {
        public static async Task seedTasks(DataContext context)
        {
            if (await context.Tasks.AnyAsync()) return;

            var userData = await File.ReadAllTextAsync("Data/TaskSeedData.json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var tasks = JsonSerializer.Deserialize<List<Tasks>>(userData, options);

            if (tasks == null) return;

            foreach (var task in tasks)
            {
                context.Tasks.Add(task);
            }

            await context.SaveChangesAsync();
        }
    }
}
