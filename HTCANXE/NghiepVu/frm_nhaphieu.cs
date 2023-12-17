using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraReports.UI;
using HTCANXE.Com;
using HTCANXE.Model;
using HTCANXE.Report;

namespace HTCANXE.NghiepVu
{
    public partial class frm_nhaphieu : DevExpress.XtraEditors.XtraForm
    {
        
        public string IDNXIDNX;
        public DateTime ngayct;

        public frm_nhaphieu()
        {
            InitializeComponent();
        }

        private void frmNhap_Load(object sender, EventArgs e)
        {
            Common.db = new DataCanXeDataContext(Common.gConn);
            using (new WaitDialogForm(Common.gCaptionNDL, Common.gTitle))
            {
                try
                {
                    txt_tungay.DateTime = DateTime.Now;
                    txt_denngay.DateTime = DateTime.Now;                
                }
                catch (Exception ex)
                {
                    ex.Message.Show(Name, MessageType.Error);
                }
            }
            gridControl_nghiemthu.DataSource = Common.db.NHAPPHIEUs;
            cbo_mavach.Properties.DataSource = Common.db.CANXEs;
            tbphieucan = new DataTable();
            tbphieucan.Columns.Add(new DataColumn("id", typeof(string)));
            tbphieucan.Columns.Add(new DataColumn("MaBarCode", typeof(string)));
            tbphieucan.Columns.Add(new DataColumn("SoPhieu", typeof(string)));
            tbphieucan.Columns.Add(new DataColumn("IdNhap", typeof(int)));
            tbphieucan.Columns.Add(new DataColumn("Soxe", typeof(string)));
            tbphieucan.Columns.Add(new DataColumn("SoRomooc", typeof(string)));
            tbphieucan.Columns.Add(new DataColumn("LoaiHang", typeof(string)));
            tbphieucan.Columns.Add(new DataColumn("KLHang", typeof(decimal)));
            tbphieucan.Columns.Add(new DataColumn("ThoiGianRa", typeof(DateTime)));
            btn_sua_luu_NT.Enabled = false;

            btn_sua_them_phieucan.Enabled = false;
            btn_themphieu.Enabled = false;
            cbo_mavach.Enabled = false;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void gridView_nghiemthu_Click(object sender, EventArgs e)
        {
            idnghiemthu = Int32.Parse(gridView_nghiemthu.GetFocusedRowCellValue("ID").ToString());
            //MessageBox.Show("ssssssssss: " + idnghiemthu);
            Common.db = new DataCanXeDataContext(Common.gConn);
            var result = Common.db.NHAPPHIEUs.SingleOrDefault(n => n.ID == idnghiemthu);
            if (result != null)
            {
                txt_manghiemthu.Text = result.Ma;
                txt_nghiemthu.Text = result.Ten;
                txt_ngaynghiemthu.Text = result.DateNT.ToString();
                if (result.DateNT != null) ngayct = result.DateNT.Value;
            }

            keyNT = "O";
            btn_sua_luu_NT.Enabled = true;
            btn_sua_luu_NT.Text = @"Sửa";
            //key = "O";
            btn_sua_them_phieucan.Enabled = true;
            btn_sua_them_phieucan.Text = @"Sửa";
            gridControl_phieucan.DataSource = Common.db.Fn_GetListCanXeWhereNhapHT(idnghiemthu);
        }

        private void cbo_mavach_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.);
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (cbo_mavach.Text != "")
                {
                    var phieucan = ((CANXE)cbo_mavach.Properties.GetRowByKeyValue(cbo_mavach.EditValue));
                    Common.db = new DataCanXeDataContext(Common.gConn);
                    var result = Common.db.Fn_GetPhieuCanXe("ALL", "ALL", 1, 1, 0, phieucan.id).Single();
                    txt_sophieu.Text = result.SoPhieu;
                    txt_soxe.Text = result.SoXe;
                    txt_soromooc.Text = result.SoRomooc;
                    txt_loaihang.Text = result.LoaiHang;
                    txt_khachhang.Text = result.CongTy;
                    txt_khoiluonghang.Text = result.KLHang.ToString(CultureInfo.CurrentCulture);
                    txt_ngaycanra.Text = result.ThoiGianRa.ToString();
                    if (result.IdNhapHT != 0)
                    {
                        String.Format("Phiếu {0} đã nhập nghiệm thu!", result.SoPhieu).Show(String.Empty, MessageType.Warning);
                    }
                    for (int i = 0; i < gridView_phieunhap.RowCount; i++)
                    {
                        int idphieu = Int32.Parse(gridView_phieunhap.GetRowCellValue(i, "id").ToString());
                        if (result.id == idphieu)
                        {
                            String.Format("Phiếu {0} đã nhập trong danh sách nghiệm thu!", result.SoPhieu).Show(String.Empty, MessageType.Warning);
                        }
                    }
                }
                //btn_themphieu.Focus();
               // if(!btn_themphieu.Focused)
                //{
                 //   btn_themphieu.Focus();
                //}
            }
        }
        private DataTable tbphieucan;
        private int idnghiemthu;
        private void btn_themphieu_Click(object sender, EventArgs e)
        {
            var phieucan = ((CANXE)cbo_mavach.Properties.GetRowByKeyValue(cbo_mavach.EditValue));
            for (int i = 0; i < gridView_phieunhap.RowCount; i++)
            {
                int idphieu = Int32.Parse(gridView_phieunhap.GetRowCellValue(i, "id").ToString());
                if (phieucan.id == idphieu)
                {
                    String.Format("Phiếu {0} đã nhập trong danh sách nghiệm thu!", phieucan.SoPhieu).Show(String.Empty, MessageType.Warning);
                    return;
                }
            }          
            Common.db = new DataCanXeDataContext(Common.gConn);
            var result = Common.db.Fn_GetPhieuCanXe("ALL", "ALL", 1, 1, 0, phieucan.id).Single();
            txt_sophieu.Text = "";
            txt_soxe.Text = "";
            txt_soromooc.Text = "";
            txt_loaihang.Text = "";
            txt_khachhang.Text = "";
            txt_khoiluonghang.Text = "";
            txt_ngaycanra.Text = "";
            // Add product to cart
            DataRow dr = tbphieucan.NewRow();
            dr["id"] = phieucan.id;
            dr["MaBarCode"] = phieucan.MaBarCode;
            dr["SoPhieu"] = result.SoPhieu;
            dr["IdNhap"] = 1;
            dr["Soxe"] = result.SoXe;
            dr["SoRomooc"] = result.SoRomooc;
            dr["LoaiHang"] = result.LoaiHang;
            dr["KLHang"] = result.KLHang.ToString(CultureInfo.CurrentCulture);
            dr["ThoiGianRa"] = result.ThoiGianRa.ToString();
            tbphieucan.Rows.Add(dr);
           // tbphieucan.Rows.Remove(dr);
            gridControl_phieucan.DataSource = tbphieucan;
            cbo_mavach.ResetText();
            cbo_mavach.Focus();

        }
        private string keyNT = "N";
        private void btn_themnghiemthu_Click(object sender, EventArgs e)
        {
            keyNT = "N";
            btn_sua_luu_NT.Text = @"Lưu";
            btn_sua_luu_NT.Enabled = true;
            txt_manghiemthu.Text = "";
            txt_nghiemthu.Text = "";
            txt_ngaynghiemthu.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
        }

        private void btn_sua_luu_NT_Click(object sender, EventArgs e)
        {
            if (keyNT == "N")
            {
                NHAPPHIEU newNhapPhieu = new NHAPPHIEU();
                newNhapPhieu.Ma = txt_manghiemthu.Text;
                newNhapPhieu.Ten = txt_nghiemthu.Text;
                newNhapPhieu.IdCreate = Common.gIdNguoidung;
                newNhapPhieu.CreateDate = DateTime.Now;
                newNhapPhieu.isDelete = false;
                newNhapPhieu.DateNT = DateTime.Parse(txt_ngaynghiemthu.Text);
                Common.db = new DataCanXeDataContext(Common.gConn);
                Common.db.NHAPPHIEUs.InsertOnSubmit(newNhapPhieu);
                Common.db.SubmitChanges();
            }
            else if (keyNT == "E")
            {
                Common.db = new DataCanXeDataContext(Common.gConn);
                NHAPPHIEU newNhapPhieu = Common.db.NHAPPHIEUs.Single(n => n.ID == idnghiemthu);
                newNhapPhieu.Ma = txt_manghiemthu.Text;
                newNhapPhieu.Ten = txt_nghiemthu.Text;
                newNhapPhieu.IdCreate = Common.gIdNguoidung;
                newNhapPhieu.CreateDate = DateTime.Now;
                newNhapPhieu.isDelete = false;
                newNhapPhieu.DateNT = DateTime.Parse(txt_ngaynghiemthu.Text);
                Common.db.SubmitChanges();
            }
            else if (keyNT == "O")
            {
                btn_sua_luu_NT.Text = @"Lưu";
                keyNT = "E";
            }
            gridControl_nghiemthu.DataSource = Common.db.NHAPPHIEUs;
        }

        private void btn_sua_them_phieucan_Click(object sender, EventArgs e)
        {
            if (keyNT == "E" && idnghiemthu != 0)
            {
                Common.db = new DataCanXeDataContext(Common.gConn);
                for (int i = 0; i < gridView_phieunhap.RowCount; i++)
                {
                    int idphieu= Int32.Parse(gridView_phieunhap.GetRowCellValue(i, "id").ToString());
                    CANXE newPhieu = Common.db.CANXEs.Single(n => n.id == idphieu);
                    newPhieu.IdNhapHT = idnghiemthu;
                    newPhieu.TimeNhapHT = DateTime.Now;
                    newPhieu.IdNhap= Common.gIdNguoidung;
                    Common.db.SubmitChanges();
                }
                MessageBox.Show(@"Lưu thành công!", @"Thông báo");
                btn_sua_them_phieucan.Text = @"Sửa";
                keyNT = "O";
                btn_themphieu.Enabled = false;
                cbo_mavach.Enabled = false;
                btn_themnghiemthu.Enabled = true;
                btnRefresh.Enabled = true;
                gridControl_nghiemthu.Enabled = true;
                txt_denngay.Enabled = true;
                txt_tungay.Enabled = true;
                btn_tai.Enabled = true;
                btn_sua_luu_NT.Enabled = true;
               // btn_In.Enabled = true;
                btn_Preview.Enabled = true;
                txt_manghiemthu.Enabled = true;
                txt_ngaynghiemthu.Enabled = true;
                txt_nghiemthu.Enabled = true;
            }
            else if (keyNT == "O" && idnghiemthu != 0)
            {
                btn_sua_them_phieucan.Text = @"Lưu";
                keyNT = "E";
                btn_themphieu.Enabled = true;
                cbo_mavach.Enabled = true;
                btn_themnghiemthu.Enabled = false;
                btnRefresh.Enabled = false;
                gridControl_nghiemthu.Enabled = false;
                txt_denngay.Enabled = false;
                txt_tungay.Enabled = false;
                btn_tai.Enabled = false;
                btn_sua_luu_NT.Enabled = false;
                //btn_In.Enabled = false;
                btn_Preview.Enabled = false;
                txt_manghiemthu.Enabled = false;
                txt_ngaynghiemthu.Enabled = false;
                txt_nghiemthu.Enabled = false;
            }
        }
        private double tongkhoiluongvao;
        private double tongkhoiluongra;
        private double tongkhoiluonghang;

        private readonly BindingSource _bindingSource = new BindingSource();
        private void btn_Preview_Click(object sender, EventArgs e)
        {
            var v = Common.db.Fn_GetListCanXeWhereNhapHT(idnghiemthu);
            var data = Utilities.LINQToDataTable(v);
            _bindingSource.DataSource = data;

            var Tong = Common.db.Fn_GetListCanXeWhereNhapHTSum(idnghiemthu).Single();
            if (Tong.KLV != null) tongkhoiluongvao = Tong.KLV.Value;
            if (Tong.KLR != null) tongkhoiluongra = Tong.KLR.Value;
            if (Tong.KLH != null) tongkhoiluonghang = Tong.KLH.Value;

            var rpt = new rpt_DanhSachNghiemThuCanXe();
            rpt.tongkhoiluongvao = tongkhoiluongvao;
            rpt.tongkhoiluongra = tongkhoiluongra;
            rpt.tongkhoiluonghang = tongkhoiluonghang;
            rpt.mocthoigian = txt_nghiemthu.Text+" ngày "+ String.Format("{0:dd/MM/yyyy}", ngayct) ;
            rpt.DataSource = _bindingSource;
            rpt.BindData();
            var pt = new ReportPrintTool(rpt);
            pt.ShowPreviewDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }
    }
}