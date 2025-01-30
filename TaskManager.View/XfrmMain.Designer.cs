namespace TaskManager.View
{
    partial class XfrmMain
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
            gridControl = new DevExpress.XtraGrid.GridControl();
            virtualServerModeSource = new DevExpress.Data.VirtualServerModeSource(components);
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            colState = new DevExpress.XtraGrid.Columns.GridColumn();
            colPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            addTask = new DevExpress.XtraBars.BarButtonItem();
            btnDelete = new DevExpress.XtraBars.BarButtonItem();
            space = new DevExpress.XtraBars.BarStaticItem();
            barLblDueDates = new DevExpress.XtraBars.BarStaticItem();
            barDateStart = new DevExpress.XtraBars.BarEditItem();
            repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            barDateEnd = new DevExpress.XtraBars.BarEditItem();
            repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            bardDdllUser = new DevExpress.XtraBars.BarEditItem();
            repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            barStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
            barDdlState = new DevExpress.XtraBars.BarEditItem();
            repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            barStaticItem5 = new DevExpress.XtraBars.BarStaticItem();
            barDdlPriorities = new DevExpress.XtraBars.BarEditItem();
            repositoryItemComboBox5 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            btnCleanFilters = new DevExpress.XtraBars.BarButtonItem();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            barToggleSwitchItem1 = new DevExpress.XtraBars.BarToggleSwitchItem();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            barDdlPriority = new DevExpress.XtraBars.BarEditItem();
            repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            barEditItem6 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)gridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)virtualServerModeSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit1.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit2.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit2).BeginInit();
            SuspendLayout();
            // 
            // gridControl
            // 
            gridControl.DataSource = virtualServerModeSource;
            gridControl.Location = new System.Drawing.Point(0, 48);
            gridControl.MainView = gridView1;
            gridControl.Name = "gridControl";
            gridControl.Size = new System.Drawing.Size(1453, 500);
            gridControl.TabIndex = 0;
            gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // virtualServerModeSource
            // 
            virtualServerModeSource.RowType = typeof(Model.Entities.Tasks);
            virtualServerModeSource.ConfigurationChanged += VirtualServerModeSource_ConfigurationChanged;
            virtualServerModeSource.MoreRows += VirtualServerModeSource_MoreRows;
            // 
            // gridView1
            // 
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colDescription, colUser, colState, colPriority, colDueDate, colNotes });
            gridView1.GridControl = gridControl;
            gridView1.Name = "gridView1";
            // 
            // colDescription
            // 
            colDescription.Caption = "Descripción";
            colDescription.FieldName = "Description";
            colDescription.MinWidth = 25;
            colDescription.Name = "colDescription";
            colDescription.Visible = true;
            colDescription.VisibleIndex = 0;
            colDescription.Width = 94;
            // 
            // colUser
            // 
            colUser.Caption = "Usuario";
            colUser.FieldName = "Username";
            colUser.MinWidth = 25;
            colUser.Name = "colUser";
            colUser.Visible = true;
            colUser.VisibleIndex = 1;
            colUser.Width = 94;
            // 
            // colState
            // 
            colState.Caption = "Estado";
            colState.FieldName = "StateName";
            colState.MinWidth = 25;
            colState.Name = "colState";
            colState.Visible = true;
            colState.VisibleIndex = 2;
            colState.Width = 94;
            // 
            // colPriority
            // 
            colPriority.Caption = "Prioridad";
            colPriority.FieldName = "PriorityName";
            colPriority.MinWidth = 25;
            colPriority.Name = "colPriority";
            colPriority.Visible = true;
            colPriority.VisibleIndex = 3;
            colPriority.Width = 94;
            // 
            // colDueDate
            // 
            colDueDate.Caption = "Fecha Compromiso";
            colDueDate.FieldName = "DueDate";
            colDueDate.MinWidth = 25;
            colDueDate.Name = "colDueDate";
            colDueDate.Visible = true;
            colDueDate.VisibleIndex = 4;
            colDueDate.Width = 94;
            // 
            // colNotes
            // 
            colNotes.Caption = "Notas";
            colNotes.FieldName = "Notes";
            colNotes.MinWidth = 25;
            colNotes.Name = "colNotes";
            colNotes.Visible = true;
            colNotes.VisibleIndex = 5;
            colNotes.Width = 94;
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1, bar3 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barToggleSwitchItem1, barButtonItem1, addTask, btnDelete, space, barDateStart, barLblDueDates, barStaticItem2, barDateEnd, barStaticItem3, bardDdllUser, barStaticItem4, barDdlState, barStaticItem5, barDdlPriority, barEditItem6, barEditItem1, barEditItem2, barDdlPriorities, btnCleanFilters });
            barManager1.MaxItemId = 20;
            barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemDateEdit1, repositoryItemDateEdit2, repositoryItemComboBox1, repositoryItemComboBox2, repositoryItemComboBox3, repositoryItemTextEdit1, repositoryItemComboBox4, repositoryItemTextEdit2, repositoryItemComboBox5 });
            barManager1.StatusBar = bar3;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(addTask), new DevExpress.XtraBars.LinkPersistInfo(btnDelete), new DevExpress.XtraBars.LinkPersistInfo(space), new DevExpress.XtraBars.LinkPersistInfo(barLblDueDates), new DevExpress.XtraBars.LinkPersistInfo(barDateStart), new DevExpress.XtraBars.LinkPersistInfo(barStaticItem2), new DevExpress.XtraBars.LinkPersistInfo(barDateEnd), new DevExpress.XtraBars.LinkPersistInfo(barStaticItem3), new DevExpress.XtraBars.LinkPersistInfo(bardDdllUser), new DevExpress.XtraBars.LinkPersistInfo(barStaticItem4), new DevExpress.XtraBars.LinkPersistInfo(barDdlState), new DevExpress.XtraBars.LinkPersistInfo(barStaticItem5), new DevExpress.XtraBars.LinkPersistInfo(barDdlPriorities), new DevExpress.XtraBars.LinkPersistInfo(btnCleanFilters) });
            bar1.Text = "Tools";
            // 
            // addTask
            // 
            addTask.Caption = "Agregar Tarea";
            addTask.Id = 2;
            addTask.Name = "addTask";
            // 
            // btnDelete
            // 
            btnDelete.Caption = "Eliminar Tarea";
            btnDelete.Id = 3;
            btnDelete.Name = "btnDelete";
            // 
            // space
            // 
            space.Id = 4;
            space.Name = "space";
            space.Size = new System.Drawing.Size(10, 0);
            space.Width = 10;
            // 
            // barLblDueDates
            // 
            barLblDueDates.Caption = "Fecha de compromiso";
            barLblDueDates.Id = 6;
            barLblDueDates.Name = "barLblDueDates";
            // 
            // barDateStart
            // 
            barDateStart.Caption = "Inicio fecha compromiso";
            barDateStart.Edit = repositoryItemDateEdit1;
            barDateStart.Id = 5;
            barDateStart.Name = "barDateStart";
            barDateStart.Size = new System.Drawing.Size(100, 0);
            barDateStart.EditValueChanged += barDateStart_EditValueChanged;
            // 
            // repositoryItemDateEdit1
            // 
            repositoryItemDateEdit1.AutoHeight = false;
            repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // barStaticItem2
            // 
            barStaticItem2.Caption = "Hasta: ";
            barStaticItem2.Id = 7;
            barStaticItem2.Name = "barStaticItem2";
            // 
            // barDateEnd
            // 
            barDateEnd.Caption = "Fin fecha compromiso";
            barDateEnd.Edit = repositoryItemDateEdit2;
            barDateEnd.Id = 8;
            barDateEnd.Name = "barDateEnd";
            barDateEnd.Size = new System.Drawing.Size(105, 0);
            barDateEnd.EditValueChanged += barDateEnd_EditValueChanged;
            // 
            // repositoryItemDateEdit2
            // 
            repositoryItemDateEdit2.AutoHeight = false;
            repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // barStaticItem3
            // 
            barStaticItem3.Caption = "Usuario";
            barStaticItem3.Id = 9;
            barStaticItem3.Name = "barStaticItem3";
            // 
            // bardDdllUser
            // 
            bardDdllUser.Caption = "Usuario asignado";
            bardDdllUser.Edit = repositoryItemComboBox1;
            bardDdllUser.Id = 10;
            bardDdllUser.Name = "bardDdllUser";
            bardDdllUser.Size = new System.Drawing.Size(100, 0);
            bardDdllUser.EditValueChanged += bardDdllUser_EditValueChanged;
            // 
            // repositoryItemComboBox1
            // 
            repositoryItemComboBox1.AutoHeight = false;
            repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // barStaticItem4
            // 
            barStaticItem4.Caption = "Estado";
            barStaticItem4.Id = 11;
            barStaticItem4.Name = "barStaticItem4";
            // 
            // barDdlState
            // 
            barDdlState.Caption = "Estado de la tarea";
            barDdlState.Edit = repositoryItemComboBox2;
            barDdlState.Id = 12;
            barDdlState.Name = "barDdlState";
            barDdlState.Size = new System.Drawing.Size(125, 0);
            barDdlState.EditValueChanged += barDdlState_EditValueChanged;
            // 
            // repositoryItemComboBox2
            // 
            repositoryItemComboBox2.AutoHeight = false;
            repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // barStaticItem5
            // 
            barStaticItem5.Caption = "Prioridad";
            barStaticItem5.Id = 13;
            barStaticItem5.Name = "barStaticItem5";
            // 
            // barDdlPriorities
            // 
            barDdlPriorities.Caption = "barEditItem3";
            barDdlPriorities.Edit = repositoryItemComboBox5;
            barDdlPriorities.Id = 18;
            barDdlPriorities.Name = "barDdlPriorities";
            barDdlPriorities.Size = new System.Drawing.Size(100, 0);
            barDdlPriorities.EditValueChanged += barDdlPriorities_EditValueChanged_1;
            // 
            // repositoryItemComboBox5
            // 
            repositoryItemComboBox5.AutoHeight = false;
            repositoryItemComboBox5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemComboBox5.Name = "repositoryItemComboBox5";
            // 
            // btnCleanFilters
            // 
            btnCleanFilters.Caption = "Limpiar filtros";
            btnCleanFilters.Id = 19;
            btnCleanFilters.Name = "btnCleanFilters";
            btnCleanFilters.ItemClick += btnCleanFilters_ItemClick;
            // 
            // bar3
            // 
            bar3.BarName = "Status bar";
            bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            bar3.DockCol = 0;
            bar3.DockRow = 0;
            bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            bar3.OptionsBar.AllowQuickCustomization = false;
            bar3.OptionsBar.DrawDragBorder = false;
            bar3.OptionsBar.UseWholeRow = true;
            bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new System.Drawing.Size(1453, 25);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 570);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new System.Drawing.Size(1453, 20);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 25);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 545);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(1453, 25);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 545);
            // 
            // barToggleSwitchItem1
            // 
            barToggleSwitchItem1.Caption = "barToggleSwitchItem1";
            barToggleSwitchItem1.Id = 0;
            barToggleSwitchItem1.Name = "barToggleSwitchItem1";
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "barButtonItem1";
            barButtonItem1.Id = 1;
            barButtonItem1.Name = "barButtonItem1";
            // 
            // barDdlPriority
            // 
            barDdlPriority.Caption = "Prioridad de la tarea";
            barDdlPriority.Edit = repositoryItemComboBox3;
            barDdlPriority.Id = 14;
            barDdlPriority.Name = "barDdlPriority";
            barDdlPriority.Size = new System.Drawing.Size(100, 0);
            // 
            // repositoryItemComboBox3
            // 
            repositoryItemComboBox3.AutoHeight = false;
            repositoryItemComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemComboBox3.Name = "repositoryItemComboBox3";
            // 
            // barEditItem6
            // 
            barEditItem6.Caption = "barEditItem6";
            barEditItem6.Edit = repositoryItemTextEdit1;
            barEditItem6.Id = 15;
            barEditItem6.Name = "barEditItem6";
            // 
            // repositoryItemTextEdit1
            // 
            repositoryItemTextEdit1.AutoHeight = false;
            repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barEditItem1
            // 
            barEditItem1.Caption = "Prioridad de la tarea";
            barEditItem1.Edit = repositoryItemComboBox4;
            barEditItem1.Id = 16;
            barEditItem1.Name = "barEditItem1";
            barEditItem1.Size = new System.Drawing.Size(100, 0);
            // 
            // repositoryItemComboBox4
            // 
            repositoryItemComboBox4.AutoHeight = false;
            repositoryItemComboBox4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemComboBox4.Name = "repositoryItemComboBox4";
            // 
            // barEditItem2
            // 
            barEditItem2.Caption = "barEditItem2";
            barEditItem2.Edit = repositoryItemTextEdit2;
            barEditItem2.Id = 17;
            barEditItem2.Name = "barEditItem2";
            // 
            // repositoryItemTextEdit2
            // 
            repositoryItemTextEdit2.AutoHeight = false;
            repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // XfrmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1453, 590);
            Controls.Add(gridControl);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "XfrmMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Administrador de tareas";
            ((System.ComponentModel.ISupportInitialize)gridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)virtualServerModeSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit1.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit2.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemDateEdit2).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Data.VirtualServerModeSource virtualServerModeSource;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarToggleSwitchItem barToggleSwitchItem1;
        private DevExpress.XtraBars.BarButtonItem addTask;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarStaticItem space;
        private DevExpress.XtraBars.BarEditItem barDateStart;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarStaticItem barLblDueDates;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarEditItem barDateEnd;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarEditItem bardDdllUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem4;
        private DevExpress.XtraBars.BarEditItem barDdlState;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem5;
        private DevExpress.XtraBars.BarEditItem barDdlPriority;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox3;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colState;
        private DevExpress.XtraGrid.Columns.GridColumn colPriority;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colNotes;
        private DevExpress.XtraBars.BarEditItem barEditItem6;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox4;
        private DevExpress.XtraBars.BarEditItem barDdlPriorities;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox5;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarButtonItem btnCleanFilters;
    }
}