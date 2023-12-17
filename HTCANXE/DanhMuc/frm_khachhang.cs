using System;
using System.Windows.Forms;
using HTCANXE.Class;

namespace HTCANXE.DanhMuc
{
    public partial class frm_khachhang : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private BindingSource bindingSource = new BindingSource();
        public frm_khachhang()
        {
            InitializeComponent();
        }
        private void ribbon_Click(object sender, EventArgs e)
        {
        }
        private void frm_khachhang_Load(object sender, EventArgs e)
        {
            LoadDataView("");
        }
        private void LoadDataView(string msg)
        {
            var lst = CongTy.GetlList("");
            bindingSource.DataSource = lst;
            gridControl_congtrinh.DataSource = bindingSource;
        }
        private void btn_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var frm = new frm_edit_khachhang();
            frm.idkhachhang = gridView2.GetFocusedRowCellValue("Ma").ToString();
            frm.SendMsg = LoadDataView;
            frm.Show();
        }

        private void btn_delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MessageBox.Show(@"xoa");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var frm = new frm_edit_khachhang();
            frm.idkhachhang = "";
            frm.SendMsg = LoadDataView;
            frm.Show();
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            LoadDataView("");
        }
    }
}
