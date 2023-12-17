namespace HTCANXE
{
    partial class frm_edit_congtrinh
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txt_diachi = new DevExpress.XtraEditors.TextEdit();
            this.txt_tencongtrinh = new DevExpress.XtraEditors.TextEdit();
            this.txt_macongtrinh = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btn_huy = new DevExpress.XtraEditors.SimpleButton();
            this.btn_luu = new DevExpress.XtraEditors.SimpleButton();
            this.cbo_khachhang = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lue_tinhthanh = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_diachi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tencongtrinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_macongtrinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_khachhang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_tinhthanh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupControl1.Controls.Add(this.txt_diachi);
            this.groupControl1.Controls.Add(this.txt_tencongtrinh);
            this.groupControl1.Controls.Add(this.txt_macongtrinh);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btn_huy);
            this.groupControl1.Controls.Add(this.btn_luu);
            this.groupControl1.Controls.Add(this.cbo_khachhang);
            this.groupControl1.Controls.Add(this.lue_tinhthanh);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(515, 308);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Cập nhật công trình";
            // 
            // txt_diachi
            // 
            this.txt_diachi.Location = new System.Drawing.Point(142, 164);
            this.txt_diachi.Name = "txt_diachi";
            this.txt_diachi.Size = new System.Drawing.Size(338, 22);
            this.txt_diachi.TabIndex = 2;
            // 
            // txt_tencongtrinh
            // 
            this.txt_tencongtrinh.Location = new System.Drawing.Point(142, 84);
            this.txt_tencongtrinh.Name = "txt_tencongtrinh";
            this.txt_tencongtrinh.Size = new System.Drawing.Size(338, 22);
            this.txt_tencongtrinh.TabIndex = 2;
            // 
            // txt_macongtrinh
            // 
            this.txt_macongtrinh.Location = new System.Drawing.Point(142, 45);
            this.txt_macongtrinh.Name = "txt_macongtrinh";
            this.txt_macongtrinh.Properties.ReadOnly = true;
            this.txt_macongtrinh.Size = new System.Drawing.Size(117, 22);
            this.txt_macongtrinh.TabIndex = 2;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(34, 204);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(71, 17);
            this.labelControl7.TabIndex = 1;
            this.labelControl7.Text = "Tỉnh thành:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(34, 167);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 17);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Địa chỉ:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(34, 127);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(71, 16);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Khách hàng:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(34, 87);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tên công trình:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 50);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(83, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Mã công trình:";
            // 
            // btn_huy
            // 
            this.btn_huy.Location = new System.Drawing.Point(383, 247);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(97, 34);
            this.btn_huy.TabIndex = 0;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.Location = new System.Drawing.Point(263, 247);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(97, 34);
            this.btn_luu.TabIndex = 0;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // cbo_khachhang
            // 
            this.cbo_khachhang.Location = new System.Drawing.Point(142, 124);
            this.cbo_khachhang.Name = "cbo_khachhang";
            this.cbo_khachhang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_khachhang.Properties.DisplayMember = "Ten";
            this.cbo_khachhang.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbo_khachhang.Properties.ValueMember = "Ma";
            this.cbo_khachhang.Properties.View = this.gridLookUpEdit1View;
            this.cbo_khachhang.Size = new System.Drawing.Size(338, 22);
            this.cbo_khachhang.TabIndex = 3;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã";
            this.gridColumn1.FieldName = "Ma";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên";
            this.gridColumn2.FieldName = "Ten";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // lue_tinhthanh
            // 
            this.lue_tinhthanh.Location = new System.Drawing.Point(142, 200);
            this.lue_tinhthanh.Name = "lue_tinhthanh";
            this.lue_tinhthanh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lue_tinhthanh.Properties.DisplayMember = "Ma";
            this.lue_tinhthanh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lue_tinhthanh.Properties.ValueMember = "Ten";
            this.lue_tinhthanh.Properties.View = this.gridView1;
            this.lue_tinhthanh.Size = new System.Drawing.Size(338, 22);
            this.lue_tinhthanh.TabIndex = 3;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // frm_edit_congtrinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 308);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_edit_congtrinh";
            this.Text = "frm_edit_congtrinh";
            this.Load += new System.EventHandler(this.frm_edit_congtrinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_diachi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tencongtrinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_macongtrinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_khachhang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lue_tinhthanh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txt_diachi;
        private DevExpress.XtraEditors.TextEdit txt_tencongtrinh;
        private DevExpress.XtraEditors.TextEdit txt_macongtrinh;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_huy;
        private DevExpress.XtraEditors.SimpleButton btn_luu;
        private DevExpress.XtraEditors.GridLookUpEdit cbo_khachhang;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.GridLookUpEdit lue_tinhthanh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}