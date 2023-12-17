using System.Collections.Generic;
using System.Linq;
using HTCANXE.Model;

namespace HTCANXE.Class
{
    class PhuongTien
    {
        public static List<PHUONGTIEN> GetlList(string loaiphuongtien)
        {
            List<PHUONGTIEN> result;
            Common.db = new DataCanXeDataContext(Common.gConn);
            //result = Common.db.PHUONGTIENs.Where(o => o.Nhom == loaiphuongtien).ToList();
            result = Common.db.PHUONGTIENs.ToList();
            return result;
        }
        public static List<PHUONGTIEN> GetlList(string loaiphuongtien1, string loaiphuongtien2)
        {
            List<PHUONGTIEN> result;
            Common.db = new DataCanXeDataContext(Common.gConn);
            //result = Common.db.PHUONGTIENs.Where(o => o.Nhom == loaiphuongtien1 || o.Nhom==loaiphuongtien2).ToList();
            result = Common.db.PHUONGTIENs.ToList();
            return result;
        }
        public static List<PHUONGTIEN> GetlList()
        {
            List<PHUONGTIEN> result;
            Common.db = new DataCanXeDataContext(Common.gConn);
            result = Common.db.PHUONGTIENs.ToList();
            return result;
        }
    }
}
