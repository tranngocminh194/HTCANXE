using HTCANXE.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace HTCANXE
{
    public partial class frm_edit_khachhang : Form
    {
        public string idkhachhang = "";
        //Định nghĩa delegate
        public delegate void DelSendMsg(string msg);
        //khạ báo biến kiểu delegate
        public DelSendMsg SendMsg;
        public class comboxItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
        public List<comboxItem> listNhomKH = new List<comboxItem>();
        public frm_edit_khachhang()
        {
            InitializeComponent();
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            var nhomkh = lue_nhomkh.GetSelectedDataRow() as comboxItem;

            if (idkhachhang != "")
            {
                Common.db = new DataCanXeDataContext(Common.gConn);
                var newkhachhang = Common.db.KHACHHANGs.Where(n => n.Ma == idkhachhang).SingleOrDefault();
                newkhachhang.Ten = txt_tenkhachhang.Text;
                newkhachhang.Nhom = nhomkh.Id;
                newkhachhang.DiaChi = txt_diachi.Text;
                newkhachhang.NguoiLH = txt_nguoilienhe.Text;
                newkhachhang.SDT = txt_sdt.Text;
                newkhachhang.GhiChu = txt_ghichu.Text;
                Common.db.SubmitChanges();
            }
            else
            {
                Common.db = new DataCanXeDataContext(Common.gConn);
                KHACHHANG newkhachhang = new KHACHHANG();
                newkhachhang.Ma = (Int32.Parse(Common.db.KHACHHANGs.Max(n => n.Ma)) + 1).ToString();
                newkhachhang.Ten = txt_tenkhachhang.Text;
                newkhachhang.Nhom = nhomkh.Id;
                newkhachhang.DiaChi = txt_diachi.Text;
                newkhachhang.NguoiLH = txt_nguoilienhe.Text;
                newkhachhang.SDT = txt_sdt.Text;
                newkhachhang.GhiChu = txt_ghichu.Text;
                newkhachhang.IsActive = true;
                newkhachhang.CreateDate = DateTime.Now;
                newkhachhang.IsDelete = false;
                Common.db.KHACHHANGs.InsertOnSubmit(newkhachhang);
                Common.db.SubmitChanges();
            }
            SendMsg.Invoke("");

            this.Close();
        }
    private void frm_edit_khachhang_Load(object sender, EventArgs e)
        {
            listNhomKH.Add(new comboxItem() { Id = "KH.XA", Name = "KH.XA" });
            listNhomKH.Add(new comboxItem() { Id = "KH.BAO", Name = "KH.BAO" });
            listNhomKH.Add(new comboxItem() { Id = "KH.PL", Name = "KH.PL" });
            lue_nhomkh.Properties.DataSource = listNhomKH;
            lue_nhomkh.Properties.DisplayMember = "Id";
            txt_makhachhang.Text = idkhachhang.ToString();
            // GetDataCombobox();
            if (idkhachhang != "")
            {
                Common.db = new DataCanXeDataContext(Common.gConn);
                var resurt = Common.db.KHACHHANGs.Single(n => n.Ma == idkhachhang);
                txt_makhachhang.Text = resurt.Ma;
                txt_tenkhachhang.Text = resurt.Ten;
                lue_nhomkh.Text = resurt.Nhom;
                txt_diachi.Text = resurt.DiaChi;
                txt_nguoilienhe.Text = resurt.NguoiLH;
                txt_sdt.Text = resurt.SDT;
                txt_ghichu.Text = resurt.GhiChu;
                txt_diachi.Text = resurt.DiaChi.ToString();
            }
        }
    }
}
