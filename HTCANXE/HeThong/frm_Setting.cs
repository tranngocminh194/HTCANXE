using System;
using System.Windows.Forms;
using HTCANXE.Properties;

namespace HTCANXE.HeThong
{
    public partial class frm_Setting : Form
    {
        public frm_Setting()
        {
            InitializeComponent();
        }

        private void frm_Setting_Load(object sender, EventArgs e)
        {
            if (Settings.Default.Modem == "N")
            {
                rdo_MK.Checked = true;
            }
            else
            {
                rdo_Other.Checked = true;
            }
            Settings.Default.PortName = "COM2";
            cbo_COMport.Text = Settings.Default.PortName;
            cbo_baudrate.Text = Settings.Default.BaudRate.ToString();
            cbo_databits.Text = Settings.Default.DataBits.ToString();
            cbo_parity.Text = Settings.Default.Parity.ToString();
            cbo_stopbits.Text = Settings.Default.StopBits.ToString();



            Settings.Default.Save();
        }

        private void btn_huycapnhatcan_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_luu2_Click(object sender, EventArgs e)
        {
            if (rdo_MK.Checked)
            {
                Settings.Default.Modem = "N";
            }
            else
            {
                if (rdo_CAS.Checked)
                {
                    Settings.Default.Modem = "C";
                }
                else
                {
                    if (rdo_RIS.Checked)
                    {
                        Settings.Default.Modem = "R";
                    }
                    else
                    {
                        Settings.Default.Modem = "O";
                    }
                }
            }
            Settings.Default.Save();
            Close();
        }

        private void btn_luu1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_huy1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
