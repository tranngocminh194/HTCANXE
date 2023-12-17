using System;
using HTCANXE.Class;
using HTCANXE.Com;

namespace HTCANXE.HeThong
{
    public partial class frm_ChangePass : DevExpress.XtraEditors.XtraForm
    {
        public frm_ChangePass()
        {
            InitializeComponent();
        }

        private void frm_ChangePass_Load(object sender, EventArgs e)
        {
            txtNguoidung.Text = Common.gNguoidung;
            txtHoten.Text = Common.gHoten;
            SelectNextControl(txtMKC, true, true, true, true);
        }

        private string validData()
        {
            string valid = String.Empty;
            if (String.IsNullOrEmpty(txtMKC.Text))
            {
                valid = "[Mật khẩu cũ] không được bỏ trống.";
                txtMKC.Focus();
                return valid;
            }
            if (String.IsNullOrEmpty(txtMKM.Text))
            {
                valid = "[Mật khẩu mới] không được bỏ trống.";
                txtMKM.Focus();
                return valid;
            }
            if (String.IsNullOrEmpty(txtXN.Text))
            {
                valid = "[Xác nhận mật khẩu mới] không được bỏ trống.";
                txtXN.Focus();
                return valid;
            }
            if (txtMKM.Text.Trim() != txtXN.Text.Trim())
            {
                valid = "[Mật khẩu mới] và [Xác nhận mật khẩu mới] không khớp với nhau.\n\n\rVui lòng kiểm tra lại!";
                txtMKM.Focus();
                return valid;
            }
            return valid;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string valid = validData();
            if (valid == "")
            {
                try
                {
                    if (User.CheckLogin(Common.gNguoidung, txtMKC.Text))
                    {
                        Model.USER user = new Model.USER();
                        user.Username = Common.gNguoidung;
                        user.IsActive = true;
                        user.Password = txtMKM.Text;
                        string result = User.Edit(user);
                        if (result != "")
                        {
                            "Đổi mật khẩu thất bại vui lòng thử lại.".Show("", MessageType.Error);
                        }
                        else
                        {
                            "Đổi mật khẩu thành công.".Show("", MessageType.Information);
                        }
                        Close();
                    }
                    else
                    {
                        "[Mật khẩu cũ] không hợp lệ.\n\n\rVui lòng kiểm tra lại!".Show("", MessageType.Error);
                        txtMKC.Focus();
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.Show(Name, MessageType.Error);
                }
            }
            else
            {
                valid.Show("", MessageType.Warning);
            }
        }
    }
}