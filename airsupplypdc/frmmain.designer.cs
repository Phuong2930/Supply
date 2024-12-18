namespace AirSupplyPDC
{
    partial class frmMain
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanelCell = new System.Windows.Forms.FlowLayoutPanel();
            this.listBoxConnect = new DevExpress.XtraEditors.ListBoxControl();
            this.gridLookUpEditArea = new DevExpress.XtraEditors.GridLookUpEdit();
            this.tb_AreaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNAME_ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlData = new DevExpress.XtraGrid.GridControl();
            this.transactionInforBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGuid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEventOccur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIPSend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSendData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRespondData = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colisSuccess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.flowLayoutPanelOnconveyor = new System.Windows.Forms.FlowLayoutPanel();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.itemRemain1 = new AirSupplyPDC.itemRemain();
            this.itemRemain2 = new AirSupplyPDC.itemRemain();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AreaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionInforBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            this.flowLayoutPanelOnconveyor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.flowLayoutPanelOnconveyor);
            this.layoutControl1.Controls.Add(this.btnUpdate);
            this.layoutControl1.Controls.Add(this.flowLayoutPanelCell);
            this.layoutControl1.Controls.Add(this.listBoxConnect);
            this.layoutControl1.Controls.Add(this.gridLookUpEditArea);
            this.layoutControl1.Controls.Add(this.gridControlData);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(964, 561);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.ImageOptions.Image = global::AirSupplyPDC.Properties.Resources.savepagesetup_16x16;
            this.btnUpdate.Location = new System.Drawing.Point(287, 52);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(72, 22);
            this.btnUpdate.StyleController = this.layoutControl1;
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // flowLayoutPanelCell
            // 
            this.flowLayoutPanelCell.AutoScroll = true;
            this.flowLayoutPanelCell.Location = new System.Drawing.Point(6, 78);
            this.flowLayoutPanelCell.Name = "flowLayoutPanelCell";
            this.flowLayoutPanelCell.Size = new System.Drawing.Size(952, 146);
            this.flowLayoutPanelCell.TabIndex = 7;
            // 
            // listBoxConnect
            // 
            this.listBoxConnect.Location = new System.Drawing.Point(363, 6);
            this.listBoxConnect.Name = "listBoxConnect";
            this.listBoxConnect.Size = new System.Drawing.Size(449, 68);
            this.listBoxConnect.StyleController = this.layoutControl1;
            this.listBoxConnect.TabIndex = 6;
            // 
            // gridLookUpEditArea
            // 
            this.gridLookUpEditArea.Location = new System.Drawing.Point(94, 6);
            this.gridLookUpEditArea.Name = "gridLookUpEditArea";
            this.gridLookUpEditArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLookUpEditArea.Properties.DataSource = this.tb_AreaBindingSource;
            this.gridLookUpEditArea.Properties.DisplayMember = "NAME_";
            this.gridLookUpEditArea.Properties.PopupView = this.gridLookUpEdit1View;
            this.gridLookUpEditArea.Properties.ValueMember = "ID_";
            this.gridLookUpEditArea.Size = new System.Drawing.Size(265, 20);
            this.gridLookUpEditArea.StyleController = this.layoutControl1;
            this.gridLookUpEditArea.TabIndex = 5;
            this.gridLookUpEditArea.EditValueChanged += new System.EventHandler(this.gridLookUpEditArea_EditValueChanged);
            // 
            // tb_AreaBindingSource
            // 
            this.tb_AreaBindingSource.DataSource = typeof(AirSupplyPDC.tb_Area);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNAME_});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colNAME_
            // 
            this.colNAME_.Caption = "Khu vực";
            this.colNAME_.FieldName = "NAME_";
            this.colNAME_.Name = "colNAME_";
            this.colNAME_.Visible = true;
            this.colNAME_.VisibleIndex = 0;
            // 
            // gridControlData
            // 
            this.gridControlData.DataSource = this.transactionInforBindingSource;
            this.gridControlData.Location = new System.Drawing.Point(6, 261);
            this.gridControlData.MainView = this.gridViewData;
            this.gridControlData.Name = "gridControlData";
            this.gridControlData.Size = new System.Drawing.Size(952, 294);
            this.gridControlData.TabIndex = 4;
            this.gridControlData.UseEmbeddedNavigator = true;
            this.gridControlData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewData});
            // 
            // transactionInforBindingSource
            // 
            this.transactionInforBindingSource.DataSource = typeof(AirSupplyPDC.TCP_IP.TransactionInfor);
            // 
            // gridViewData
            // 
            this.gridViewData.Appearance.EvenRow.BackColor = System.Drawing.Color.Azure;
            this.gridViewData.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewData.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridViewData.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Blue;
            this.gridViewData.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewData.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridViewData.Appearance.OddRow.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.gridViewData.Appearance.OddRow.Options.UseBackColor = true;
            this.gridViewData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGuid,
            this.colEventOccur,
            this.colIPSend,
            this.colSendData,
            this.colRespondData,
            this.colisSuccess});
            this.gridViewData.GridControl = this.gridControlData;
            this.gridViewData.Name = "gridViewData";
            this.gridViewData.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewData.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewData.OptionsBehavior.ReadOnly = true;
            this.gridViewData.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewData.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewData.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridViewData.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewData.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewData.OptionsView.ShowAutoFilterRow = true;
            this.gridViewData.OptionsView.ShowGroupPanel = false;
            this.gridViewData.RowSeparatorHeight = 1;
            // 
            // colGuid
            // 
            this.colGuid.FieldName = "Guid";
            this.colGuid.Name = "colGuid";
            this.colGuid.Width = 135;
            // 
            // colEventOccur
            // 
            this.colEventOccur.Caption = "Thời gian";
            this.colEventOccur.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss.fff";
            this.colEventOccur.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEventOccur.FieldName = "EventOccur";
            this.colEventOccur.MaxWidth = 150;
            this.colEventOccur.MinWidth = 150;
            this.colEventOccur.Name = "colEventOccur";
            this.colEventOccur.OptionsColumn.AllowEdit = false;
            this.colEventOccur.Visible = true;
            this.colEventOccur.VisibleIndex = 0;
            this.colEventOccur.Width = 150;
            // 
            // colIPSend
            // 
            this.colIPSend.Caption = "IP Gửi";
            this.colIPSend.FieldName = "IPSend";
            this.colIPSend.MaxWidth = 150;
            this.colIPSend.MinWidth = 150;
            this.colIPSend.Name = "colIPSend";
            this.colIPSend.Visible = true;
            this.colIPSend.VisibleIndex = 1;
            this.colIPSend.Width = 150;
            // 
            // colSendData
            // 
            this.colSendData.Caption = "Dữ liệu";
            this.colSendData.FieldName = "SendData";
            this.colSendData.MaxWidth = 150;
            this.colSendData.MinWidth = 150;
            this.colSendData.Name = "colSendData";
            this.colSendData.Visible = true;
            this.colSendData.VisibleIndex = 2;
            this.colSendData.Width = 150;
            // 
            // colRespondData
            // 
            this.colRespondData.Caption = "Hồi đáp";
            this.colRespondData.FieldName = "RespondData";
            this.colRespondData.Name = "colRespondData";
            this.colRespondData.Visible = true;
            this.colRespondData.VisibleIndex = 3;
            this.colRespondData.Width = 157;
            // 
            // colisSuccess
            // 
            this.colisSuccess.Caption = "Thành công";
            this.colisSuccess.FieldName = "isSuccess";
            this.colisSuccess.MaxWidth = 100;
            this.colisSuccess.MinWidth = 100;
            this.colisSuccess.Name = "colisSuccess";
            this.colisSuccess.Visible = true;
            this.colisSuccess.VisibleIndex = 4;
            this.colisSuccess.Width = 100;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.layoutControlItem5,
            this.emptySpaceItem3,
            this.layoutControlItem6});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup1.Size = new System.Drawing.Size(964, 561);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlData;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 255);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(956, 298);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.gridLookUpEditArea;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2);
            this.layoutControlItem2.Size = new System.Drawing.Size(357, 24);
            this.layoutControlItem2.Text = "Khu vực";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(77, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.flowLayoutPanelCell;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 150);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(104, 150);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(956, 150);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(810, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(146, 72);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.listBoxConnect;
            this.layoutControlItem3.Location = new System.Drawing.Point(357, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(453, 72);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(453, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(453, 72);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(357, 22);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnUpdate;
            this.layoutControlItem5.Location = new System.Drawing.Point(281, 46);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(76, 26);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(76, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(76, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 46);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(281, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // flowLayoutPanelOnconveyor
            // 
            this.flowLayoutPanelOnconveyor.Controls.Add(this.itemRemain1);
            this.flowLayoutPanelOnconveyor.Controls.Add(this.itemRemain2);
            this.flowLayoutPanelOnconveyor.Location = new System.Drawing.Point(86, 228);
            this.flowLayoutPanelOnconveyor.Name = "flowLayoutPanelOnconveyor";
            this.flowLayoutPanelOnconveyor.Size = new System.Drawing.Size(872, 29);
            this.flowLayoutPanelOnconveyor.TabIndex = 9;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.flowLayoutPanelOnconveyor;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 222);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(956, 33);
            this.layoutControlItem6.Text = "On conveyor";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(77, 14);
            // 
            // itemRemain1
            // 
            this.itemRemain1.Location = new System.Drawing.Point(3, 3);
            this.itemRemain1.MaximumSize = new System.Drawing.Size(100, 25);
            this.itemRemain1.MinimumSize = new System.Drawing.Size(100, 25);
            this.itemRemain1.Name = "itemRemain1";
            this.itemRemain1.RemainAdd = null;
            this.itemRemain1.Size = new System.Drawing.Size(100, 25);
            this.itemRemain1.TabIndex = 0;
            // 
            // itemRemain2
            // 
            this.itemRemain2.Location = new System.Drawing.Point(109, 3);
            this.itemRemain2.MaximumSize = new System.Drawing.Size(100, 25);
            this.itemRemain2.MinimumSize = new System.Drawing.Size(100, 25);
            this.itemRemain2.Name = "itemRemain2";
            this.itemRemain2.RemainAdd = null;
            this.itemRemain2.Size = new System.Drawing.Size(100, 25);
            this.itemRemain2.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 561);
            this.Controls.Add(this.layoutControl1);
            this.MaximumSize = new System.Drawing.Size(980, 600);
            this.MinimumSize = new System.Drawing.Size(980, 600);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AreaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionInforBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            this.flowLayoutPanelOnconveyor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControlData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEditArea;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource tb_AreaBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNAME_;
        private DevExpress.XtraGrid.Columns.GridColumn colGuid;
        private DevExpress.XtraGrid.Columns.GridColumn colEventOccur;
        private DevExpress.XtraGrid.Columns.GridColumn colIPSend;
        private DevExpress.XtraGrid.Columns.GridColumn colSendData;
        private DevExpress.XtraGrid.Columns.GridColumn colRespondData;
        private DevExpress.XtraGrid.Columns.GridColumn colisSuccess;
        private System.Windows.Forms.BindingSource transactionInforBindingSource;
        private DevExpress.XtraEditors.ListBoxControl listBoxConnect;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCell;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOnconveyor;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private itemRemain itemRemain1;
        private itemRemain itemRemain2;
    }
}

