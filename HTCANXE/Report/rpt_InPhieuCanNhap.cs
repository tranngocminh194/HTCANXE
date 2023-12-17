using System.Globalization;
using System.Linq;
using HTCANXE.Com;
using HTCANXE.Model;
using HTCANXE.Properties;
using ZXing;
using ZXing.QrCode;

namespace HTCANXE.Report
{
    public partial class rpt_InPhieuCanNhap : DevExpress.XtraReports.UI.XtraReport
    {
        private string PaperSize = Settings.Default.PaperSize;
        public rpt_InPhieuCanNhap()
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
        private string _Name;
        public string names
        {
            set
            {
                _Name = value;
            }
        }
        private void Qcode()
        {
            var data = " So phieu:" + txt_sophieu.Text
                                    + "\n So xe:" + txt_soxe.Text
                                    + "\n So Romooc:" + txt_soromooc.Text
                                    + "\n Loai hang:" + txt_hanghoa.Text
                                    + "\n Cong trinh:" 
                                    + "\n Cong ty:" + txt_khachhang.Text
                                    + "\n So lo:" 
                                    + "\n So niem:" 
                                    + "\n Khoi luong:" + txt_trongluonghang.Text
                                    + "\n NGAY:" + txt_ngaysx.Text;
            var barcodeWriter1 = new BarcodeWriter();
            barcodeWriter1.Format = BarcodeFormat.QR_CODE;
            var barcodeWriter2 = barcodeWriter1;
            var codeEncodingOptions1 = new QrCodeEncodingOptions();
            codeEncodingOptions1.Height = 148;
            codeEncodingOptions1.Width = 148;
            codeEncodingOptions1.Margin = 0;
            codeEncodingOptions1.CharacterSet = "utf-8";
            codeEncodingOptions1.PureBarcode = false;
            var codeEncodingOptions2 = codeEncodingOptions1;
            barcodeWriter2.Options = codeEncodingOptions2;
            var originalImage = barcodeWriter1.Write(data);
            pictureBox2.Image = originalImage;
        }
        private void rpt_InPhieuCanNhap_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Common.db = new DataCanXeDataContext(Common.gConn);
            var result = Common.db.Fn_GetPhieuCanXe("NHAP","ALL", 0, 1, 0,_id).SingleOrDefault();

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
                    Qcode();
                }
                catch
                {
                    // ignored
                }
            }
        }
    }
}
