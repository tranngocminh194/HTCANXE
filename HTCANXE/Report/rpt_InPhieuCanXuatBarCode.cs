using System.Globalization;
using System.Linq;
using HTCANXE.Com;
using HTCANXE.Model;
using HTCANXE.Properties;

namespace HTCANXE.Report
{
    public partial class rpt_InPhieuCanXuatBarCode : DevExpress.XtraReports.UI.XtraReport
    {
        private string PaperSize = Settings.Default.PaperSize;
        public rpt_InPhieuCanXuatBarCode()
        {
            InitializeComponent();
            if (PaperSize == "A5")
            {
                Landscape = true;
                PageHeight = 583;
                PageWidth = 827;
                PaperKind = System.Drawing.Printing.PaperKind.A5;
            }
        }
        private int _id;
        public int id
        {
            set
            {
                _id = value;
            }
        }
        private string _loaican;
        public string loaican
        {
            set
            {
                _loaican = value;
            }
        }

        private void rpt_InPhieuCanXuatBarCode_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Common.db = new DataCanXeDataContext(Common.gConn);
            var result = Common.db.Fn_GetPhieuCanXe(_loaican, "ALL", 0, 1, 0, _id).SingleOrDefault();
            if (_loaican == "XUATVT")
            {
                txt_kykhachhang.Text = @"Cung Ứng Vật Tư";
            }

            if (result != null)
            {
                txt_sophieu.Text = result.SoPhieu;
                txt_soxe.Text = result.SoXe;
                txt_soromooc.Text = result.SoRomooc;
                txt_hanghoa.Text = result.LoaiHang;
                txt_congtrinh.Text = result.CongTrinh;
                txt_khachhang.Text = result.CongTy;
                txt_solo.Text = result.SoLo;
                txt_soniemphong.Text = result.SoNiem;
                txt_trongluongxe.Text = result.KLVao.ToString(CultureInfo.CurrentCulture) + @" KG";
                txt_ngaysx.Text = result.ThoiGianRa.ToString();
                txt_tongtrongluong.Text = result.KLRa + @" KG";
                txt_trongluonghang.Text = result.KLHang.ToString(CultureInfo.CurrentCulture) + @" KG";
                txt_tramcan.Text = result.TramCan.ToUpper();
                try
                {
                    txt_vietbangchu.Text =
                        Cls_ChuSo.So_chu(float.Parse(result.KLHang.ToString(CultureInfo.CurrentCulture)));
                    txt_nhanviencan.Text = Common.gHoten;
                    //txt_tramcan.Text = Common.gTenTramCan;
                    //Qcode();
                    barCode.Text = result.MaBarCode; //+DateTime.Now.DayOfYear;
                    barCode.ShowText = true;
                    barCode.BarCodeOrientation = DevExpress.XtraPrinting.BarCode.BarCodeOrientation.Normal;
                    DevExpress.XtraPrinting.BarCode.CodabarGenerator codabarGenerator =
                        new DevExpress.XtraPrinting.BarCode.CodabarGenerator();
                    barCode.Symbology = codabarGenerator;
                    barCode.AutoModule = true;
                }
                catch
                {
                    // ignored
                }
            }
        }
    }
}
