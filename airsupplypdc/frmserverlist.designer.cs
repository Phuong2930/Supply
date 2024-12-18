namespace AirSupplyPDC
{
    partial class frmServerList
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.spinEditPort = new DevExpress.XtraEditors.SpinEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.serverInforBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repOn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colOff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repOff = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverInforBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnRemove);
            this.layoutControl1.Controls.Add(this.btnAdd);
            this.layoutControl1.Controls.Add(this.spinEditPort);
            this.layoutControl1.Controls.Add(this.gridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(462, 318);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnRemove
            // 
            this.btnRemove.ImageOptions.Image = global::AirSupplyPDC.Properties.Resources.cancel_16x16;
            this.btnRemove.Location = new System.Drawing.Point(400, 7);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(55, 22);
            this.btnRemove.StyleController = this.layoutControl1;
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Xóa";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = global::AirSupplyPDC.Properties.Resources.addchartpane_16x16;
            this.btnAdd.Location = new System.Drawing.Point(233, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(67, 24);
            this.btnAdd.StyleController = this.layoutControl1;
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // spinEditPort
            // 
            this.spinEditPort.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditPort.Location = new System.Drawing.Point(38, 7);
            this.spinEditPort.Name = "spinEditPort";
            this.spinEditPort.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinEditPort.Properties.Appearance.Options.UseFont = true;
            this.spinEditPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditPort.Properties.IsFloatValue = false;
            this.spinEditPort.Properties.Mask.EditMask = "N00";
            this.spinEditPort.Properties.MaxValue = new decimal(new int[] {
            65500,
            0,
            0,
            0});
            this.spinEditPort.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditPort.Size = new System.Drawing.Size(191, 24);
            this.spinEditPort.StyleController = this.layoutControl1;
            this.spinEditPort.TabIndex = 5;
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.serverInforBindingSource;
            this.gridControl.Location = new System.Drawing.Point(7, 35);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repOff,
            this.repOn});
            this.gridControl.Size = new System.Drawing.Size(448, 276);
            this.gridControl.TabIndex = 4;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // serverInforBindingSource
            // 
            this.serverInforBindingSource.DataSource = typeof(AirSupplyPDC.TCP_IP.ServerInfor);
            // 
            // gridView
            // 
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPort,
            this.colOn,
            this.colOff});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsView.ShowAutoFilterRow = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.RowSeparatorHeight = 1;
            this.gridView.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView_CustomRowCellEdit);
            // 
            // colPort
            // 
            this.colPort.FieldName = "Port";
            this.colPort.Name = "colPort";
            this.colPort.Visible = true;
            this.colPort.VisibleIndex = 0;
            // 
            // colOn
            // 
            this.colOn.Caption = "Bật";
            this.colOn.ColumnEdit = this.repOn;
            this.colOn.MaxWidth = 100;
            this.colOn.MinWidth = 100;
            this.colOn.Name = "colOn";
            this.colOn.Visible = true;
            this.colOn.VisibleIndex = 1;
            this.colOn.Width = 100;
            // 
            // repOn
            // 
            this.repOn.AutoHeight = false;
            editorButtonImageOptions1.Image = global::AirSupplyPDC.Properties.Resources.media_16x16;
            this.repOn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repOn.Name = "repOn";
            this.repOn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repOn.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repOn_ButtonClick);
            // 
            // colOff
            // 
            this.colOff.Caption = "Tắt";
            this.colOff.ColumnEdit = this.repOff;
            this.colOff.MaxWidth = 100;
            this.colOff.MinWidth = 100;
            this.colOff.Name = "colOff";
            this.colOff.Visible = true;
            this.colOff.VisibleIndex = 2;
            this.colOff.Width = 100;
            // 
            // repOff
            // 
            this.repOff.AutoHeight = false;
            editorButtonImageOptions2.Image = global::AirSupplyPDC.Properties.Resources.cancel_16x161;
            this.repOff.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repOff.Name = "repOff";
            this.repOff.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repOff.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repOff_ButtonClick);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new System.Drawing.Size(462, 318);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(452, 280);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.spinEditPort;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(226, 28);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(226, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2);
            this.layoutControlItem2.Size = new System.Drawing.Size(226, 28);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Port";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(20, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnAdd;
            this.layoutControlItem3.Location = new System.Drawing.Point(226, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(71, 28);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(71, 28);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(71, 28);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(297, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(96, 28);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnRemove;
            this.layoutControlItem4.Location = new System.Drawing.Point(393, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(59, 28);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // frmServerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 318);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmServerList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách máy chủ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverInforBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource serverInforBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPort;
        public DevExpress.XtraGrid.Columns.GridColumn colOn;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repOn;
        private DevExpress.XtraGrid.Columns.GridColumn colOff;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repOff;
        private DevExpress.XtraEditors.SpinEdit spinEditPort;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}