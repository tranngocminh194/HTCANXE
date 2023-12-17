using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using HTCANXE.Com;
using HTCANXE.Model;
using HTCANXE.NghiepVu;
using HTCANXE.Report;

namespace HTCANXE.BaoCao
{
    public partial class frm_BaoCaoCanXeTai : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int id_phieu;
        private string _loaiCan= "XETAI";
        public string username;
        private double tongkhoiluongvao;
        private double tongkhoiluongra;
        private double tongkhoiluonghang;
        private readonly BindingSource _bindingSource = new BindingSource();
        public frm_BaoCaoCanXeTai()
        {
            Common.db = new DataCanXeDataContext(Common.gConn);
            InitializeComponent();
            cbo_soxe.Properties.DataSource = Common.db.PHUONGTIENs;
            cbo_noixuat.Properties.DataSource = Common.db.NOIXUATs;
        }


        private void frm_BaoCaoCanXeTai_Load(object sender, EventArgs e)
        {
            dateEdit_tungay.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Today);
            dateEdit_denngay.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Today);
            cbo_soxe.Text = @"ALL";
            cbo_noixuat.Text = @"X";

            btn_locbaocao_Click(sender, e);
        }

        private void gridControl_dulieucan_Click(object sender, EventArgs e)
        {
            id_phieu = Int32.Parse(gridView_dulieucan.GetFocusedRowCellValue("id").ToString());

            Common.db = new DataCanXeDataContext(Common.gConn);
            var result = Common.db.Fn_GetPhieuCanXe(_loaiCan,"ALL", 1, 1, 0,id_phieu).SingleOrDefault();
            if (result != null)
            {
                txt_sophieu.Text = result.SoPhieu;
                txt_soxe.Text = result.SoXe;
                txt_soromooc.Text = result.SoRomooc;
                txt_loaihang.Text = result.MaHang;
                txt_congtrinh.Text = result.MaCongTrinh.ToString();
                txt_congty.Text = result.MaCongTy;
                txt_solo.Text = result.SoLo;
                txt_soniem.Text = result.SoNiem;
                txt_khoiluongvao.Text = result.KLVao.ToString(CultureInfo.CurrentCulture);
                txt_khoiluongra.Text = result.KLRa.ToString(CultureInfo.CurrentCulture);
                txt_ngaysx.Text = result.ThoiGianRa.ToString();
                txt_khoiluonghang.Text = result.KLHang.ToString(CultureInfo.CurrentCulture);
            }
        }
        private void btn_xuatbaocao_Click(object sender, EventArgs e)
        {
            var tungay = string.Format("{0:dd/MM/yyyy}", dateEdit_tungay.Text);
            var denngay = string.Format("{0:dd/MM/yyyy}", dateEdit_denngay.Text);
            var soxe = ((PHUONGTIEN)cbo_soxe.Properties.GetRowByKeyValue(cbo_soxe.EditValue)).Ma;
            var noixuat = ((NOIXUAT)cbo_noixuat.Properties.GetRowByKeyValue(cbo_noixuat.EditValue)).Ma;
            Common.db = new DataCanXeDataContext(Common.gConn);
            var v = Common.db.Fn_GetListCanXeWhere(_loaiCan, "ALL", tungay, denngay, "ALL", 0, "ALL", "ALL", soxe, "PT", noixuat, Common.gTramCan);
            var data = Utilities.LINQToDataTable(v);
            _bindingSource.DataSource = data;
            gridControl_dulieucan.DataSource = _bindingSource;
            var Tong = Common.db.Fn_GetListCanXeWhereSum(_loaiCan, "ALL", tungay, denngay, "ALL", 0, "ALL", "ALL", soxe, "PT", noixuat, Common.gTramCan).Single();
            if (Tong.KLV != null) tongkhoiluongvao = Tong.KLV.Value;
            if (Tong.KLR != null) tongkhoiluongra = Tong.KLR.Value;
            if (Tong.KLH != null) tongkhoiluonghang = Tong.KLH.Value;

            if (_loaiCan == "XETAI")
            {
                var rpt = new rpt_DanhSachCanXeTai();
                rpt.tongkhoiluongvao = tongkhoiluongvao;
                rpt.tongkhoiluongra = tongkhoiluongra;
                rpt.tongkhoiluonghang = tongkhoiluonghang;
                rpt.mocthoigian = String.Format("Từ ngày {0} đến ngày {1}", tungay, denngay);
                rpt.DataSource = _bindingSource;
                rpt.BindData();
                var pt = new ReportPrintTool(rpt);
                pt.ShowPreviewDialog();
            } 
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            var frm = new frm_suaphieucan();
            frm.id_phieu = id_phieu;
            frm.ShowDialog();
        }

        private void btn_locbaocao_Click(object sender, EventArgs e)
        {
            var tungay = string.Format("{0:dd/MM/yyyy}", dateEdit_tungay.Text);
            var denngay = string.Format("{0:dd/MM/yyyy}", dateEdit_denngay.Text);
            var soxe = ((PHUONGTIEN)cbo_soxe.Properties.GetRowByKeyValue(cbo_soxe.EditValue)).Ma;
            var noixuat = ((NOIXUAT)cbo_noixuat.Properties.GetRowByKeyValue(cbo_noixuat.EditValue)).Ma;
            Common.db = new DataCanXeDataContext(Common.gConn);
            var v = Common.db.Fn_GetListCanXeWhere(_loaiCan, "ALL", tungay, denngay, "ALL", 0, "ALL", "ALL", soxe, "PT", noixuat, Common.gTramCan);
            _bindingSource.DataSource = Utilities.LINQToDataTable(v);
            gridControl_dulieucan.DataSource = _bindingSource;
        }
    }
}
