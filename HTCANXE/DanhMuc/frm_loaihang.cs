using System;
using System.Windows.Forms;
using HTCANXE.Class;

namespace HTCANXE.DanhMuc
{
    public partial class frm_loaihang : DevExpress.XtraBars.Ribbon.RibbonForm
    {      
        //Hàm ủy nhiệm cho formChild
        private void LoadDataView(string msg)
        {
            var lstHanghoas = HangHoa.GetlList();
            bindingSource.DataSource = lstHanghoas;
            gridControl_loaihang.DataSource = bindingSource;
        }


        private BindingSource bindingSource = new BindingSource();
        public frm_loaihang()
        {
            InitializeComponent();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {
        }
    
        private void frm_loaihang_Load(object sender, EventArgs e)
        {
            LoadDataView("");
        }

        private void btn_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var frm = new frm_edit_loaihang();
            frm.Mahang = gridView2.GetFocusedRowCellValue("Ma").ToString();
            frm.SendMsg = LoadDataView;
            frm.Show();
        }

        private void btn_delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MessageBox.Show(@"xoa");
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            var frm = new frm_edit_loaihang();
            frm.Mahang = string.Empty;
            frm.SendMsg=LoadDataView;
            frm.Show();
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            LoadDataView("");
        }
    }
}
