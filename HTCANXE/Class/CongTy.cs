using System.Collections.Generic;
using System.Linq;
using HTCANXE.Model;

namespace HTCANXE.Class
{
    class CongTy
    {
        public static List<KHACHHANG> GetlList(string loaihang)
        {
            List<KHACHHANG> result;
            Common.db = new DataCanXeDataContext(Common.gConn);
            result = Common.db.KHACHHANGs.ToList();
            return result;
        }
    }
}
