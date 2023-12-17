using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HTCANXE.Model;

namespace HTCANXE.DanhMuc
{
    public partial class frm_edit_phuongtien : Form
    {
        public string _ma = string.Empty;
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
        public frm_edit_phuongtien()
        {
            InitializeComponent();
        }
        private void frm_edit_phuongtien_Load(object sender, EventArgs e)
        {
            listNhomKH.Add(new comboxItem() { Id = "XETAI", Name = "XETAI" });
            listNhomKH.Add(new comboxItem() { Id = "DAUKEO", Name = "DAUKEO" });
            listNhomKH.Add(new comboxItem() { Id = "ROMOOC", Name = "ROMOOC" });
            listNhomKH.Add(new comboxItem() { Id = "BETONG", Name = "BETONG" });
            lue_nhom.Properties.DataSource = listNhomKH;
            lue_nhom.Properties.DisplayMember = "Id";

            if (_ma != string.Empty)
            {
                Common.db = new DataCanXeDataContext(Common.gConn);
                var phuongtien = Common.db.PHUONGTIENs.Where(n => n.Ma == _ma).SingleOrDefault();
                if (phuongtien != null)
                {
                    txt_ma.Text = phuongtien.Ma;
                    txt_ten.Text = phuongtien.Ten;
                    lue_nhom.Text = phuongtien.Nhom;
                    txt_chu.Text = phuongtien.Chu;
                    txt_cmt.Text = phuongtien.SoCMT;
                    txt_sdt.Text = phuongtien.SDT;
                    txt_taitrong.Text = phuongtien.TaiTrong.ToString();
                    txt_trongluong.Text = phuongtien.TrongLuong.ToString();
                    txt_soniem.Text = phuongtien.SoNiem.ToString();
                }

                txt_ma.Enabled = false;
            }
            else
            {
                lue_nhom.Text = @"DAUKEO";
                txt_taitrong.Text = 0.ToString();
                txt_trongluong.Text = 0.ToString();
                txt_soniem.Text = 0.ToString();
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            var nhom = lue_nhom.GetSelectedDataRow() as comboxItem;
            if (_ma != string.Empty)
            {
                Common.db = new DataCanXeDataContext(Common.gConn);
                var phuongtien = Common.db.PHUONGTIENs.Where(n => n.Ma == _ma).SingleOrDefault();
                if (phuongtien != null)
                {
                    phuongtien.Ma = _ma;
                    phuongtien.Ten = txt_ten.Text;
                    if (nhom != null) phuongtien.Nhom = nhom.Id;
                    phuongtien.Chu = txt_chu.Text;
                    phuongtien.SoCMT = txt_cmt.Text;
                    phuongtien.SDT = txt_sdt.Text;
                    phuongtien.TaiTrong = Int32.Parse(txt_taitrong.Text);
                    phuongtien.TrongLuong = Int32.Parse(txt_trongluong.Text);
                    phuongtien.SoNiem = Int32.Parse(txt_soniem.Text);
                    phuongtien.IsActive = true;
                }

                Common.db.SubmitChanges();
            }
            else
            {
                Common.db = new DataCanXeDataContext(Common.gConn);
                PHUONGTIEN phuongtien = new PHUONGTIEN();
                phuongtien.Ma = txt_ma.Text;
                phuongtien.Ten = txt_ten.Text;
                if (nhom != null) phuongtien.Nhom = nhom.Id;
                phuongtien.Chu = txt_chu.Text;
                phuongtien.SoCMT = txt_cmt.Text;
                phuongtien.SDT = txt_sdt.Text;
                phuongtien.TaiTrong = Int32.Parse(txt_taitrong.Text);
                phuongtien.TrongLuong = Int32.Parse(txt_trongluong.Text);
                phuongtien.SoNiem = Int32.Parse(txt_soniem.Text);
                phuongtien.IsActive = true;
                phuongtien.IsDelete = false;
                phuongtien.CreateDate=DateTime.Now;
                Common.db.PHUONGTIENs.InsertOnSubmit(phuongtien);
                Common.db.SubmitChanges();
            }
            SendMsg.Invoke("");
            Close();
        }
    }
}
