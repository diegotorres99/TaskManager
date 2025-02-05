using System;
using System.Windows.Forms;
using TaskManager.Model.DTOs;
using TaskManager.Model.Entities;
using TaskManager.ViewModel.Services;
using TaskManagerApp.ViewModel.Services;

namespace TaskManager.View
{
    public partial class XfrmEditForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly TasksService _tasksService;
        private readonly UsersService _usersService;
        private readonly StatesServices _statesService;
        private readonly PrioritiesService _prioritiesService;
        public XfrmEditForm()
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
      
            var userList = await _usersService.GetAllAsync() ?? [];
            var statesList = await _statesService.GetAllAsync() ?? [];
            var prioritiesList = await _prioritiesService.GetAllAsync() ?? [];

            var comboBoxRepositoryItem = this.cbxUsuario.Properties;
            if (comboBoxRepositoryItem != null)
            {
                comboBoxRepositoryItem.Items.Clear();
                foreach (var user in userList)
                {
                    comboBoxRepositoryItem.Items.Add(user);
                }
            }

            var priorityComboBox = this.cbxPriority.Properties;
            if (priorityComboBox != null)
            {
                priorityComboBox.Items.Clear();
                foreach (var priority in prioritiesList)
                {
                    priorityComboBox.Items.Add(priority);
                }
            }

            var stateComboBox = this.cbxEstado.Properties;
            if (stateComboBox != null)
            {

                stateComboBox.Items.Clear();
                foreach (var state in statesList)
                {
                    stateComboBox.Items.Add(state);
                }
            }
        }

        public (bool changesSaved, Tasks item) EditItem(Tasks orderItem)
        {
            using var form = new XfrmEditForm();
            var clonedItem = new Tasks
            {
                Id = orderItem.Id,
                CreationDate = orderItem.CreationDate,
                Description = orderItem.Description,
                DueDate = orderItem.DueDate,
                Notes = orderItem.Notes,
                PriorityId = orderItem.PriorityId,
                PriorityName = orderItem.PriorityName,
                StateId = orderItem.StateId,
                StateName = orderItem.StateName,
                UserId = orderItem.UserId,
                Username = orderItem.Username
            };
            form.tasksBindingSource.DataSource = clonedItem;
            if (form.ShowDialog() == DialogResult.OK)
            {
                return (true, clonedItem);
            }
            return (false, orderItem);
        }

        private void cbxEstado_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cbxEstado.SelectedItem is StateDto selectedState)
            {
                var task = tasksBindingSource.Current as Tasks;
                if (task != null)
                {
                    task.StateId = selectedState.Id;
                    task.StateName = selectedState.Name;
                }
            }
        }

        private void CbxUsuario_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cbxUsuario.SelectedItem is UserDto selectedUser)
            {
                var task = tasksBindingSource.Current as Tasks;
                if (task != null)
                {
                    task.UserId = selectedUser.Id;
                    task.Username = selectedUser.Name;
                }
            }
        }

        private void cbxPriority_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cbxPriority.SelectedItem is PriorityDto selectedPriority)
            {
                var task = tasksBindingSource.Current as Tasks;
                if (task != null)
                {
                    task.PriorityId = selectedPriority.Id;
                    task.PriorityName = selectedPriority.Name;
                }
            }
        }

        public static (bool changesSaved, Tasks? item) CreateItem()
        {
            using var form = new XfrmEditForm();
            var newItem = new Tasks()
            {
                DueDate = new DateTime(DateTime.Today.Year, 1, 1)
            };

            form.tasksBindingSource.DataSource = newItem;
            if (form.ShowDialog() == DialogResult.OK)
            {
                return (true, newItem);
            }
            return (false, null);
        }
    }
}