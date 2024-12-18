namespace AirSupplyPDC
{
    partial class itemPart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.lbName = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.lbName);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Margin = new System.Windows.Forms.Padding(0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup;
            this.layoutControl.Size = new System.Drawing.Size(105, 25);
            this.layoutControl.TabIndex = 0;
            this.layoutControl.Text = "layoutControl1";
            // 
            // lbName
            // 
            this.lbName.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.lbName.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Appearance.Options.UseBackColor = true;
            this.lbName.Appearance.Options.UseFont = true;
            this.lbName.Appearance.Options.UseTextOptions = true;
            this.lbName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbName.Location = new System.Drawing.Point(2, 2);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(101, 21);
            this.lbName.StyleController = this.layoutControl;
            this.lbName.TabIndex = 4;
            // 
            // layoutControlGroup
            // 
            this.layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup.GroupBordersVisible = false;
            this.layoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem});
            this.layoutControlGroup.Name = "layoutControlGroup";
            this.layoutControlGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup.Size = new System.Drawing.Size(105, 25);
            this.layoutControlGroup.TextVisible = false;
            // 
            // layoutControlItem
            // 
            this.layoutControlItem.Control = this.lbName;
            this.layoutControlItem.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem.Name = "layoutControlItem";
            this.layoutControlItem.Size = new System.Drawing.Size(105, 25);
            this.layoutControlItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem.TextVisible = false;
            // 
            // itemPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl);
            this.MaximumSize = new System.Drawing.Size(105, 25);
            this.MinimumSize = new System.Drawing.Size(105, 25);
            this.Name = "itemPart";
            this.Size = new System.Drawing.Size(105, 25);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup;
        private DevExpress.XtraEditors.LabelControl lbName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem;
    }
}
