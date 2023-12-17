using System;

namespace HTCANXE.Report

{
    public partial class rpt_DanhSachCanXeTai : DevExpress.XtraReports.UI.XtraReport
    {
        private string _MocThoiGian;
        public string mocthoigian
        {
            set
            {
                _MocThoiGian = value;
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
        private double _tklra;
        public double tongkhoiluongra
        {
            set
            {
                _tklra = value;
            }
        }
        private double _tklvao;
        public double tongkhoiluongvao
        {
            set
            {
                _tklvao = value;
            }
        }
        private double _tklhang;
        public double tongkhoiluonghang
        {
            set
            {
                _tklhang = value;
            }
        }


        public rpt_DanhSachCanXeTai()
        {
            InitializeComponent();
        }
        public void BindData()
        {
            xrTableCell_stt.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell_noixuat.DataBindings.Add("Text", DataSource, "NoiXuat");
            xrTableCell_phuongtien.DataBindings.Add("Text", DataSource, "SoXe");
            xrTableCell_klvao.DataBindings.Add("Text", DataSource, "KLVao").FormatString = "{0:#,0}";
            xrTableCell_klra.DataBindings.Add("Text", DataSource, "KLRa").FormatString = "{0:#,0}"; 
            xrTableCell_klhang.DataBindings.Add("Text", DataSource, "KLHang").FormatString = "{0:#,0}"; 
        }



        private void rpt_DanhSachCanXeTai_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txt_ngayin.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Today);
            lb_nguoican.Text = Common.gHoten;
            txt_tramcan.Text = Common.gTenTramCan;
            xrTableCell_tongklvao.Text = String.Format("{0:#,0}", _tklvao);
            xrTableCell_tongklra.Text = String.Format("{0:#,0}", _tklra);
            xrTableCell_tongklhang.Text = String.Format("{0:#,0}", _tklhang);
        }
    }
}
