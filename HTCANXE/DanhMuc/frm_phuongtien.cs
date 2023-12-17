using System;
using System.Linq;
using System.Windows.Forms;
using HTCANXE.Class;
using HTCANXE.Com;
using HTCANXE.Model;

namespace HTCANXE.DanhMuc
{
    public partial class frm_phuongtien : DevExpress.XtraBars.Ribbon.RibbonForm
    {      
        //Hàm ủy nhiệm cho formChild
        private void LoadDataView(string msg)
        {
            var lstptPhuongtiens = PhuongTien.GetlList();
            bindingSource.DataSource = lstptPhuongtiens;
            gridControl_phuongtien.DataSource = bindingSource;

            var lstnhompt = lstptPhuongtiens.GroupBy(n => n.Nhom).Select(n => n);
            bindingSourcenhom.DataSource = lstnhompt;
            gridControl_nhompt.DataSource = bindingSourcenhom;

        }

        private BindingSource bindingSource = new BindingSource();
        private BindingSource bindingSourcenhom = new BindingSource();
        

        public frm_phuongtien()
        {
            InitializeComponent();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {
        }
    
        private void frm_phuongtien_Load(object sender, EventArgs e)
        {
            LoadDataView("");
        }

        private void btn_edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var frm = new frm_edit_phuongtien();
            frm._ma = gridView2.GetFocusedRowCellValue("Ma").ToString();
            frm.SendMsg = LoadDataView;
            frm.Show();
        }

        private void btn_delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MessageBox.Show(@"xoa");
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            var frm = new frm_edit_phuongtien();
            frm._ma = string.Empty;
            frm.SendMsg=LoadDataView;
            frm.Show();
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            LoadDataView("");
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            string key = gridView1.GetFocusedRowCellValue("Key").ToString();
            var lstptPhuongtiens = PhuongTien.GetlList(key);
            bindingSource.DataSource = lstptPhuongtiens;
            gridControl_phuongtien.DataSource = bindingSource;
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            Common.db = new DataCanXeDataContext(Common.gConn);
            var v = Common.db.Fn_FindPhuongTien(txt_phuongtien.Text);
            bindingSource.DataSource = Utilities.LINQToDataTable(v);
            gridControl_phuongtien.DataSource = bindingSource;
        }
    }
}
