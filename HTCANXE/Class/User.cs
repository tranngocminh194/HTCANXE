using System;
using System.Linq;
using HTCANXE.Model;

namespace HTCANXE.Class
{
    class User
    {
        public static USER GetByUser(string user)
        {
            USER result;
            Common.db = new DataCanXeDataContext(Common.gConn);
            result = Common.db.USERs.Single(o => o.Username == user);
            return result;
        }


        public static string Edit(USER newUser)
        {
            string result = "";
            try
            {
                Common.db = new DataCanXeDataContext(Common.gConn);
                USER oldUser = Common.db.USERs.Single(o => o.Username == newUser.Username);
                //oldUser.FullName = newUser.FullName;
                oldUser.Password = newUser.Password;
                oldUser.IsActive = newUser.IsActive;
                Common.db.SubmitChanges();
                //result = "TRUE";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        public static bool CheckLogin(string user, string password)
        {
            Common.db = new DataCanXeDataContext(Common.gConn);
            return Common.db.USERs.Where(q => q.Username == user && q.Password == password && q.IsActive).ToList().Count > 0;
        }


        public static void PhanQuyen(string user, Frm_Home frm)
        {
            if (user == "SA")
                return;
            //
            // 1. PHÂN QUYỀN CHỨC NĂNG MENU
            //
            // Ẩn tất cả menu
            foreach (DevExpress.XtraBars.Ribbon.RibbonPage page in frm.Ribbon.Pages)
            {
                page.Visible = false;
                foreach (DevExpress.XtraBars.Ribbon.RibbonPageGroup pagegroup in page.Groups)
                {
                    pagegroup.Visible = false;
                    foreach (DevExpress.XtraBars.BarButtonItemLink item in pagegroup.ItemLinks)
                    {
                        item.Visible = false;
                    }
                }
            }

            // Phân quyền
            // --Lấy về các quyền chức năng của user
            Common.db = new DataCanXeDataContext(Common.gConn);
            //CANXE oldcanxe = Common.db.CANXEs.Single(o => o.id == newcanxe.id);
            var quyen = Common.db.Fn_GetQuyenMenu(Common.gIdNguoidung).ToList();
            foreach (var itemq in quyen)
            {
                foreach (DevExpress.XtraBars.Ribbon.RibbonPage page in frm.Ribbon.Pages)
                {
                    //page.Visible = false;
                    foreach (DevExpress.XtraBars.Ribbon.RibbonPageGroup pagegroup in page.Groups)
                    {
                        // pagegroup.Visible = false;
                        foreach (DevExpress.XtraBars.BarButtonItemLink item in pagegroup.ItemLinks)
                        {
                            // item.Visible = false;
                            if (itemq.Nut == item.Item.Name)
                            {
                                page.Visible = true;
                                pagegroup.Visible = true;
                                item.Visible = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
