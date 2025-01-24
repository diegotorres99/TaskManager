namespace TaskManagerApp
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            popupControlContainer1 = new DevExpress.XtraBars.PopupControlContainer(components);
            gridSplitContainer1 = new DevExpress.XtraGrid.GridSplitContainer();
            gridSplitContainer1Grid = new DevExpress.XtraGrid.GridControl();
            gridSplitContainer1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)popupControlContainer1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridSplitContainer1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridSplitContainer1.Panel1).BeginInit();
            gridSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSplitContainer1.Panel2).BeginInit();
            gridSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSplitContainer1Grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridSplitContainer1View).BeginInit();
            SuspendLayout();
            // 
            // popupControlContainer1
            // 
            popupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            popupControlContainer1.Location = new Point(0, 0);
            popupControlContainer1.Name = "popupControlContainer1";
            popupControlContainer1.Size = new Size(250, 130);
            popupControlContainer1.TabIndex = 0;
            popupControlContainer1.Visible = false;
            // 
            // gridSplitContainer1
            // 
            gridSplitContainer1.Grid = gridSplitContainer1Grid;
            gridSplitContainer1.Location = new Point(529, 192);
            gridSplitContainer1.Name = "gridSplitContainer1";
            // 
            // gridSplitContainer1.Panel1
            // 
            gridSplitContainer1.Panel1.Controls.Add(gridSplitContainer1Grid);
            gridSplitContainer1.Panel1.Text = "Panel1";
            // 
            // gridSplitContainer1.Panel2
            // 
            gridSplitContainer1.Panel2.Text = "Panel2";
            gridSplitContainer1.Size = new Size(500, 500);
            gridSplitContainer1.TabIndex = 0;
            // 
            // gridSplitContainer1Grid
            // 
            gridSplitContainer1Grid.Dock = DockStyle.Fill;
            gridSplitContainer1Grid.Location = new Point(0, 0);
            gridSplitContainer1Grid.MainView = gridSplitContainer1View;
            gridSplitContainer1Grid.Name = "gridSplitContainer1Grid";
            gridSplitContainer1Grid.Size = new Size(500, 500);
            gridSplitContainer1Grid.TabIndex = 0;
            gridSplitContainer1Grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridSplitContainer1View });
            // 
            // gridSplitContainer1View
            // 
            gridSplitContainer1View.GridControl = gridSplitContainer1Grid;
            gridSplitContainer1View.Name = "gridSplitContainer1View";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1339, 828);
            Controls.Add(gridSplitContainer1);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrador de tareas";
            UseWaitCursor = true;
            ((System.ComponentModel.ISupportInitialize)popupControlContainer1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridSplitContainer1.Panel1).EndInit();
            gridSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridSplitContainer1.Panel2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridSplitContainer1).EndInit();
            gridSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridSplitContainer1Grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridSplitContainer1View).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.PopupControlContainer popupControlContainer1;
        private DevExpress.XtraGrid.GridSplitContainer gridSplitContainer1;
        private DevExpress.XtraGrid.GridControl gridSplitContainer1Grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridSplitContainer1View;
    }
}
