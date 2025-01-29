using DevExpress.XtraEditors;
using System;
using TaskManager.ViewModels.Models;
using TaskManagerApp.ViewModel.Services;

namespace TaskManager.View
{
    public partial class XfrmMain : XtraForm
    {
        private readonly TasksService _tasksService;
        private VirtualServerModeDataLoader? loader;

        public XfrmMain()
        {
            InitializeComponent();
            _tasksService = new TasksService();
            InitializeFilterData();
        }

        private void InitializeFilterData()
        {
            this.barDateStart.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            this.barDateEnd.EditValue = new DateTime(DateTime.Today.Year, 12, 31);

            //var userList = _tasksService.GetUsersAsync();
            //var statesList = _tasksService.GetStatesAsync();
            //var proritiesList = _tasksService.GetPrioritiesAsync();

        }

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private void VirtualServerModeSource_ConfigurationChanged(object? sender, DevExpress.Data.VirtualServerModeRowsEventArgs e)
        {
            loader = new VirtualServerModeDataLoader(e.ConfigurationInfo, _tasksService);

            DateTime? startDate = this.barDateStart.EditValue as DateTime?;
            DateTime? endDate = this.barDateEnd.EditValue as DateTime?;

            var filters = new TaskFilterDto
            {
                DueDateStart = startDate,
                DueDateEnd = endDate,
                PriorityId = 1,
                StateId = 1,
                UserId = 1
            };

            e.RowsTask = loader.GetRowsAsync(e, filters);
        }

        private void VirtualServerModeSource_MoreRows(object? sender, DevExpress.Data.VirtualServerModeRowsEventArgs e)
        {
            if (loader is not null)
            {
                DateTime? startDate = this.barDateStart.EditValue as DateTime?;
                DateTime? endDate = this.barDateEnd.EditValue as DateTime?;

                var filters = new TaskFilterDto
                {
                    DueDateStart = startDate,
                    DueDateEnd = endDate,
                    PriorityId = 1,
                    StateId = 1,
                    UserId = 1
                };

                e.RowsTask = loader.GetRowsAsync(e, filters);
            }
        }
    }
}