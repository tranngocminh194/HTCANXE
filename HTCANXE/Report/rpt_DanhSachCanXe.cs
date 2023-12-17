﻿using System;

namespace HTCANXE.Report
{
    public partial class rpt_DanhSachCanXe : DevExpress.XtraReports.UI.XtraReport
    {
        private string _MocThoiGian;
        public string mocthoigian
        {
            set
            {
                _MocThoiGian = value;
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
        public rpt_DanhSachCanXe()
        {
            InitializeComponent();
            
            //txt_ngayin.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Today);
        }
        public void BindData()
        {
            xrTableCell_stt.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell_sophieu.DataBindings.Add("Text", DataSource, "SoPhieu");
            xrTableCell_phuongtien.DataBindings.Add("Text", DataSource, "SoXe");
            xrTableCell_romooc.DataBindings.Add("Text", DataSource, "SoRomooc");
            xrTableCell_khachhang.DataBindings.Add("Text", DataSource, "CongTy");
            xrTableCell_loaihang.DataBindings.Add("Text", DataSource, "LoaiHang");
            xrTableCell_ngaycanvao.DataBindings.Add("Text", DataSource, "ThoiGianVao");
            xrTableCell_ngaycanra.DataBindings.Add("Text", DataSource, "ThoiGianRa");
            xrTableCell_klvao.DataBindings.Add("Text", DataSource, "KLVao").FormatString= "{0:#,0}";
            xrTableCell_klhang.DataBindings.Add("Text", DataSource, "KLHang").FormatString = "{0:#,0}";
            xrTableCell_klra.DataBindings.Add("Text", DataSource, "KLRa").FormatString = "{0:#,0}";
            xrTableCell_tramcan.DataBindings.Add("Text", DataSource, "TramCan");}

        private void rpt_DanhSachCanXe_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txt_ngaylap.Text = string.Format("Cần Thơ, ngày {0} tháng {1} năm {2}", DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);
            xrTableCell_tongklvao.Text = String.Format("{0:#,0}", _tklvao);
            xrTableCell_tongklra.Text = String.Format("{0:#,0}", _tklra);
            xrTableCell_tongklhang.Text = String.Format("{0:#,0}", _tklhang);
            txt_tramcan.Text = Common.gTenTramCan.ToUpper();txt_ngayin.Text = _MocThoiGian;
        }
    }
}
