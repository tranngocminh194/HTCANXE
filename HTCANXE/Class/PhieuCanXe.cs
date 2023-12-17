using System;
using System.Linq;
using HTCANXE.Model;

namespace HTCANXE.Class
{
    class PhieuCanXe
    {
        public static string InsertPhieuCan(CANXE canxe)
        {             
            string result = "";
            try
            {
                Common.db = new DataCanXeDataContext(Common.gConn);
                Common.db.CANXEs.InsertOnSubmit(canxe);
                Common.db.SubmitChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;          
        }
        public static string UpdatePhieuCan(CANXE newcanxe)
        {
            string result = "";
            try
            {
                Common.db = new DataCanXeDataContext(Common.gConn);
                CANXE oldcanxe = Common.db.CANXEs.Single(o => o.id == newcanxe.id);
                //oldcanxe.SoPhieu = newcanxe.SoPhieu;
                oldcanxe.SoXe = newcanxe.SoXe;
                oldcanxe.KLXe = newcanxe.KLXe;
                oldcanxe.SoRomooc = newcanxe.SoRomooc;
                oldcanxe.KLRomooc = newcanxe.KLRomooc;
                oldcanxe.LoaiHang = newcanxe.LoaiHang;
                oldcanxe.CongTrinh = newcanxe.CongTrinh;
                oldcanxe.CongTy = newcanxe.CongTy;
                oldcanxe.SoLo = newcanxe.SoLo;
                oldcanxe.SoNiem = newcanxe.SoNiem;
                //oldcanxe.KLVao = newcanxe.KLVao;
                oldcanxe.KLRa = newcanxe.KLRa;
                //oldcanxe.ThoiGianVao = newcanxe.ThoiGianVao;
                oldcanxe.ThoiGianRa = newcanxe.ThoiGianRa;
                //oldcanxe.idCanVao = newcanxe.idCanVao;
                oldcanxe.idCanRa = newcanxe.idCanRa;
                //oldcanxe.isDelete = newcanxe.isDelete;
                oldcanxe.KLHang = newcanxe.KLHang;
                //oldcanxe.MACAN = newcanxe.MACAN;
                oldcanxe.NoiXuat = newcanxe.NoiXuat;
                //oldcanxe.TramCan = newcanxe.TramCan;
                Common.db.SubmitChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
    }
}
