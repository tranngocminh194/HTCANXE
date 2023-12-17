using DevExpress.Utils;
using HTCANXE.Model;
using HTCANXE.Properties;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows.Forms;
using HTCANXE.Class;
using HTCANXE.Com;

namespace HTCANXE
{
    public partial class frm_Login : DevExpress.XtraEditors.XtraForm
    {
        public delegate void closeForms();
        public closeForms closeForm;
        private bool hideOptionDatabase;
        public static bool isSuccess;
        public bool logout;

        public frm_Login()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                loadRegistry();
                ShowInTaskbar = false;// Hien thi Focus form Login
                if (txtUserName.Text == "" && txtPassword.Text == "")
                {
                    SelectNextControl(txtUserName, true, true, true, true);
                }
                if (txtUserName.Text != "" && txtPassword.Text == "")
                {
                    SelectNextControl(txtPassword, true, true, true, true);
                }
                if (txtUserName.Text != "" && txtPassword.Text != "")
                {
                    SelectNextControl(txtUserName, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                ex.Message.Show(Name, MessageType.Error);
            }
        }
        private void frmLogin_Activated(object sender, EventArgs e)
        {
            if (logout)
            {
                txtPassword.Text = "";
                txtPassword.Focus();
            }
        }
        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (logout)
            {
                Common.frmM.Dispose();
            }

            Application.Exit();
        }
        private void btnDongY_Click(object sender, EventArgs e)
        {
            string valid = validData();
            if (valid == string.Empty)
            {
                try
                {
                    using (var wait = new WaitDialogForm(Common.gCaptionXLDL, Common.gTitle))
                    {
                        string user = txtUserName.Text.Trim();
                        //string pass = Utilities.Encrypt(txtPassword.Text.Trim(), Common.gKey, true);
                        string pass = txtPassword.Text.Trim();
                        string serverName = String.Format("Data Source={0}", txtServer.Text.Trim());
                        string databaseName = String.Format("Initial Catalog={0}", txtDatabase.Text.Trim());
                        string serverUser = String.Format("User ID={0}", txtUserDatabase.Text.Trim());
                        string serverPass = String.Format("Password={0}", txtPassDatabase.Text.Trim());
                        // Create ConnectionString
                        Common.gConn = String.Format("{0};{1};Persist Security Info=True;{2};{3}", serverName, databaseName, serverUser, serverPass);

                        // Connect
                        string result = Utilities.Connect(Common.gConn);

                        if (result == string.Empty) // Connect success
                        {
                            // Check User
                            if (User.CheckLogin(user, pass)) // Validated
                            {
                                // Check permission to access Branchs of User

                                // Save login info to Registry
                                saveRegistry();

                                // Save login info to class Common
                                saveInfoToCommon();

                                // Close frmSplash
                               // closeForm();

                                Common.frmL = this;

                                // Hide frmLogin
                                Hide();
                                isSuccess = true;
                                logout = false;
                                if (Settings.Default.UpdateData)
                                {
                                   Utilities.UpdateDataServer();
                                }
                                // Show frmMain
                                if (Common.frmM == null)
                                {
                                    wait.Close();
                                    Frm_Home fmdi = new Frm_Home();
                                    User.PhanQuyen(user, fmdi);
                                    fmdi.Show();
                                }
                                else
                                {
                                    wait.Close();
                                    Frm_Home frm = (Frm_Home)Common.frmM;
                                    //User.Permission(user, frm);
                                    frm.Show();
                                }
                            }
                            else // User not valid
                            {
                                wait.Close();
                                "Tên đăng nhập hoặc mật khẩu không đúng. \n\n\r Hoặc tài khoản không được kích hoạt.".Show(string.Empty, MessageType.Error);
                                txtUserName.Focus();
                                txtUserName.SelectAll();
                            }
                        }
                        else // Connect fail
                        {
                            wait.Close();
                            String.Format("Kiểm tra lại kết nối đến Máy chủ và CSDL.\n\n\rError Details: {0}", result).Show(string.Empty, MessageType.Error);
                            txtServer.Focus();
                            txtServer.SelectAll();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.Show(Name, MessageType.Error);
                }
            }
            else // Dữ liệu không hợp lệ
            {
                valid.Show(string.Empty, MessageType.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picKey_Click(object sender, EventArgs e)
        {
            if (hideOptionDatabase)
            {
                showOptionDatabase(0);
            }
            else
            {
                showOptionDatabase(1);
            }
        }
        private void btnKiemtra_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtServer.Text != string.Empty && txtDatabase.Text != string.Empty)
                {
                    using (var wait = new WaitDialogForm(Common.gCaptionXLDL, Common.gTitle))
                    {
                        string sServerName = String.Format("Data Source={0}", txtServer.Text.Trim());
                        string sDatabaseName = String.Format("Initial Catalog={0}", txtDatabase.Text.Trim());
                        string sserverUser = String.Format("User ID={0}", txtUserDatabase.Text.Trim());
                        string sserverPass = String.Format("Password={0}", txtPassDatabase.Text.Trim());

                        // Create ConnectionString
                        string result = Utilities.Connect(String.Format("{0};{1};Persist Security Info=True;{2};{3}", sServerName, sDatabaseName, sserverUser, sserverPass));
                        if (result == string.Empty)
                        {
                            wait.Close();
                            "Kiểm tra kết nối thành công.".Show(string.Empty, MessageType.Information);
                        }
                        else
                        {
                            wait.Close();
                            String.Format("Kiểm tra kết nối thất bại.\n\r{0}", result).Show(string.Empty, MessageType.Error);
                        }
                    }
                }
                else
                {
                    "Thông tin kiểm tra chưa hợp lệ.".Show(string.Empty, MessageType.Warning);
                    if (txtServer.Text == string.Empty)
                    {
                        txtServer.Focus();
                    }

                    if (txtDatabase.Text == string.Empty)
                    {
                        txtDatabase.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.Show(Name, MessageType.Error);
            }
        }
        private void saveInfoToCommon()
        {
            Common.db = new DataCanXeDataContext(Common.gConn);
            Common.gServer = txtServer.Text.Trim();
            Common.gDatabase = txtDatabase.Text.Trim();
            USER user = User.GetByUser(txtUserName.Text.Trim());
            Common.gIdNguoidung = user.UserId;
            Common.gNguoidung = user.Username;
            Common.gHoten = user.FullName;
            Common.gMatkhau = user.Password;
            Common.gTramCan = Settings.Default.TramCan;
            Common.gTenTramCan = Common.db.TRAMCANs.SingleOrDefault(n => n.Ma == Common.gTramCan)?.Ten;
            loadRegistryUpdateServerOnline();
        }
        private void loadRegistryUpdateServerOnline()
        {
            Common.gConnServer = (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Online\\HTCANXE", "ConnString", "");
        }

        private void loadRegistry()
        {
            if ((string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "SaveInfo", "1") == "1") // Có lưu mật khẩu
            {
                chkSaveInfoLogin.Checked = true;
                txtUserName.Text = (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "UserName", txtUserName.Text);
                txtPassword.Text = (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "Password", txtPassword.Text);
                txtServer.Text = (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "Server", txtServer.Text);
                txtDatabase.Text = (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "Database", txtDatabase.Text);
                txtUserDatabase.Text = (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "UserDatabase", txtUserDatabase.Text);
                txtPassDatabase.Text = (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "PassDatabase", txtPassDatabase.Text);
            }
            else // Không lưu mật khẩu
            {
                chkSaveInfoLogin.Checked = false;
                txtUserName.Text = (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "UserName", txtUserName.Text);
                txtServer.Text = (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "Server", txtServer.Text);
                txtDatabase.Text = (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "Database", txtDatabase.Text);
                txtUserDatabase.Text = (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "UserDatabase", txtUserDatabase.Text);
                txtPassDatabase.Text = (string)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "PassDatabase", txtPassDatabase.Text);
                txtPassword.Text = "";
            }

            // Kiểm tra thông tin Server và Database có chưa?
            if (String.IsNullOrEmpty(txtServer.Text) || String.IsNullOrEmpty(txtDatabase.Text))
            {
                showOptionDatabase(1);
            }
            else
            {
                showOptionDatabase(0);
            }

        }

        private void saveRegistry()
        {
            // Lưu thông tin đăng nhập sau cùng
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "UserName", txtUserName.Text);
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "Server", txtServer.Text);
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "Database", txtDatabase.Text);
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "UserDatabase", txtUserDatabase.Text);
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "PassDatabase", txtPassDatabase.Text);
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "ConnString", Common.gConn);
            if (chkSaveInfoLogin.Checked) // Lưu mật khẩu
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "SaveInfo", "1");
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "Password", txtPassword.Text);
            }
            else // Không lưu mật khẩu
            {
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "SaveInfo", "0");
                Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Offline\\HTCANXE", "Password", "");
            }
        }
        private void showOptionDatabase(int p)
        {
            if (p == 1)
            {
                hideOptionDatabase = true;
                Height = 333;
            }
            else
            {
                hideOptionDatabase = false;
                Height = 193;
            }
        }

        private string validData()
        {
            string valid = "";
            if (txtUserName.Text == "")
            {
                valid = "Người dùng không được bỏ trống.";
                txtUserName.Focus();
                return valid;
            }
            if (txtPassword.Text == "")
            {
                valid = "Mật khẩu không được bỏ trống.";
                txtPassword.Focus();
                return valid;
            }
            if (txtServer.Text == "")
            {
                valid = "Máy chủ không được bỏ trống.";
                showOptionDatabase(1);
                txtServer.Focus();
                return valid;
            }
            if (txtDatabase.Text == "")
            {
                valid = "Cơ sỡ dữ liệu không được bỏ trống.";
                showOptionDatabase(1);
                txtDatabase.Focus();
                return valid;
            }
            return valid;
        }

    }
}