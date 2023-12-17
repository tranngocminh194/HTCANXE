namespace HTCANXE.HeThong
{
    partial class frm_ChangePass
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
            this.panelAction = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtHoten = new DevExpress.XtraEditors.TextEdit();
            this.txtXN = new DevExpress.XtraEditors.TextEdit();
            this.txtMKM = new DevExpress.XtraEditors.TextEdit();
            this.txtMKC = new DevExpress.XtraEditors.TextEdit();
            this.txtNguoidung = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelAction)).BeginInit();
            this.panelAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMKM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMKC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoidung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.btnCancel);
            this.panelAction.Controls.Add(this.btnOK);
            this.panelAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAction.Location = new System.Drawing.Point(0, 172);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(394, 40);
            this.panelAction.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::HTCANXE.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(198, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Hủy bỏ";
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Image = global::HTCANXE.Properties.Resources.Ok;
            this.btnOK.Location = new System.Drawing.Point(112, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 30);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // layoutControl1
            // 
            //this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Appearance.ControlFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.layoutControl1.Appearance.ControlFocused.Options.UseBackColor = true;
            this.layoutControl1.Controls.Add(this.txtHoten);
            this.layoutControl1.Controls.Add(this.txtXN);
            this.layoutControl1.Controls.Add(this.txtMKM);
            this.layoutControl1.Controls.Add(this.txtMKC);
            this.layoutControl1.Controls.Add(this.txtNguoidung);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.HighlightFocusedItem = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(394, 172);
            this.layoutControl1.TabIndex = 7;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtHoten
            // 
            this.txtHoten.EditValue = "";
            this.txtHoten.EnterMoveNextControl = true;
            this.txtHoten.Location = new System.Drawing.Point(135, 60);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoten.Properties.Appearance.Options.UseFont = true;
            this.txtHoten.Properties.ReadOnly = true;
            this.txtHoten.Size = new System.Drawing.Size(247, 22);
            this.txtHoten.StyleController = this.layoutControl1;
            this.txtHoten.TabIndex = 9;
            // 
            // txtXN
            // 
            this.txtXN.EnterMoveNextControl = true;
            this.txtXN.Location = new System.Drawing.Point(135, 138);
            this.txtXN.Name = "txtXN";
            this.txtXN.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXN.Properties.Appearance.Options.UseFont = true;
            this.txtXN.Properties.MaxLength = 50;
            this.txtXN.Properties.PasswordChar = '*';
            this.txtXN.Size = new System.Drawing.Size(247, 22);
            this.txtXN.StyleController = this.layoutControl1;
            this.txtXN.TabIndex = 8;
            // 
            // txtMKM
            // 
            this.txtMKM.EnterMoveNextControl = true;
            this.txtMKM.Location = new System.Drawing.Point(135, 112);
            this.txtMKM.Name = "txtMKM";
            this.txtMKM.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMKM.Properties.Appearance.Options.UseFont = true;
            this.txtMKM.Properties.MaxLength = 50;
            this.txtMKM.Properties.PasswordChar = '*';
            this.txtMKM.Size = new System.Drawing.Size(247, 22);
            this.txtMKM.StyleController = this.layoutControl1;
            this.txtMKM.TabIndex = 8;
            // 
            // txtMKC
            // 
            this.txtMKC.EditValue = "";
            this.txtMKC.EnterMoveNextControl = true;
            this.txtMKC.Location = new System.Drawing.Point(135, 86);
            this.txtMKC.Name = "txtMKC";
            this.txtMKC.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMKC.Properties.Appearance.Options.UseFont = true;
            this.txtMKC.Properties.MaxLength = 50;
            this.txtMKC.Properties.PasswordChar = '*';
            this.txtMKC.Size = new System.Drawing.Size(247, 22);
            this.txtMKC.StyleController = this.layoutControl1;
            this.txtMKC.TabIndex = 8;
            // 
            // txtNguoidung
            // 
            this.txtNguoidung.EditValue = "";
            this.txtNguoidung.EnterMoveNextControl = true;
            this.txtNguoidung.Location = new System.Drawing.Point(135, 34);
            this.txtNguoidung.Name = "txtNguoidung";
            this.txtNguoidung.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoidung.Properties.Appearance.Options.UseFont = true;
            this.txtNguoidung.Properties.ReadOnly = true;
            this.txtNguoidung.Size = new System.Drawing.Size(247, 22);
            this.txtNguoidung.StyleController = this.layoutControl1;
            this.txtNguoidung.TabIndex = 8;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup1.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceGroup.Options.UseTextOptions = true;
            this.layoutControlGroup1.AppearanceGroup.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlGroup1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.CustomizationFormText = "ĐỔI MẬT KHẨU";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(394, 172);
            this.layoutControlGroup1.Text = "ĐỔI MẬT KHẨU";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtNguoidung;
            this.layoutControlItem1.CustomizationFormText = "Người dùng";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(374, 26);
            this.layoutControlItem1.Text = "Người sử dụng";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(119, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtMKC;
            this.layoutControlItem2.CustomizationFormText = "Mật khẩu cũ";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(374, 26);
            this.layoutControlItem2.Text = "Mật khẩu cũ";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(119, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtMKM;
            this.layoutControlItem3.CustomizationFormText = "Mật khẩu mới";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(374, 26);
            this.layoutControlItem3.Text = "Mật khẩu mới";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(119, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtXN;
            this.layoutControlItem4.CustomizationFormText = "Xác nhận";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 104);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(374, 26);
            this.layoutControlItem4.Text = "Lặp lại mật khẩu mới";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(119, 16);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtHoten;
            this.layoutControlItem5.CustomizationFormText = "Họ tên đầy đủ";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(374, 26);
            this.layoutControlItem5.Text = "Họ tên đầy đủ";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(119, 16);
            // 
            // frm_ChangePass
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(394, 212);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.panelAction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChangePass";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.frm_ChangePass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelAction)).EndInit();
            this.panelAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtHoten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMKM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMKC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoidung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelAction;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtXN;
        private DevExpress.XtraEditors.TextEdit txtMKM;
        private DevExpress.XtraEditors.TextEdit txtMKC;
        private DevExpress.XtraEditors.TextEdit txtNguoidung;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.TextEdit txtHoten;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}