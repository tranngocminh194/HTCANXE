using System.Globalization;
using System.Linq;
using HTCANXE.Com;
using HTCANXE.Model;
using HTCANXE.Properties;

namespace HTCANXE.Report
{
    public partial class rpt_InPhieuCanNhapBarCode : DevExpress.XtraReports.UI.XtraReport
    {
        private string PaperSize = Settings.Default.PaperSize;
        public rpt_InPhieuCanNhapBarCode()
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

        private string names_;
        public string names
        {
            set { names_ = value; }
        }

        private void rpt_InPhieuCanNhapBarCode_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Common.db = new DataCanXeDataContext(Common.gConn);
            var result = Common.db.Fn_GetPhieuCanXe("NHAP", "ALL", 0, 1, 0,_id).SingleOrDefault();

            if (result != null)
            {
                txt_sophieu.Text = result.SoPhieu;
                txt_soxe.Text = result.SoXe;
                txt_soromooc.Text = result.SoRomooc;
                txt_hanghoa.Text = result.LoaiHang;
                txt_khachhang.Text = result.CongTy;
                txt_trongluongxe.Text = result.KLRa.ToString(CultureInfo.CurrentCulture) + @" KG";
                txt_ngaysx.Text = result.ThoiGianRa.ToString();
                txt_tongtrongluong.Text = result.KLVao + @" KG";
                txt_trongluonghang.Text = result.KLHang.ToString(CultureInfo.CurrentCulture) + @" KG";
                txt_tramcan.Text = result.TramCan.ToUpper();
                try
                {
                    txt_vietbangchu.Text = Cls_ChuSo.So_chu(float.Parse(result.KLHang.ToString(CultureInfo.CurrentCulture)));
                    txt_nhanviencan.Text = Common.gHoten;
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
