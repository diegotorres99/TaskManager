using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManager.Model.Entities;

namespace TaskManager.View
{
    public partial class XfrmEditForm : DevExpress.XtraEditors.XtraForm
    {
        public XfrmEditForm()
        {
            InitializeComponent();
        }


        public static (bool changesSaved, Tasks item) EditItem(Tasks orderItem)
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
    }
}