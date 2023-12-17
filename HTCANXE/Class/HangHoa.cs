using System.Collections.Generic;
using System.Linq;
using HTCANXE.Model;

namespace HTCANXE.Class
{
    class HangHoa
    {
        public static List<HANGHOA> GetlList()
        {
            List<HANGHOA> result;
            Common.db = new DataCanXeDataContext(Common.gConn);
            result = Common.db.HANGHOAs.ToList();
            return result;
        }
        public static List<HANGHOA> GetlList(string nhomcan)
        {
            List<HANGHOA> result;
            Common.db = new DataCanXeDataContext(Common.gConn);
            result = Common.db.HANGHOAs.Where(n => n.NhomCan == nhomcan || n.NhomCan=="ALL").ToList();
            return result;
        }
    }
}
