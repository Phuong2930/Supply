namespace AirSupplyPDC
{
    partial class frmStore
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.flowLayoutPanelOnchange = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toggleSwitchEnable = new DevExpress.XtraEditors.ToggleSwitch();
            this.lbCabinet = new DevExpress.XtraEditors.LabelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnConv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitchEnable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.flowLayoutPanelOnchange);
            this.layoutControl1.Controls.Add(this.flowLayoutPanel);
            this.layoutControl1.Controls.Add(this.toggleSwitchEnable);
            this.layoutControl1.Controls.Add(this.lbCabinet);
            this.layoutControl1.Controls.Add(this.gridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1154, 709);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // flowLayoutPanelOnchange
            // 
            this.flowLayoutPanelOnchange.AutoScroll = true;
            this.flowLayoutPanelOnchange.Location = new System.Drawing.Point(846, 570);
            this.flowLayoutPanelOnchange.Name = "flowLayoutPanelOnchange";
            this.flowLayoutPanelOnchange.Size = new System.Drawing.Size(304, 135);
            this.flowLayoutPanelOnchange.TabIndex = 9;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(838, 701);
            this.flowLayoutPanel.TabIndex = 8;
            // 
            // toggleSwitchEnable
            // 
            this.toggleSwitchEnable.Location = new System.Drawing.Point(846, 4);
            this.toggleSwitchEnable.Name = "toggleSwitchEnable";
            this.toggleSwitchEnable.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleSwitchEnable.Properties.Appearance.Options.UseFont = true;
            this.toggleSwitchEnable.Properties.OffText = "Dừng cấp";
            this.toggleSwitchEnable.Properties.OnText = "Cấp";
            this.toggleSwitchEnable.Size = new System.Drawing.Size(113, 20);
            this.toggleSwitchEnable.StyleController = this.layoutControl1;
            this.toggleSwitchEnable.TabIndex = 7;
            this.toggleSwitchEnable.Toggled += new System.EventHandler(this.toggleSwitchEnable_Toggled);
            // 
            // lbCabinet
            // 
            this.lbCabinet.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbCabinet.Appearance.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCabinet.Appearance.Options.UseBackColor = true;
            this.lbCabinet.Appearance.Options.UseFont = true;
            this.lbCabinet.Appearance.Options.UseTextOptions = true;
            this.lbCabinet.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbCabinet.Location = new System.Drawing.Point(963, 4);
            this.lbCabinet.Name = "lbCabinet";
            this.lbCabinet.Size = new System.Drawing.Size(187, 77);
            this.lbCabinet.StyleController = this.layoutControl1;
            this.lbCabinet.TabIndex = 6;
            this.lbCabinet.Text = "00";
            // 
            // gridControl
            // 
            this.gridControl.Location = new System.Drawing.Point(846, 85);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(304, 465);
            this.gridControl.TabIndex = 5;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPart,
            this.colOnConv,
            this.colRemain,
            this.colEmpty});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsView.ShowAutoFilterRow = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.RowHeight = 26;
            this.gridView.RowSeparatorHeight = 2;
            // 
            // colPart
            // 
            this.colPart.Caption = "Mã linh kiện";
            this.colPart.FieldName = "Part_";
            this.colPart.MinWidth = 80;
            this.colPart.Name = "colPart";
            this.colPart.Visible = true;
            this.colPart.VisibleIndex = 0;
            this.colPart.Width = 100;
            // 
            // colOnConv
            // 
            this.colOnConv.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colOnConv.AppearanceCell.Options.UseFont = true;
            this.colOnConv.Caption = "Đang";
            this.colOnConv.FieldName = "Oncon_";
            this.colOnConv.MaxWidth = 50;
            this.colOnConv.MinWidth = 50;
            this.colOnConv.Name = "colOnConv";
            this.colOnConv.Visible = true;
            this.colOnConv.VisibleIndex = 1;
            this.colOnConv.Width = 50;
            // 
            // colRemain
            // 
            this.colRemain.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colRemain.AppearanceCell.Options.UseFont = true;
            this.colRemain.Caption = "Kho";
            this.colRemain.FieldName = "Remain_";
            this.colRemain.MaxWidth = 50;
            this.colRemain.MinWidth = 50;
            this.colRemain.Name = "colRemain";
            this.colRemain.Visible = true;
            this.colRemain.VisibleIndex = 2;
            this.colRemain.Width = 50;
            // 
            // colEmpty
            // 
            this.colEmpty.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colEmpty.AppearanceCell.Options.UseFont = true;
            this.colEmpty.Caption = "Trống";
            this.colEmpty.FieldName = "Empty_";
            this.colEmpty.MaxWidth = 50;
            this.colEmpty.MinWidth = 50;
            this.colEmpty.Name = "colEmpty";
            this.colEmpty.Visible = true;
            this.colEmpty.VisibleIndex = 3;
            this.colEmpty.Width = 50;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1154, 709);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl;
            this.layoutControlItem2.Location = new System.Drawing.Point(842, 81);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(308, 0);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(308, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(308, 469);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lbCabinet;
            this.layoutControlItem3.Location = new System.Drawing.Point(959, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(191, 81);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(191, 81);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(191, 81);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(842, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(117, 57);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.toggleSwitchEnable;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem4.Location = new System.Drawing.Point(842, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(117, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(117, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(117, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.flowLayoutPanel;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(842, 705);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.flowLayoutPanelOnchange;
            this.layoutControlItem5.Location = new System.Drawing.Point(842, 550);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(308, 155);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(308, 155);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(308, 155);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "On conveyor";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(62, 13);
            // 
            // frmStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 709);
            this.Controls.Add(this.layoutControl1);
            this.MinimizeBox = false;
            this.Name = "frmStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Location";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStore_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitchEnable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colPart;
        private DevExpress.XtraGrid.Columns.GridColumn colRemain;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpty;
        private DevExpress.XtraGrid.Columns.GridColumn colOnConv;
        private DevExpress.XtraEditors.LabelControl lbCabinet;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitchEnable;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOnchange;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}