namespace TaskManager.View
{
    partial class XfrmEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            btnDelete = new DevExpress.XtraEditors.SimpleButton();
            txtDescription = new DevExpress.XtraEditors.TextEdit();
            tasksBindingSource = new System.Windows.Forms.BindingSource(components);
            cbxUsuario = new DevExpress.XtraEditors.ComboBoxEdit();
            cbxEstado = new DevExpress.XtraEditors.ComboBoxEdit();
            cbxPriority = new DevExpress.XtraEditors.ComboBoxEdit();
            dtFechaCompromiso = new DevExpress.XtraEditors.DateEdit();
            txtNotas = new DevExpress.XtraEditors.TextEdit();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            Descripción = new DevExpress.XtraLayout.LayoutControlItem();
            simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
            Usuario = new DevExpress.XtraLayout.LayoutControlItem();
            simpleSeparator3 = new DevExpress.XtraLayout.SimpleSeparator();
            Estado = new DevExpress.XtraLayout.LayoutControlItem();
            simpleSeparator4 = new DevExpress.XtraLayout.SimpleSeparator();
            Prioridad = new DevExpress.XtraLayout.LayoutControlItem();
            simpleSeparator5 = new DevExpress.XtraLayout.SimpleSeparator();
            txtFechaCompromiso = new DevExpress.XtraLayout.LayoutControlItem();
            simpleSeparator6 = new DevExpress.XtraLayout.SimpleSeparator();
            txtNotes = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            textEdit1 = new DevExpress.XtraEditors.TextEdit();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).BeginInit();
            dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tasksBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbxUsuario.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbxEstado.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbxPriority.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtFechaCompromiso.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtFechaCompromiso.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNotas.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Descripción).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Usuario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Estado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Prioridad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaCompromiso).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNotes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            dataLayoutControl1.Controls.Add(btnDelete);
            dataLayoutControl1.Controls.Add(txtDescription);
            dataLayoutControl1.Controls.Add(cbxUsuario);
            dataLayoutControl1.Controls.Add(cbxEstado);
            dataLayoutControl1.Controls.Add(cbxPriority);
            dataLayoutControl1.Controls.Add(dtFechaCompromiso);
            dataLayoutControl1.Controls.Add(txtNotas);
            dataLayoutControl1.Controls.Add(btnSave);
            dataLayoutControl1.Location = new System.Drawing.Point(2, -3);
            dataLayoutControl1.Name = "dataLayoutControl1";
            dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(922, -1118, 812, 500);
            dataLayoutControl1.Root = Root;
            dataLayoutControl1.Size = new System.Drawing.Size(559, 336);
            dataLayoutControl1.TabIndex = 0;
            dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(362, 297);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(185, 27);
            btnDelete.StyleController = dataLayoutControl1;
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Eliminar";
            // 
            // txtDescription
            // 
            txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", tasksBindingSource, "Description", true));
            txtDescription.Location = new System.Drawing.Point(134, 12);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new System.Drawing.Size(413, 22);
            txtDescription.StyleController = dataLayoutControl1;
            txtDescription.TabIndex = 0;
            // 
            // tasksBindingSource
            // 
            tasksBindingSource.DataSource = typeof(Models.Tasks);
            // 
            // cbxUsuario
            // 
            cbxUsuario.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", tasksBindingSource, "Username", true));
            cbxUsuario.Location = new System.Drawing.Point(134, 40);
            cbxUsuario.Name = "cbxUsuario";
            cbxUsuario.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbxUsuario.Size = new System.Drawing.Size(413, 22);
            cbxUsuario.StyleController = dataLayoutControl1;
            cbxUsuario.TabIndex = 2;
            // 
            // cbxEstado
            // 
            cbxEstado.Location = new System.Drawing.Point(134, 67);
            cbxEstado.Name = "cbxEstado";
            cbxEstado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbxEstado.Size = new System.Drawing.Size(413, 22);
            cbxEstado.StyleController = dataLayoutControl1;
            cbxEstado.TabIndex = 3;
            // 
            // cbxPriority
            // 
            cbxPriority.Location = new System.Drawing.Point(134, 94);
            cbxPriority.Name = "cbxPriority";
            cbxPriority.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbxPriority.Size = new System.Drawing.Size(413, 22);
            cbxPriority.StyleController = dataLayoutControl1;
            cbxPriority.TabIndex = 4;
            // 
            // dtFechaCompromiso
            // 
            dtFechaCompromiso.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", tasksBindingSource, "DueDate", true));
            dtFechaCompromiso.EditValue = null;
            dtFechaCompromiso.Location = new System.Drawing.Point(134, 121);
            dtFechaCompromiso.Name = "dtFechaCompromiso";
            dtFechaCompromiso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtFechaCompromiso.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtFechaCompromiso.Size = new System.Drawing.Size(413, 22);
            dtFechaCompromiso.StyleController = dataLayoutControl1;
            dtFechaCompromiso.TabIndex = 5;
            // 
            // txtNotas
            // 
            txtNotas.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", tasksBindingSource, "Notes", true));
            txtNotas.Location = new System.Drawing.Point(134, 148);
            txtNotas.Name = "txtNotas";
            txtNotas.Size = new System.Drawing.Size(413, 22);
            txtNotas.StyleController = dataLayoutControl1;
            txtNotas.TabIndex = 6;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(12, 297);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(346, 27);
            btnSave.StyleController = dataLayoutControl1;
            btnSave.TabIndex = 7;
            btnSave.Text = "Guardar";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { Descripción, simpleSeparator1, simpleSeparator2, Usuario, simpleSeparator3, Estado, simpleSeparator4, Prioridad, simpleSeparator5, txtFechaCompromiso, simpleSeparator6, txtNotes, emptySpaceItem2, layoutControlItem2, layoutControlItem3 });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(559, 336);
            Root.TextVisible = false;
            // 
            // Descripción
            // 
            Descripción.Control = txtDescription;
            Descripción.CustomizationFormText = "Descripción:";
            Descripción.Location = new System.Drawing.Point(0, 0);
            Descripción.Name = "Descripción";
            Descripción.Size = new System.Drawing.Size(539, 26);
            // 
            // simpleSeparator1
            // 
            simpleSeparator1.Location = new System.Drawing.Point(0, 26);
            simpleSeparator1.Name = "simpleSeparator1";
            simpleSeparator1.Size = new System.Drawing.Size(539, 1);
            // 
            // simpleSeparator2
            // 
            simpleSeparator2.Location = new System.Drawing.Point(0, 27);
            simpleSeparator2.Name = "simpleSeparator2";
            simpleSeparator2.Size = new System.Drawing.Size(539, 1);
            // 
            // Usuario
            // 
            Usuario.Control = cbxUsuario;
            Usuario.Location = new System.Drawing.Point(0, 28);
            Usuario.Name = "Usuario";
            Usuario.Size = new System.Drawing.Size(539, 26);
            // 
            // simpleSeparator3
            // 
            simpleSeparator3.Location = new System.Drawing.Point(0, 54);
            simpleSeparator3.Name = "simpleSeparator3";
            simpleSeparator3.Size = new System.Drawing.Size(539, 1);
            // 
            // Estado
            // 
            Estado.Control = cbxEstado;
            Estado.Location = new System.Drawing.Point(0, 55);
            Estado.Name = "Estado";
            Estado.Size = new System.Drawing.Size(539, 26);
            // 
            // simpleSeparator4
            // 
            simpleSeparator4.Location = new System.Drawing.Point(0, 81);
            simpleSeparator4.Name = "simpleSeparator4";
            simpleSeparator4.Size = new System.Drawing.Size(539, 1);
            // 
            // Prioridad
            // 
            Prioridad.Control = cbxPriority;
            Prioridad.Location = new System.Drawing.Point(0, 82);
            Prioridad.Name = "Prioridad";
            Prioridad.Size = new System.Drawing.Size(539, 26);
            // 
            // simpleSeparator5
            // 
            simpleSeparator5.Location = new System.Drawing.Point(0, 108);
            simpleSeparator5.Name = "simpleSeparator5";
            simpleSeparator5.Size = new System.Drawing.Size(539, 1);
            // 
            // txtFechaCompromiso
            // 
            txtFechaCompromiso.Control = dtFechaCompromiso;
            txtFechaCompromiso.Location = new System.Drawing.Point(0, 109);
            txtFechaCompromiso.Name = "txtFechaCompromiso";
            txtFechaCompromiso.Size = new System.Drawing.Size(539, 26);
            txtFechaCompromiso.Text = "Fecha Compromiso";
            // 
            // simpleSeparator6
            // 
            simpleSeparator6.Location = new System.Drawing.Point(0, 135);
            simpleSeparator6.Name = "simpleSeparator6";
            simpleSeparator6.Size = new System.Drawing.Size(539, 1);
            // 
            // txtNotes
            // 
            txtNotes.Control = txtNotas;
            txtNotes.Location = new System.Drawing.Point(0, 136);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new System.Drawing.Size(539, 26);
            txtNotes.Text = "Notas";
            // 
            // emptySpaceItem2
            // 
            emptySpaceItem2.Location = new System.Drawing.Point(0, 162);
            emptySpaceItem2.Name = "emptySpaceItem2";
            emptySpaceItem2.Size = new System.Drawing.Size(539, 123);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = btnSave;
            layoutControlItem2.Location = new System.Drawing.Point(0, 285);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new System.Drawing.Size(350, 31);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = btnDelete;
            layoutControlItem3.Location = new System.Drawing.Point(350, 285);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.Size = new System.Drawing.Size(189, 31);
            layoutControlItem3.TextVisible = false;
            // 
            // textEdit1
            // 
            textEdit1.Location = new System.Drawing.Point(132, 39);
            textEdit1.Name = "textEdit1";
            textEdit1.Size = new System.Drawing.Size(395, 22);
            textEdit1.StyleController = dataLayoutControl1;
            textEdit1.TabIndex = 5;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            // 
            // XfrmEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(564, 334);
            Controls.Add(dataLayoutControl1);
            Name = "XfrmEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Editar Tarea";
            ((System.ComponentModel.ISupportInitialize)dataLayoutControl1).EndInit();
            dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tasksBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbxUsuario.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbxEstado.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbxPriority.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtFechaCompromiso.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtFechaCompromiso.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNotas.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)Descripción).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator1).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator2).EndInit();
            ((System.ComponentModel.ISupportInitialize)Usuario).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator3).EndInit();
            ((System.ComponentModel.ISupportInitialize)Estado).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator4).EndInit();
            ((System.ComponentModel.ISupportInitialize)Prioridad).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator5).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFechaCompromiso).EndInit();
            ((System.ComponentModel.ISupportInitialize)simpleSeparator6).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNotes).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraLayout.LayoutControlItem Descripción;
        private System.Windows.Forms.BindingSource tasksBindingSource;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ComboBoxEdit cbxUsuario;
        private DevExpress.XtraEditors.ComboBoxEdit cbxEstado;
        private DevExpress.XtraEditors.ComboBoxEdit cbxPriority;
        private DevExpress.XtraEditors.DateEdit dtFechaCompromiso;
        private DevExpress.XtraLayout.LayoutControlItem Usuario;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator3;
        private DevExpress.XtraLayout.LayoutControlItem Estado;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator4;
        private DevExpress.XtraLayout.LayoutControlItem Prioridad;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator5;
        private DevExpress.XtraLayout.LayoutControlItem txtFechaCompromiso;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator6;
        private DevExpress.XtraEditors.TextEdit txtNotas;
        private DevExpress.XtraLayout.LayoutControlItem txtNotes;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}