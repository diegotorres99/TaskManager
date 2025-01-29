using DevExpress.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TaskManager.ViewModels.Models;
using TaskManagerApp.ViewModel.Services;

namespace TaskManager.View
{
    public class DataFetchResult
    {
        public List<Models.Tasks> Items { get; set; } = null!;
        public int TotalCount { get; set; }
    }

    // This type is instantiated each time a configuration change in the virtual server
    // mode source takes place. It receives the configuration information and handles
    // the parts of it that are relevant to the data loading process.
    public class VirtualServerModeDataLoader
    {
        private readonly TasksService _dataServiceClient;
        public int BatchSize { get; set; } = 40;
        public string SortField { get; set; } = "Id";
        public bool SortAscending { get; set; } = true;

        public VirtualServerModeDataLoader(VirtualServerModeConfigurationInfo configurationInfo, TasksService dataServiceClient)
        {
            _dataServiceClient = dataServiceClient;

            if (configurationInfo.SortInfo?.Length > 0)
            {
                SortField = configurationInfo.SortInfo[0].SortPropertyName;
                SortAscending = !configurationInfo.SortInfo[0].IsDesc;
            }
        }

        public Task<VirtualServerModeRowsTaskResult> GetRowsAsync(VirtualServerModeRowsEventArgs e, TaskFilterDto pFilters)
        {
            return Task.Run(async () =>
            {
                Debug.WriteLine($"Fetching data rows {e.CurrentRowCount} to {e.CurrentRowCount + BatchSize}, sorting by {SortField} ({(SortAscending ? "asc" : "desc")})");
                var filters = new TaskFilterDto
                {
                    Skip = e.CurrentRowCount,
                    Take = BatchSize,
                    SortField = SortField,
                    SortAscending = SortAscending,
                    DueDateStart = pFilters.DueDateStart,
                    DueDateEnd = pFilters.DueDateEnd,
                    PriorityId = 1,
                    StateId = 1,
                    UserId = 1
                };

                var dataFetchResult = await _dataServiceClient.GetFilteredTasksAsync(filters);

                if (dataFetchResult == null)
                    return new VirtualServerModeRowsTaskResult();

                var moreRowsAvailable = e.CurrentRowCount + BatchSize < dataFetchResult.Count;
                Debug.WriteLine($"Returning {dataFetchResult.Count} items, more rows available: {moreRowsAvailable}");

                return new VirtualServerModeRowsTaskResult(dataFetchResult, moreRowsAvailable);
            }, e.CancellationToken);
        }
    }
}
