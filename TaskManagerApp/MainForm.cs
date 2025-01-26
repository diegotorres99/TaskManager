using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using TaskManager.Model.DTOs;
using TaskManagerApp.View;
using TaskManagerApp.ViewModel.Services;

namespace WinForms.Client
{
    public partial class MainForm : XtraForm
    {
        private readonly TasksService _tasksService;
        public MainForm()
        {
            InitializeComponent();
            _tasksService = new TasksService(); 
        }

        private VirtualServerModeDataLoader? loader;

        private void VirtualServerModeSource_ConfigurationChanged(object? sender, DevExpress.Data.VirtualServerModeRowsEventArgs e)
        {
            loader = new VirtualServerModeDataLoader(e.ConfigurationInfo, null);
            e.RowsTask = loader.GetRowsAsync(e);
        }

        private void VirtualServerModeSource_MoreRows(object? sender, DevExpress.Data.VirtualServerModeRowsEventArgs e)
        {
            if (loader is not null)
            {
                e.RowsTask = loader.GetRowsAsync(e);
            }
        }

        private async void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (sender is GridView view)
            {
                if (view.FocusedRowObject is TaskDto t)
                {
                    var editResult = EditForm.EditItem(t);
                    if (editResult.changesSaved)
                    {
                        await _tasksService.UpdateOrderItemAsync(editResult.item);
                        view.RefreshData();
                    }
                }
            }
        }

        private async void addItemButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridControl.FocusedView is ColumnView view)
            {
                var createResult = EditForm.CreateItem();
                if (createResult.changesSaved)
                {
                    await _tasksService.CreateOrderItemAsync(createResult.item!);
                    view.RefreshData();
                }
            }
        }

        private async void deleteItemButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridControl.FocusedView is ColumnView view &&
                view.GetFocusedRow() is TaskDto taskItem)
            {
                await _tasksService.DeleteOrderItemAsync(taskItem.Id);
                view.RefreshData();
            }
        }
    }
}
