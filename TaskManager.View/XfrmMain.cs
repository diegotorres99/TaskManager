using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Threading.Tasks;
using TaskManager.Model.DTOs;
using TaskManager.View.VirtualServer;
using TaskManager.ViewModel.Services;
using TaskManager.ViewModels.Models;
using TaskManagerApp.ViewModel.Services;

namespace TaskManager.View
{
    public partial class XfrmMain : XtraForm
    {
        private readonly TasksService _tasksService;
        private readonly UsersService _usersService;
        private readonly StatesServices _statesService;
        private readonly PrioritiesService _prioritiesService;
        private VirtualServerModeDataLoader? loader;

        public XfrmMain()
        {
            InitializeComponent();
            _tasksService = new TasksService();
            _usersService = new UsersService();
            _prioritiesService = new PrioritiesService();
            _statesService = new StatesServices();
            InitializeFilterData();
        }

        private async void InitializeFilterData()
        {
            barDateStart.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            barDateEnd.EditValue = new DateTime(DateTime.Today.Year, 12, 31);

            var userList = await _usersService.GetAllAsync() ?? [];
            var statesList = await _statesService.GetAllAsync() ?? [];
            var prioritiesList = await _prioritiesService.GetAllAsync() ?? [];

            var comboBoxRepositoryItem = this.bardDdllUser.Edit as RepositoryItemComboBox;
            if (comboBoxRepositoryItem != null)
            {
                comboBoxRepositoryItem.Items.Clear();
                foreach (var user in userList)
                {
                    comboBoxRepositoryItem.Items.Add(user);
                }
                comboBoxRepositoryItem.Items.Add(new UserDto() { Name = "TODOS" });
            }

            var priorityComboBox = this.barDdlPriorities.Edit as RepositoryItemComboBox;
            if (priorityComboBox != null)
            {
                priorityComboBox.Items.Clear();
                foreach (var priority in prioritiesList)
                {
                    priorityComboBox.Items.Add(priority);
                }
                priorityComboBox.Items.Add(new PriorityDto() { Name = "TODAS" });
            }

            var stateComboBox = this.barDdlState.Edit as RepositoryItemComboBox;
            if (stateComboBox != null)
            {

                stateComboBox.Items.Clear();
                foreach (var state in statesList)
                {
                    stateComboBox.Items.Add(state);
                }
                stateComboBox.Items.Add(new StateDto() { Name = "TODOS" });
            }

        }
        private void VirtualServerModeSource_ConfigurationChanged(object sender, DevExpress.Data.VirtualServerModeRowsEventArgs e)
        {
            loader = new VirtualServerModeDataLoader(e.ConfigurationInfo, _tasksService);

            DateTime? startDate = this.barDateStart.EditValue as DateTime?;
            DateTime? endDate = this.barDateEnd.EditValue as DateTime?;

            var filters = new TaskFilterDto
            {
                DueDateStart = startDate,
                DueDateEnd = endDate,
                PriorityId = barDdlPriorities.EditValue as int? ?? 0,
                StateId = barDdlState.EditValue as int? ?? 0,
                UserId = bardDdllUser.EditValue as int? ?? 0,
            };

            e.RowsTask = loader.GetRowsAsync(e, filters);
        }
        private async Task LoadDataWithCustomFilters()
        {
            var selectedPriority = this.barDdlPriorities.EditValue as PriorityDto;
            var selectedState = this.barDdlState.EditValue as StateDto;
            var selectedUser = this.bardDdllUser.EditValue as UserDto;

            var filters = new TaskFilterDto
            {
                DueDateStart = this.barDateStart.EditValue as DateTime? ?? new DateTime(DateTime.Today.Year, 1, 1),
                DueDateEnd = this.barDateEnd.EditValue as DateTime? ?? new DateTime(DateTime.Today.Year, 12, 31),
                PriorityId = selectedPriority?.Id ?? 0,
                StateId = selectedState?.Id ?? 0,
                UserId = selectedUser?.Id ?? 0,
            };

            var result = await _tasksService.GetFilteredTasksAsync(filters);

            this.gridControl.DataSource = result;
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
                    PriorityId = barDdlPriorities.EditValue as int? ?? 1,
                    StateId = barDdlState.EditValue as int? ?? 1,
                    UserId = bardDdllUser.EditValue as int? ?? 1,
                };

                e.RowsTask = loader.GetRowsAsync(e, filters);
            }
        }
        private async void bardDdllUser_EditValueChanged(object sender, EventArgs e)
        {
            await LoadDataWithCustomFilters();
        }
        private async void barDdlState_EditValueChanged(object sender, EventArgs e)
        {
            await LoadDataWithCustomFilters();
        }
        private async void barDateStart_EditValueChanged(object sender, EventArgs e)
        {
            await LoadDataWithCustomFilters();
        }
        private async void barDateEnd_EditValueChanged(object sender, EventArgs e)
        {
            await LoadDataWithCustomFilters();
        }
        private void btnCleanFilters_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barDateStart.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            barDateEnd.EditValue = new DateTime(DateTime.Today.Year, 12, 31);
            barDdlPriorities.EditValue = "";
            barDdlState.EditValue = "";
            bardDdllUser.EditValue = "";
        }
        private async void barDdlPriorities_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await LoadDataWithCustomFilters();
        }
        private async void barDdlPriorities_EditValueChanged_1(object sender, EventArgs e)
        {
            await LoadDataWithCustomFilters();
        }
    }
}