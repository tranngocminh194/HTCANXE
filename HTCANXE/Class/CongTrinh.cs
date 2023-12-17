using System;
using System.Collections.Generic;
using System.Linq;
using HTCANXE.Model;

namespace HTCANXE.Class
{
    class CongTrinh
    {
        public static List<CONGTRINH> GetlList(string loaihang)
        {
            List<CONGTRINH> result;
            Common.db = new DataCanXeDataContext(Common.gConn);
            result = Common.db.CONGTRINHs.ToList();
            return result;
        }
        public static string InsertCongTrinh(CONGTRINH newcongtrinh)
        {
            string result = "";
            try
            {
                Common.db = new DataCanXeDataContext(Common.gConn);
                Common.db.CONGTRINHs.InsertOnSubmit(newcongtrinh);
                Common.db.SubmitChanges();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
        public static string UpdateCongTrinh(CONGTRINH newCongtrinh)
        {
            string result = "";
            try
            {
                Common.db = new DataCanXeDataContext(Common.gConn);
                CONGTRINH oldCongtrinh = Common.db.CONGTRINHs.Single(o => o.ID == newCongtrinh.ID);
                oldCongtrinh.DiaChi = newCongtrinh.DiaChi;
                oldCongtrinh.KhachHang = newCongtrinh.KhachHang;
                oldCongtrinh.Ten = newCongtrinh.Ten;
                oldCongtrinh.TinhThanh = newCongtrinh.TinhThanh;
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
