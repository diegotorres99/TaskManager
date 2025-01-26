using TaskManager.Model.DTOs;

namespace WinForms.Client
{
    public partial class EditForm : DevExpress.XtraEditors.XtraForm
    {
        public EditForm()
        {
            InitializeComponent();
        }

        public static (bool changesSaved, TaskDto item) EditItem(TaskDto orderItem)
        {
            using var form = new EditForm();
            var clonedItem = new TaskDto
            {
                //Id = orderItem.Id,
                //ProductName = orderItem.ProductName,
                //UnitPrice = orderItem.UnitPrice,
                //Quantity = orderItem.Quantity,
                //Discount = orderItem.Discount,
                //OrderDate = orderItem.OrderDate
                
            };
            form.orderItemBindingSource.DataSource = clonedItem;
            if (form.ShowDialog() == DialogResult.OK)
            {
                return (true, clonedItem);
            }
            return (false, orderItem);
        }

        public static (bool changesSaved, TaskDto? item) CreateItem()
        {
            using var form = new EditForm();
            var newItem = new TaskDto()
            {
                DueDate = DateTime.Now
            };
            form.orderItemBindingSource.DataSource = newItem;
            if (form.ShowDialog() == DialogResult.OK)
            {
                return (true, newItem);
            }
            return (false, null);
        }
    }
}