using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using HTCANXE.Com;
using HTCANXE.Model;
using HTCANXE.NghiepVu;
using HTCANXE.Properties;
using HTCANXE.Report;

namespace HTCANXE.BaoCao
{
    public partial class frm_BaoCaoCanXuatVatTu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int id_phieu;
        private string _loaiCan = "XUATVT";
        private double tongkhoiluongvao;
        private double tongkhoiluongra;
        private double tongkhoiluonghang;
        private double tongsoniem;
        private string _mavach;
        private readonly BindingSource _bindingSource = new BindingSource();
        public frm_BaoCaoCanXuatVatTu()
        {
            Common.db = new DataCanXeDataContext(Common.gConn);
            InitializeComponent();
            cbo_khachhang.Properties.DataSource = Common.db.KHACHHANGs;
            cbo_loaihang.Properties.DataSource = Common.db.HANGHOAs;
            cbo_soxe.Properties.DataSource = Common.db.PHUONGTIENs;
            cbo_soromooc.Properties.DataSource = Common.db.PHUONGTIENs.Where(m => m.Nhom == "ROMOOC").ToList();
            cbo_congtrinh.Properties.DataSource = Common.db.CONGTRINHs;
            cbo_noixuat.Properties.DataSource = Common.db.NOIXUATs;
            cbo_nhomhang.Properties.DataSource = Common.db.NHOMHANGHOAs;
        }


        private void frm_BaoCaoCanXuatVatTu_Load(object sender, EventArgs e)
        {
            _mavach = Settings.Default.MaVach;
            dateEdit_tungay.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Today);
            dateEdit_denngay.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Today);
            //cbo_loaican.Text = "XUAT";
            //txt_sophieufind.Text = "ALL";
            cbo_khachhang.Text = @"ALL";
            cbo_congtrinh.Text = @"0";
            cbo_nhomhang.Text = @"ALL";
            cbo_loaihang.Text = @"ALL";
            cbo_soxe.Text = @"ALL";
            cbo_soromooc.Text = @"PT";
            cbo_noixuat.Text = @"X";
            //cbo_tramcan.Text = "ALL";

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

        private void btn_inphieu_Click(object sender, EventArgs e)
        {
            if (_loaiCan == "XUAT" || _loaiCan == "XUATVT")
            {
                if (_mavach == "B")
                {
                    var rpt = new rpt_InPhieuCanXuatBarCode()
                    {
                        id = id_phieu,
                        loaican = _loaiCan
                    };
                    var pt = new ReportPrintTool(rpt);
                    if (Settings.Default.SetPrint)
                    {
                        pt.ShowPreviewDialog();
                    }
                    else
                    {
                        pt.Print();
                    }
                }
                if (_mavach == "Q")
                {
                    var rpt = new rpt_InPhieuCanXuat()
                    {
                        id = id_phieu
                    };
                    var pt = new ReportPrintTool(rpt);
                    if (Settings.Default.SetPrint)
                    {
                        pt.ShowPreviewDialog();
                    }
                    else
                    {
                        pt.Print();
                    }
                }

            }
            if (_loaiCan == "NHAP")
            {
                if (_mavach == "B")
                {
                    var rpt = new rpt_InPhieuCanNhapBarCode()
                    {
                        id = id_phieu
                    };
                    var pt = new ReportPrintTool(rpt);
                    if (Settings.Default.SetPrint)
                    {
                        pt.ShowPreviewDialog();
                    }
                    else
                    {
                        pt.Print();
                    }
                }
                if (_mavach == "Q")
                {
                    var rpt = new rpt_InPhieuCanNhap()
                    {
                        id = id_phieu
                    };
                    var pt = new ReportPrintTool(rpt);
                    if (Settings.Default.SetPrint)
                    {
                        pt.ShowPreviewDialog();
                    }
                    else
                    {
                        pt.Print();
                    }
                }
            }
            if (_loaiCan == "BETONG")
            {
                var rpt = new rpt_InPhieuCanBetong()
                {
                    id = id_phieu
                };
                var pt = new ReportPrintTool(rpt);
                if (Settings.Default.SetPrint)
                {
                    pt.ShowPreviewDialog();
                }
                else
                {
                    pt.Print();
                }
            }
        }

        private void btn_xuatbaocao_Click(object sender, EventArgs e)
        {
            //_loaiCan = ((LOAICAN)cbo_loaican.Properties.GetRowByKeyValue(cbo_loaican.EditValue)).Ma;
            //var sophieu = txt_sophieufind.Text;
            var tungay = string.Format("{0:dd/MM/yyyy}", dateEdit_tungay.Text);
            var denngay = string.Format("{0:dd/MM/yyyy}", dateEdit_denngay.Text);
            var khachhang = ((KHACHHANG)cbo_khachhang.Properties.GetRowByKeyValue(cbo_khachhang.EditValue)).Ma;
            var congtrinh = ((CONGTRINH)cbo_congtrinh.Properties.GetRowByKeyValue(cbo_congtrinh.EditValue)).ID;
            var nhomhang = ((NHOMHANGHOA)cbo_nhomhang.Properties.GetRowByKeyValue(cbo_nhomhang.EditValue)).Ma;
            var loaihang = ((HANGHOA)cbo_loaihang.Properties.GetRowByKeyValue(cbo_loaihang.EditValue)).Ma;
            var soxe = ((PHUONGTIEN)cbo_soxe.Properties.GetRowByKeyValue(cbo_soxe.EditValue)).Ma;
            var soromooc = ((PHUONGTIEN)cbo_soromooc.Properties.GetRowByKeyValue(cbo_soromooc.EditValue)).Ma;
            var noixuat = ((NOIXUAT)cbo_noixuat.Properties.GetRowByKeyValue(cbo_noixuat.EditValue)).Ma;
            //var tramcan = ((TRAMCAN)cbo_tramcan.Properties.GetRowByKeyValue(cbo_tramcan.EditValue)).Ma;
            Common.db = new DataCanXeDataContext(Common.gConn);
            var v = Common.db.Fn_GetListCanXeWhere(_loaiCan, "ALL", tungay, denngay, khachhang, congtrinh, nhomhang, loaihang, soxe, soromooc, noixuat, Common.gTramCan);
            var data = Utilities.LINQToDataTable(v);
            _bindingSource.DataSource = data;
            gridControl_dulieucan.DataSource = _bindingSource;
            var Tong = Common.db.Fn_GetListCanXeWhereSum(_loaiCan, "ALL", tungay, denngay, khachhang, congtrinh, nhomhang, loaihang, soxe, soromooc, noixuat, Common.gTramCan).Single();
            if (Tong.KLV != null) tongkhoiluongvao = Tong.KLV.Value;
            if (Tong.KLR != null) tongkhoiluongra = Tong.KLR.Value;
            if (Tong.KLH != null) tongkhoiluonghang = Tong.KLH.Value;

            if (_loaiCan == "XUAT")
            {
                if (Tong.SLN != null)
                    if (Tong.SLNR != null)
                        tongsoniem = Tong.SLN.Value + Tong.SLNR.Value;
                var rpt = new rpt_DanhSachCanXeXa();
                rpt.tongkhoiluongvao = tongkhoiluongvao;
                rpt.tongkhoiluongra = tongkhoiluongra;
                rpt.tongkhoiluonghang = tongkhoiluonghang;
                rpt.tongsoniem = tongsoniem;
                rpt.mocthoigian = $"Từ ngày {tungay} đến ngày {denngay}";
                rpt.DataSource = _bindingSource;
                rpt.BindData();
                var pt = new ReportPrintTool(rpt);
                pt.ShowPreviewDialog();

            }
            if (_loaiCan == "XUATVT")
            {
                var rpt = new rpt_DanhSachCanXe();
                rpt.tongkhoiluongvao = tongkhoiluongvao;
                rpt.tongkhoiluongra = tongkhoiluongra;
                rpt.tongkhoiluonghang = tongkhoiluonghang;
                rpt.mocthoigian = String.Format("Từ ngày {0} đến ngày {1}", tungay, denngay);
                rpt.DataSource = _bindingSource;
                rpt.BindData();
                var pt = new ReportPrintTool(rpt);
                pt.ShowPreviewDialog();

            }
            if (_loaiCan == "NHAP")
            {
                var rpt = new rpt_DanhSachCanXe();
                rpt.tongkhoiluongvao = tongkhoiluongvao;
                rpt.tongkhoiluongra = tongkhoiluongra;
                rpt.tongkhoiluonghang = tongkhoiluonghang;
                rpt.mocthoigian = String.Format("Từ ngày {0} đến ngày {1}", tungay, denngay);
                rpt.DataSource = _bindingSource;
                rpt.BindData();
                var pt = new ReportPrintTool(rpt);
                pt.ShowPreviewDialog();
            }
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
            if (_loaiCan == "BETONG")
            {
                //var rpt = new rpt_InPhieuCanBetong();
                //rpt.tongkhoiluongvao = tongkhoiluongvao;
                //rpt.tongkhoiluongra = tongkhoiluongra;
                //rpt.tongkhoiluonghang = tongkhoiluonghang;
                //rpt.mocthoigian = String.Format("Từ ngày {0} đến ngày {1}", tungay, denngay);
                //rpt.DataSource = _bindingSource;
                //rpt.BindData();
                //var pt = new ReportPrintTool(rpt);
                //pt.ShowPreviewDialog();
            }

            
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            var frm = new frm_suaphieucan();
            frm.id_phieu = id_phieu;
            frm.ShowDialog();
        }

        private void gridView_dulieucan_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void btn_locbaocao_Click(object sender, EventArgs e)
        {
            //_loaiCan = ((LOAICAN)cbo_loaican.Properties.GetRowByKeyValue(cbo_loaican.EditValue)).Ma;
            //var sophieu = txt_sophieufind.Text;
            var tungay = string.Format("{0:dd/MM/yyyy}", dateEdit_tungay.Text);
            var denngay = string.Format("{0:dd/MM/yyyy}", dateEdit_denngay.Text);
            var khachhang = ((KHACHHANG)cbo_khachhang.Properties.GetRowByKeyValue(cbo_khachhang.EditValue)).Ma;
            var congtrinh = ((CONGTRINH)cbo_congtrinh.Properties.GetRowByKeyValue(cbo_congtrinh.EditValue)).ID;
            var nhomhang = ((NHOMHANGHOA)cbo_nhomhang.Properties.GetRowByKeyValue(cbo_nhomhang.EditValue)).Ma;
            var loaihang = ((HANGHOA)cbo_loaihang.Properties.GetRowByKeyValue(cbo_loaihang.EditValue)).Ma;
            var soxe = ((PHUONGTIEN)cbo_soxe.Properties.GetRowByKeyValue(cbo_soxe.EditValue)).Ma;
            var soromooc = ((PHUONGTIEN)cbo_soromooc.Properties.GetRowByKeyValue(cbo_soromooc.EditValue)).Ma;
            var noixuat = ((NOIXUAT)cbo_noixuat.Properties.GetRowByKeyValue(cbo_noixuat.EditValue)).Ma;
           // var tramcan = ((TRAMCAN)cbo_tramcan.Properties.GetRowByKeyValue(cbo_tramcan.EditValue)).Ma;
            Common.db = new DataCanXeDataContext(Common.gConn);
            var v = Common.db.Fn_GetListCanXeWhere(_loaiCan, "ALL", tungay, denngay, khachhang, congtrinh, nhomhang, loaihang, soxe, soromooc, noixuat, Common.gTramCan);
            _bindingSource.DataSource = Utilities.LINQToDataTable(v);
            gridControl_dulieucan.DataSource = _bindingSource;
        }
    }
}
