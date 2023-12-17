using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Ribbon;
using HTCANXE.Class;
using HTCANXE.Model;
using HTCANXE.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using HTCANXE.BaoCao;
using HTCANXE.Com;
using HTCANXE.DanhMuc;
using HTCANXE.HeThong;
using HTCANXE.NghiepVu;

namespace HTCANXE
{
    public partial class Frm_Home : RibbonForm
    {
        private List<PHUONGTIEN> lstPhuongtiens, lstPhuongtienromooc;
        private List<HANGHOA> lstHanghoas;
        private List<KHACHHANG> lstKhachhangs;
        private List<CONGTRINH> lstCongtrinhs;
        private List<NOIXUAT> lstNoixuats;
        private int taitrongxe;
        private int taitrongromooc;
        private string _loaiCan;
        private int _idphieu;
        private readonly bool _print;
        private readonly short _PaperCoppies;
        private readonly string _mode;
        private readonly string _mavach;
        private readonly BindingSource _bindingSource = new BindingSource();
        private void ViewCanXuat()
        {
            lstPhuongtiens = PhuongTien.GetlList("DAUKEO");
            cbo_soxe.Properties.DataSource = lstPhuongtiens;
            cbo_soxe.Properties.ValueMember = "Ma";
            cbo_soxe.Properties.DisplayMember = "Ten";
            lstPhuongtienromooc = PhuongTien.GetlList("ROMOOC", "DAUKEO");
            cbo_romooc.Properties.DataSource = lstPhuongtienromooc;
            cbo_romooc.Properties.ValueMember = "Ma";
            cbo_romooc.Properties.DisplayMember = "Ten";
            lstHanghoas = HangHoa.GetlList(_loaiCan);
            cbo_loaihang.Properties.DataSource = lstHanghoas;
            cbo_loaihang.Properties.ValueMember = "Ma";
            cbo_loaihang.Properties.DisplayMember = "Ten";
            cbo_noixuat.Enabled = true;
            cbo_soxe.Enabled = true;
            txt_khoiluongxe.Enabled = true;
            cbo_romooc.Enabled = true;
            txt_khoiluongromooc.Enabled = true;
            cbo_loaihang.Enabled = true;
            cbo_congtrinh.Enabled = true;
            cbo_congty.Enabled = true;
            txt_solo.Enabled = true;
            txt_soniem.Enabled = true;
            _SetNew();
            cbo_noixuat.Text = @"X";
            cbo_loaihang.Text = @"ALL";
        }
        private void ViewCanNhap()
        {
            lstPhuongtiens = PhuongTien.GetlList("DAUKEO");
            cbo_soxe.Properties.DataSource = lstPhuongtiens;
            cbo_soxe.Properties.ValueMember = "Ma";
            cbo_soxe.Properties.DisplayMember = "Ten";

            lstPhuongtienromooc = PhuongTien.GetlList("ROMOOC", "DAUKEO");
            cbo_romooc.Properties.DataSource = lstPhuongtienromooc;
            cbo_romooc.Properties.ValueMember = "Ma";
            cbo_romooc.Properties.DisplayMember = "Ten";

            lstHanghoas = HangHoa.GetlList(_loaiCan);
            cbo_loaihang.Properties.DataSource = lstHanghoas;
            cbo_loaihang.Properties.ValueMember = "Ma";
            cbo_loaihang.Properties.DisplayMember = "Ten";

            //txt_sophieu.Enabled = false;
            cbo_noixuat.Enabled = false;
            cbo_soxe.Enabled = true;
            txt_khoiluongxe.Enabled = false;
            cbo_romooc.Enabled = true;
            txt_khoiluongromooc.Enabled = false;
            cbo_loaihang.Enabled = true;
            cbo_congtrinh.Enabled = true;
            cbo_congty.Enabled = true;
            txt_solo.Enabled = false;
            txt_soniem.Enabled = false;

            _SetNew();
            cbo_noixuat.Text = @"X";
            txt_solo.Text = @"-";
            txt_soniem.Text = @"-";
            cbo_loaihang.Text = @"ALL";
        }
        private void ViewCanXeTai()
        {

            lstPhuongtiens = PhuongTien.GetlList("XETAI");
            cbo_soxe.Properties.DataSource = lstPhuongtiens;
            cbo_soxe.Properties.ValueMember = "Ma";
            cbo_soxe.Properties.DisplayMember = "Ten";

            lstHanghoas = HangHoa.GetlList(_loaiCan);
            cbo_loaihang.Properties.DataSource = lstHanghoas;
            cbo_loaihang.Properties.ValueMember = "Ma";
            cbo_loaihang.Properties.DisplayMember = "Ten";
            cbo_noixuat.Enabled = true;
            cbo_soxe.Enabled = true;
            txt_khoiluongxe.Enabled = false;
            cbo_romooc.Enabled = false;
            txt_khoiluongromooc.Enabled = false;
            cbo_loaihang.Enabled = false;
            cbo_congtrinh.Enabled = false;
            cbo_congty.Enabled = false;
            txt_solo.Enabled = false;
            txt_soniem.Enabled = false;
            _SetNew();
            cbo_romooc.Text = @"PT";
            cbo_loaihang.Text = @"XE";
            cbo_congtrinh.Text = @"0";
            cbo_congty.Text = @"0";
        }
        private void ViewCanBetong()
        {
            lstPhuongtiens = PhuongTien.GetlList("BETONG");
            cbo_soxe.Properties.DataSource = lstPhuongtiens;
            cbo_soxe.Properties.ValueMember = "Ma";
            cbo_soxe.Properties.DisplayMember = "Ten";

            lstHanghoas = HangHoa.GetlList(_loaiCan);
            cbo_loaihang.Properties.DataSource = lstHanghoas;
            cbo_loaihang.Properties.ValueMember = "Ma";
            cbo_loaihang.Properties.DisplayMember = "Ten";

            //txt_sophieu.Enabled = false;
            cbo_noixuat.Enabled = false;
            cbo_soxe.Enabled = true;
            txt_khoiluongxe.Enabled = false;
            cbo_romooc.Enabled = false;
            txt_khoiluongromooc.Enabled = false;
            cbo_loaihang.Enabled = true;
            cbo_congtrinh.Enabled = false;
            cbo_congty.Enabled = true;
            txt_solo.Enabled = false;
            txt_soniem.Enabled = false;
            _SetNew();
            cbo_romooc.Text = @"PT";
            cbo_loaihang.Text = @"BT";
            cbo_congtrinh.Text = @"0";
            cbo_congty.Text = @"100002";
        }
        private void loadComboHangHoa()
        {
            lstHanghoas = HangHoa.GetlList("");
            cbo_loaihang.Properties.DataSource = lstHanghoas;
            cbo_loaihang.Properties.ValueMember = "Ma";
            cbo_loaihang.Properties.DisplayMember = "Ten";
        }
        private void loadComboCongTrinh()
        {
            lstCongtrinhs = CongTrinh.GetlList("");
            cbo_congtrinh.Properties.DataSource = lstCongtrinhs;
            cbo_congtrinh.Properties.ValueMember = "ID";
            cbo_congtrinh.Properties.DisplayMember = "Ten";
        }
        private void loadComboKhachHang()
        {
            lstKhachhangs = CongTy.GetlList("");
            cbo_congty.Properties.DataSource = lstKhachhangs;
            cbo_congty.Properties.ValueMember = "Ma";
            cbo_congty.Properties.DisplayMember = "Ten";
        }
        private void loadComboNoiXuat()
        {
            Common.db = new DataCanXeDataContext(Common.gConn);
            lstNoixuats = Common.db.NOIXUATs.ToList();
            cbo_noixuat.Properties.DataSource = lstNoixuats;
            cbo_noixuat.Properties.ValueMember = "Ma";
            cbo_noixuat.Properties.DisplayMember = "Ten";
        }


        private void ConnectRs232()
        {
            if (!RS232.IsOpen)
            {
                try
                {
                    RS232.PortName = Settings.Default.PortName;
                    RS232.BaudRate = Settings.Default.BaudRate;
                    RS232.DataBits = Settings.Default.DataBits;
                    RS232.Parity = Settings.Default.Parity;
                    RS232.StopBits = Settings.Default.StopBits;
                    RS232.Open();
                }
                catch
                {
                    "Không thể mở cổng COM!".Show(string.Empty, MessageType.Warning);
                    Application.Exit();
                }
            }
            else
            {
                RS232.Close();
            }
        }
        private void RS232_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Invoke(new EventHandler(DoUpdate));
            }
            catch (Exception)
            {
                // ignored
            }
        }
        private void DoUpdate(object s, EventArgs e)
        {
            Thread.Sleep(50);
            var data = RS232.ReadExisting();
            if (!data.Trim().Any())
            {
                "Không thể mở cổng COM!".Show(string.Empty, MessageType.Warning);
            }
            else
            {
                var vt = 0;
                var rx = new Regex(@"[^1234567890]");
                var relay0 = rx.Replace(data, "+?");
                while (relay0[vt].Equals('0'))
                {
                    vt++;
                }
                var removeNumberZero = relay0.Substring(vt, relay0.Length - vt);
                var phanCach = new[] { "+?" };
                var weigh = removeNumberZero.Split(phanCach, StringSplitOptions.RemoveEmptyEntries);
                var t = weigh[0];

                if (_mode == "N")
                {
                    var kq = t.Substring(0, 6);
                    var kq2 = Double.Parse(kq);
                    txt_can.Text = kq2.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    var kq2 = Double.Parse(t);
                    txt_can.Text = kq2.ToString(CultureInfo.CurrentCulture);
                }
            }
        }

        public Frm_Home()
        {
            InitializeComponent();
            _loaiCan = Settings.Default.LoaiCan;
            _mode = Settings.Default.Modem;
            _mavach = Settings.Default.MaVach;
            _print = Settings.Default.SetPrint;
            _PaperCoppies = Settings.Default.paperCopies;
            UserLookAndFeel.Default.SkinName = Settings.Default.ApplicationSkinName;
            Common.frmM = this;

        }      
        private void Frm_Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            const string info = @"Thoát ứng dụng cân xe ?";
            if (info.Confirm())
            {
                RS232.Close();
                Common.frmM.Dispose();
                Common.frmL.Dispose();
                Application.Exit();
            }
        }
        private void barPaintStyle_GalleryItemCheckedChanged(object sender, GalleryItemEventArgs e)
        {
           // Settings.Default.ApplicationSkinName = UserLookAndFeel.Default.SkinName;
            //Settings.Default.Save();
        }
        public void loadDataTableCanXe()
        {
            Common.db = new DataCanXeDataContext(Common.gConn);
            var v = Common.db.Fn_GetPhieuCanXe(_loaiCan, Common.gTramCan, 0, 0, 0, 0);
            _bindingSource.DataSource = Utilities.LINQToDataTable(v);
            gridControl_phuongtiencan.DataSource = _bindingSource;
        }
        private void frm_home_Load(object sender, EventArgs e)
        {
            ConnectRs232();
            int year = DateTime.Now.Year;
            if (year > 2019)
            {
                barStaticItem_copyright.Caption = @"Develope by Trần Ngọc Minh - Copyright Công ty cổ phần Xi Măng Tây Đô © 2019 - " + year;
            }
            else
            {
                barStaticItem_copyright.Caption = @"Develope by Trần Ngọc Minh - Copyright Công ty cổ phần Xi Măng Tây Đô © 2019";
            }
            _SetButtom(true, false, false, false);
            loadComboHangHoa();
            loadComboCongTrinh();
            loadComboKhachHang();
            loadDataTableCanXe();
            loadComboNoiXuat();

            switch (_loaiCan)
            {
                case "XUAT":
                    rdo_canxuat.Checked = true;
                    rdo_canxuat_CheckedChanged(sender, e);
                    break;
                case "XUATVT":
                    rdo_canphelieu.Checked = true;
                    break;
                case "NHAP":
                    rdo_cannhap.Checked = true;
                    break;
                case "XETAI":
                    rdo_canxetai.Checked = true;
                    break;
                case "BETONG":
                    rdo_canxebetong.Checked = true;
                    break;
            }
            _SetNew();        
        }
        public void _SetNew()
        {
            txt_sophieu.Text = Utilities.SoPhieuCan();
            cbo_noixuat.Text = @"X";
            cbo_soxe.Text = @"PT";
            txt_khoiluongxe.Text = @"0";
            cbo_romooc.Text = @"PT";
            txt_khoiluongromooc.Text = @"0";
            cbo_loaihang.Text = @"ALL";
            cbo_congty.Text = @"0";
            cbo_congtrinh.Text = @"0";
            txt_solo.Text = @"-";
            txt_soniem.Text = @"-";
            txt_khoiluongvao.Text = @"0";
            txt_khoiluongra.Text = @"0";
            txt_khoiluonghang.Text = @"0";
            txt_thoigianvao.Text = "";
            txt_thoigianra.Text = "";
            _SetButtom(true, false, false, false);
        }
        public void _SetButtom(bool bcanvao, bool bcanra, bool binphieu, bool canthu)
        {
            btn_InPhieu.Enabled = binphieu;
            btn_CanVao.Enabled = bcanvao;
            btn_CanRa.Enabled = bcanra;
            btn_tinhkhoiluong.Enabled = canthu;
        }
        private void gridControl_phuongtiencan_Click(object sender, EventArgs e)
        {
            try
            {
                _idphieu = Int32.Parse(gridView_HTCANXE.GetFocusedRowCellValue("id").ToString());
                Common.db = new DataCanXeDataContext(Common.gConn);
                var result = Common.db.Fn_GetPhieuCanXe(_loaiCan, Common.gTramCan, 0, 0, 0, _idphieu).SingleOrDefault();
                if (result != null)
                {
                    txt_sophieu.Text = result.SoPhieu;
                    cbo_soxe.Text = result.SoXe;
                    cbo_romooc.Text = result.SoRomooc;
                    txt_khoiluongxe.Text = result.KLXe.ToString();
                    txt_khoiluongromooc.Text = result.KLRomooc.ToString();
                    cbo_loaihang.Text = result.MaHang;
                    cbo_congtrinh.Text = result.MaCongTrinh.ToString();
                    cbo_congty.Text = result.MaCongTy;
                    txt_solo.Text = result.SoLo;
                    txt_soniem.Text = result.SoNiem;
                    txt_khoiluongvao.Text = result.KLVao.ToString(CultureInfo.InvariantCulture);
                    txt_thoigianvao.Text = result.ThoiGianVao.ToString();
                    txt_khoiluongra.Text = string.Empty;
                    txt_thoigianra.Text = string.Empty;
                    txt_khoiluonghang.Text = string.Empty;
                    cbo_noixuat.Text = result.NoiXuat;
                }

                var _klxe = Int32.Parse(txt_khoiluongxe.Text);
                var _klromooc = Int32.Parse(txt_khoiluongromooc.Text);
                txt_tongkhoiluong.Text = (_klxe + _klromooc).ToString();
                _SetButtom(false, true, false, true);
            }
            catch
            {
                //MessageBox.Show(@"Lỗi không lấy được dữ liệu", @"Thông báo lỗi");
            }
        }

        private void cbo_soxe_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Common.db = new DataCanXeDataContext(Common.gConn);
                var result = Common.db.Fn_GetRomooc(cbo_soxe.Text).SingleOrDefault();
                if (result != null)
                {
                    cbo_romooc.Text = result.SoRomooc;
                }

                var trongLuong = ((PHUONGTIEN) cbo_soxe.Properties.GetRowByKeyValue(cbo_soxe.EditValue)).TrongLuong;
                if (trongLuong != null)
                    txt_khoiluongxe.Text =
                        trongLuong.Value
                        .ToString(CultureInfo.InvariantCulture);
                txt_tongkhoiluong.Text = (Int32.Parse(txt_khoiluongxe.Text) + Int32.Parse(txt_khoiluongromooc.Text)).ToString();
                var taiTrong = ((PHUONGTIEN) cbo_soxe.Properties.GetRowByKeyValue(cbo_soxe.EditValue))
                    .TaiTrong;
                if (taiTrong != null)
                    taitrongxe = Int32.Parse(taiTrong.Value.ToString(CultureInfo.CurrentCulture));
                txt_taitrong.Text = taitrongxe.ToString();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
        private void cbo_romooc_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var trongLuong = ((PHUONGTIEN) cbo_romooc.Properties.GetRowByKeyValue(cbo_romooc.EditValue)).TrongLuong;
                if (trongLuong != null)
                    txt_khoiluongromooc.Text =
                        trongLuong.Value
                        .ToString(CultureInfo.InvariantCulture);
                txt_tongkhoiluong.Text = (Int32.Parse(txt_khoiluongxe.Text) + Int32.Parse(txt_khoiluongromooc.Text)).ToString();
                var taiTrong = ((PHUONGTIEN) cbo_romooc.Properties.GetRowByKeyValue(cbo_romooc.EditValue)).TaiTrong;
                if (taiTrong != null)
                    taitrongromooc =
                        Int32.Parse(taiTrong
                            .Value.ToString(CultureInfo.InvariantCulture));
                txt_taitrong.Text = (taitrongxe + taitrongromooc).ToString();
            }
            catch
            {
                // ignored
            }
        }
        private void rdo_canxuat_CheckedChanged(object sender, EventArgs e)
        {
            _loaiCan = @"XUAT";
            loadDataTableCanXe();
            ViewCanXuat();
        }
        private void rdo_cannhap_CheckedChanged(object sender, EventArgs e)
        {
            _loaiCan = @"NHAP";
            loadDataTableCanXe();
            ViewCanNhap();
        }
        private void rdo_canxetai_CheckedChanged(object sender, EventArgs e)
        {
            _loaiCan = @"XETAI";
            loadDataTableCanXe();
            ViewCanXeTai();
        }
        private void rdo_canphelieu_CheckedChanged(object sender, EventArgs e)
        {
            _loaiCan = @"XUATVT";
            loadDataTableCanXe();
            ViewCanXuat();
        }
        private void rdo_canxebetong_CheckedChanged(object sender, EventArgs e)
        {
            _loaiCan = "BETONG";
            loadDataTableCanXe();
            ViewCanBetong();
        }
        public void loadcan(int macan)
        {
            string SoXe = "PT";
            if (cbo_soxe.EditValue != null)
            {
                SoXe = ((PHUONGTIEN)cbo_soxe.Properties.GetRowByKeyValue(cbo_soxe.EditValue)).Ma;
            }
            string SoRomooc = "PT";
            if (cbo_romooc.EditValue != null)
            {
                SoRomooc = ((PHUONGTIEN)cbo_romooc.Properties.GetRowByKeyValue(cbo_romooc.EditValue)).Ma;
            }
            string LoaiHang = "XE";
            if (cbo_loaihang.EditValue != null)
            {
                LoaiHang = ((HANGHOA)cbo_loaihang.Properties.GetRowByKeyValue(cbo_loaihang.EditValue)).Ma;
            }
            int CongTrinh = 0;
            if (cbo_congtrinh.EditValue != null)
            {
                CongTrinh = ((CONGTRINH)cbo_congtrinh.Properties.GetRowByKeyValue(cbo_congtrinh.EditValue)).ID;
            }
            string CongTy = "0";
            if (cbo_congty.EditValue != null)
            {
                CongTy = ((KHACHHANG)cbo_congty.Properties.GetRowByKeyValue(cbo_congty.EditValue)).Ma;
            }
            string NoiXuat = "X";
            if (cbo_noixuat.EditValue != null)
            {
                NoiXuat = ((NOIXUAT)cbo_noixuat.Properties.GetRowByKeyValue(cbo_noixuat.EditValue)).Ma;
            }
            CANXE newCanxe = new CANXE();
            newCanxe.SoPhieu = txt_sophieu.Text;
            newCanxe.SoXe = SoXe;
            newCanxe.KLXe = Int32.Parse(txt_khoiluongxe.Text);
            newCanxe.SoRomooc = SoRomooc;
            newCanxe.KLRomooc = Int32.Parse(txt_khoiluongromooc.Text);
            newCanxe.LoaiHang = LoaiHang;
            newCanxe.CongTrinh = CongTrinh;
            newCanxe.CongTy = CongTy;
            newCanxe.SoLo = txt_solo.Text;
            newCanxe.SoNiem = txt_soniem.Text;
            newCanxe.isDelete = false;
            newCanxe.MACAN = _loaiCan;
            newCanxe.NoiXuat = NoiXuat;
            newCanxe.TramCan = Common.gTramCan;
            newCanxe.IdDelete = "0";
            newCanxe.TimeDelete = DateTime.Now;
            newCanxe.IdEdit = "0";
            newCanxe.TimeEdit = DateTime.Now;
            newCanxe.IdNhapHT = 0;
            newCanxe.TimeNhapHT = DateTime.Now;
            newCanxe.IdNhap = 0;
            newCanxe.UpdateServer = DateTime.Now;
            newCanxe.IsUpdateServer = false;
            if (macan == 1)
            {
                newCanxe.KLVao = Int32.Parse(txt_can.Text);
                newCanxe.KLRa = 0;
                newCanxe.KLHang = 0;
                newCanxe.ThoiGianVao = DateTime.Now;
                newCanxe.ThoiGianRa = DateTime.Now;
                newCanxe.idCanVao = Common.gIdNguoidung.ToString();
                newCanxe.idCanRa = Common.gIdNguoidung.ToString();
                newCanxe.MaBarCode = DateTime.Now.ToString("yyMMddHHmmss");
                PhieuCanXe.InsertPhieuCan(newCanxe);
            }
            else if (macan == 2)
            {
                newCanxe.id = _idphieu;
                newCanxe.KLVao = Int32.Parse(txt_khoiluongvao.Text);
                newCanxe.KLRa = Int32.Parse(txt_can.Text);
                newCanxe.KLHang = Math.Abs(newCanxe.KLRa - newCanxe.KLVao);
                newCanxe.ThoiGianRa = DateTime.Now;
                txt_khoiluonghang.Text = newCanxe.KLHang.ToString(CultureInfo.InvariantCulture);
                txt_khoiluongra.Text = newCanxe.KLRa.ToString(CultureInfo.InvariantCulture);
                newCanxe.idCanRa = Common.gIdNguoidung.ToString();
                PhieuCanXe.UpdatePhieuCan(newCanxe);
            }
        }
        private void btn_CanVao_Click(object sender, EventArgs e)
        {
            loadcan(1);
            loadDataTableCanXe();
        }
        private void btn_CanRa_Click(object sender, EventArgs e)
        {
            loadcan(2);
            loadDataTableCanXe();
            _SetButtom(false, false, true, false);
        }
        private void btn_InPhieu_Click(object sender, EventArgs e)
        {
            Utilities.InPhieuCan(_idphieu, _loaiCan, _mavach, _print, _PaperCoppies);
        }

        private void bar_loaihang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frm_loaihang();
            frm.Show();
        }
        private void bar_congtrinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frm_congtrinh();
            frm.Show();
        }
        private void bar_congty_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frm_khachhang();
            frm.Show();
        }
        private void bar_baocaocan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frm_baocaotonghop();
            frm.Show();
        }
        private void bar_phuongtien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frm_phuongtien();
            frm.Show();
        }
        private void cbo_loaihang_EditValueChanged(object sender, EventArgs e)
        {
            var solo = "0";
            try
            {
                var soLo = ((HANGHOA) cbo_loaihang.Properties.GetRowByKeyValue(cbo_loaihang.EditValue)).SoLo;
                if (soLo != null)
                    solo = soLo.Value.ToString();
            }
            catch
            {
                // ignored
            }

            txt_solo.Text = solo;
        }
        private void bar_dangxuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form check in MdiChildren)
            {
                check.Close();
            }
            Common.frmM = this;
            Hide();
            frm_Login frm = (frm_Login)Common.frmL;
            frm.logout = true;
            frm.Show();

        }
        private void bar_phanquyenmenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frm_QuyenCN(); frm.Show();
        }

        private void bar_nhapphieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frm_nhaphieu(); frm.Show();
        }

        private void bar_changepass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frm_ChangePass(); frm.ShowDialog();
        }

        private void bar_baocaobetong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frm_BaoCaoCanBetong(); frm.Show();
        }

        private void bar_baocaocanxuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frm_BaoCaoCanXuatXa(); frm.Show();
        }

        private void bar_baocaocannhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frm_BaoCaoCanNhap(); frm.Show();
        }
        private void bar_canxe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frm_BaoCaoCanXeTai(); frm.Show();
        }

        private void bar_canxuatvattu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frm_BaoCaoCanXuatVatTu(); frm.Show();
        }

        private void bar_capnhatdulieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //UpdateDataServer();
            Utilities.UpdateDataServer();
        }


        private void bar_info_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //UpdateDataServer();
        }

        private void repositoryItemButtonEdit_delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                _idphieu = Int32.Parse(gridView_HTCANXE.GetFocusedRowCellValue("id").ToString());
                Common.db = new DataCanXeDataContext(Common.gConn);
                CANXE oldcanxe = Common.db.CANXEs.Single(o => o.id == _idphieu);
                string info = @"Xóa phiếu cân xe số: " + oldcanxe.SoPhieu + " : " + oldcanxe.SoXe;
                if (info.Confirm())
                {
                    oldcanxe.isDelete = true;
                    oldcanxe.TimeDelete = DateTime.Now;
                    Common.db.SubmitChanges();
                    loadDataTableCanXe();
                    String.Format("Xóa phiêu cân {0} thành công!", oldcanxe.SoPhieu).Show(string.Empty, MessageType.Information);
                }
            }
            catch
            {
                "Xóa phiêu cân không thành công!".Show(string.Empty, MessageType.Error);
            }
        }
        private void btn_tinhkhoiluong_Click(object sender, EventArgs e)
        {
            int KLVao = Int32.Parse(txt_khoiluongvao.Text);
            int KLRa = Int32.Parse(txt_can.Text);
            int KLHang = Math.Abs(KLRa - KLVao);
            txt_khoiluonghang.Text = KLHang.ToString();
            txt_khoiluongra.Text = KLRa.ToString();
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            _SetNew();
        }
    }
}