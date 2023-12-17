using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using HTCANXE.Model;

namespace HTCANXE
{
    public static class Common
    {
        public static Form frmL = null;
        public static Form frmM = null;

        // Khai báo đường dẫn đến chương trình
        public static string appPath = Application.StartupPath;
        // Khai báo đối tượng kết nối cơ sở dữ liệu
        public static DataCanXeDataContext db;
        // Khai báo key dùng để mã hóa và giải mã dữ liệu
        public static string gKey = "tranngocminh@xmtd.vn";

        // Khai báo key bản quyền
        public static string gLicense = "tnminh";

        // Khai báo chuỗi kết nối
        public static string gConn;
        public static string gConnServer;

        // Khai báo biến thông tin đơn vị
        public static string gTenTramCan;
        public static string gTramCan; 

        // Khai báo biến người dùng
        public static int gIdNguoidung;
        public static string gNguoidung;
        public static string gHoten;   
        public static string gMatkhau;  
    

        // Khai báo biến thông số chương trình
        public static string gDatabase;
        public static string gServer;
        public static string gCaptionXLDL = "Đang xử lý dữ liệu...";
        public static string gCaptionNDL = "Đang nạp dữ liệu...";
        public static string gTitle = "Vui lòng đợi trong giây lát!";        
    }
}
