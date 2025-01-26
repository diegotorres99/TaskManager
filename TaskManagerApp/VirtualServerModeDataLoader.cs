using DevExpress.Data;
using System.Diagnostics;
using TaskManager.Model.Entities;
using TaskManagerApp.ViewModel.Services; // Assuming DataServiceClient is in this namespace

namespace TaskManagerApp.View
{
    public class DataFetchResult
    {
        public List<Tasks> Items { get; set; } = null!;
        public int TotalCount { get; set; }
    }

    // This type is instantiated each time a configuration change in the virtual server
    // mode source takes place. It receives the configuration information and handles
    // the parts of it that are relevant to the data loading process.
    public class VirtualServerModeDataLoader
    {
        private readonly TasksService _dataServiceClient;  // Service Layer Dependency

        // Modify the constructor to accept DataServiceClient as a dependency
        public VirtualServerModeDataLoader(VirtualServerModeConfigurationInfo configurationInfo, TasksService dataServiceClient)
        {
            _dataServiceClient = dataServiceClient;

            // For instance, let's assume the backend supports sorting for just one field
            if (configurationInfo.SortInfo?.Length > 0)
            {
                SortField = configurationInfo.SortInfo[0].SortPropertyName;
                SortAscending = !configurationInfo.SortInfo[0].IsDesc;
            }
        }

        public int BatchSize { get; set; } = 40;
        public string SortField { get; set; } = "Id";
        public bool SortAscending { get; set; } = true;

        // Modify GetRowsAsync to use the injected DataServiceClient
        public Task<VirtualServerModeRowsTaskResult> GetRowsAsync(VirtualServerModeRowsEventArgs e)
        {
            return Task.Run(async () =>
            {
                Debug.WriteLine($"Fetching data rows {e.CurrentRowCount} to {e.CurrentRowCount + BatchSize}, sorting by {SortField} ({(SortAscending ? "asc" : "desc")})");

                // Call the service layer method using the injected DataServiceClient
                var dataFetchResult = await _dataServiceClient.GetOrderItemsAsync(e.CurrentRowCount, BatchSize, SortField, SortAscending);

                if (dataFetchResult == null)
                    return new VirtualServerModeRowsTaskResult();

                // Assuming the result is a List<TaskDto>, directly use the List to get the count and items
                var moreRowsAvailable = e.CurrentRowCount + dataFetchResult.Count < dataFetchResult.Count;
                Debug.WriteLine($"Returning {dataFetchResult.Count} items, more rows available: {moreRowsAvailable}");

                return new VirtualServerModeRowsTaskResult(dataFetchResult, moreRowsAvailable);
            }, e.CancellationToken);
        }

    }
}
