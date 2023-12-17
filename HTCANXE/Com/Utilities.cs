using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using HTCANXE.Model;
using HTCANXE.Report;
using DataTable = System.Data.DataTable;

namespace HTCANXE.Com
{
    public enum MessageType
    {
        Information,
        Warning,
        Error
    };

    public static class Utilities
    {
        public static bool Confirm(this string message)
        {
            if (XtraMessageBox.Show(message, ":: Hệ thống cân xe ::", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                return true;
            return false;
        }

        public static void Show(this string message, string objectError, MessageType type)
        {
            switch (type)
            {
                case MessageType.Information:
                    XtraMessageBox.Show(message, ":: Hệ thống cân xe ::", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;
                case MessageType.Warning:
                    XtraMessageBox.Show(message, ":: Hệ thống cân xe ::", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    break;
                case MessageType.Error:
                    if (objectError == "")
                        XtraMessageBox.Show(message, ":: Hệ thống cân xe ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        XtraMessageBox.Show(string.Format("Lỗi xảy ra trong ứng dụng ở module [{0}].\n\n\rError Details: {1}.\n\n\r(Chú ý: Hãy ghi lại các thông số về lỗi và thông báo cho người quản trị.\n\rHoặc liên hệ trực tiếp với tác giả.)", objectError, message), ":: Hệ thống cân xe ::", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    break;
            }
        }
        public static string SoPhieuCan()
        {
            try
            {
                Common.db = new DataCanXeDataContext(Common.gConn);
                var result = Common.db.Fn_GetSoPhieuCanXe(Common.gTramCan).SingleOrDefault()?.SoPhieu;
                if (result != null && result.Length > 2)
                {
                    var DateNow = DateTime.Now;
                    var sp = result.Split('K');
                    var kiemngay = sp[1].Substring(1);
                    var day = DateNow.AddHours(-6).ToString("ddMMyy");
                    int sophieu;
                    int catruc = DateTime.Now.AddHours(-6).TimeOfDay.Hours / 8 + 1;
                    if (kiemngay == day)
                    {
                        sophieu = Int32.Parse(sp[0]) + 1;
                    }
                    else
                    {
                        sophieu = 1;
                    }
                    var ngayht = DateNow.ToString("ddMMyy");

                    //Console.WriteLine(catruc);
                    return $"{sophieu}K" + catruc + ngayht;
                }
                else
                {
                    var DateNow = DateTime.Now;
                    int sophieu = 1;
                    var ngayht = DateNow.ToString("ddMMyy");
                    int catruc = DateTime.Now.AddHours(-6).TimeOfDay.Hours / 8 + 1;
                    //Console.WriteLine(catruc);
                    return $"{sophieu}K" + catruc + ngayht;
                }
            }
            catch
            {
                // ignored
            }

            return string.Empty;
        }
        public static void InPhieuCan(int _idphieu, string _loaiCan, string _mavach,bool _print, short _PaperCoppies)
        {
            if (_loaiCan == "XUAT" || _loaiCan == "XUATVT")
            {
                if (_mavach == "B")
                {
                    var rpt = new rpt_InPhieuCanXuatBarCode()
                    {
                        id = _idphieu,
                        loaican = _loaiCan
                    };
                    var pt = new ReportPrintTool(rpt);
                    if (!_print)
                    {
                        pt.ShowPreviewDialog();
                    }
                    else
                    {
                        pt.PrinterSettings.Copies = _PaperCoppies;
                        pt.Print();
                    }
                }
                if (_mavach == "Q")
                {
                    var rpt = new rpt_InPhieuCanXuat()
                    {
                        id = _idphieu
                    };
                    var pt = new ReportPrintTool(rpt);
                    if (!_print)
                    {
                        pt.ShowPreviewDialog();
                    }
                    else
                    {
                        pt.PrinterSettings.Copies = _PaperCoppies;
                        pt.Print();
                    }
                }

            }
            if (_loaiCan == "NHAP")
            {
                if (_mavach == "B")
                {
                    var rpt = new rpt_InPhieuCanNhapBarCode()
                    {
                        id = _idphieu
                    };
                    var pt = new ReportPrintTool(rpt);
                    if (!_print)
                    {
                        pt.ShowPreviewDialog();
                    }
                    else
                    {
                        pt.PrinterSettings.Copies = _PaperCoppies;
                        pt.Print();
                    }
                }
                if (_mavach == "Q")
                {
                    var rpt = new rpt_InPhieuCanNhap()
                    {
                        id = _idphieu
                    };
                    var pt = new ReportPrintTool(rpt);
                    if (!_print)
                    {
                        pt.ShowPreviewDialog();
                    }
                    else
                    {
                        pt.PrinterSettings.Copies = _PaperCoppies;
                        pt.Print();
                    }
                }
            }
            if (_loaiCan == "BETONG")
            {
                var rpt = new rpt_InPhieuCanBetong()
                {
                    id = _idphieu
                };
                var pt = new ReportPrintTool(rpt);
                if (!_print)
                {
                    pt.ShowPreviewDialog();
                }
                else
                {
                    pt.PrinterSettings.Copies = _PaperCoppies;
                    pt.Print();
                }
            }
        }

        public static string GetTags(TreeNode parentNode)
        {
            string result = string.Empty;
            if (parentNode == null)
                return result;

            if (parentNode.Nodes.Count == 0)
                return parentNode.Tag.ToString();
            else
                result = parentNode.Tag.ToString();

            for (int i = 0; i < parentNode.Nodes.Count; i++)
            {
                result = String.Format("{0},{1}", result, GetTags(parentNode.Nodes[i]));
            }
            return result;
        }

        public static TreeNode FindNode(this object keyNode, TreeNode parentNode)
        {
            if (parentNode == null)
                return null;

            if (parentNode.Tag.ToString() == keyNode.ToString())
                return parentNode;

            for (int i = 0; i < parentNode.Nodes.Count; i++)
            {
                TreeNode foundNode = FindNode(keyNode, parentNode.Nodes[i]);
                if (foundNode != null)
                    return foundNode;
            }
            return null;
        }

        public static TreeNode FindNode(this object keyNode, TreeNodeCollection Nodes)
        {
            foreach (TreeNode node in Nodes)
            {
                if (node == null)
                    return null;

                if (node.Tag.ToString() == keyNode.ToString())
                    return node;

                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    TreeNode foundNode = FindNode(keyNode, node.Nodes[i]);
                    if (foundNode != null)
                        return foundNode;
                }
            }
            return null;
        }

        public static string Connect(string connstring)
        {
            string result = string.Empty;
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                try
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    conn.Open();
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = rec.GetType().GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) ?? DBNull.Value;
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

       

        public static string Encrypt(string toEncrypt, string key, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
            }
            else
                keyArray = Encoding.UTF8.GetBytes(key);

            using (var tdes = new TripleDESCryptoServiceProvider() { Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
            {
                using (ICryptoTransform cTransform = tdes.CreateEncryptor())
                {
                    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
                }
            }
        }

        public static string Decrypt(string toDecrypt, string key, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
            }
            else
                keyArray = Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Encoding.UTF8.GetString(resultArray);
        }
        public static bool UpdateDataServer()
        {
            var db = new DataCanXeDataContext(Common.gConn);
            var dbserver = new DataCanXeDataContext(Common.gConnServer);
            var listcanxe = db.CANXEs.Where(n => n.IsUpdateServer == false);
            foreach (CANXE item in listcanxe)
            {
                if (UpdateDataServerItem(item))
                {
                    var resurt = db.Fn_SetUpdateDatabaseServer(item.id, item.MaBarCode).Single(m => m.id == item.id);
                }
            }
            return true;
        }

        public static bool UpdateDataServerItem(CANXE item)
        {
            var query = "INSERT INTO CANXE (SoPhieu,SoXe,KLXe,SoRomooc,KLRomooc,LoaiHang,CongTy," +
                "SoLo,SoNiem,KLVao,ThoiGianVao,idCanVao,KLRa,ThoiGianRa,idCanRa," +
                "IdDelete,TimeDelete,IdEdit,TimeEdit,isDelete,KLHang,MACAN, " +
                "NoiXuat,TramCan,CongTrinh,IdNhapHT,TimeNhapHT,MaBarCode,IdNhap,UpdateServer," +
                "IsUpdateServer) VALUES (@SoPhieu,@SoXe,@KLXe,@SoRomooc,@KLRomooc,@LoaiHang,@CongTy,@SoLo,@SoNiem, @KLVao, @ThoiGianVao,@idCanVao," +
                "@KLRa, @ThoiGianRa,@idCanRa, @IdDelete, @TimeDelete, @IdEdit, @TimeEdit, @isDelete, @KLHang," +
                "@MACAN,@NoiXuat,@TramCan, @CongTrinh, @IdNhapHT, @TimeNhapHT,@MaBarCode, @IdNhap, @UpdateServer, @IsUpdateServer)";
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Common.gConnServer))
                {
                    conn.Open();
                    //SqlCommand comm = new SqlCommand(sql, conn);
                    using (var command = new SqlCommand(query, conn))
                    {
                        command.Parameters.Add("@SoPhieu", sqlDbType: SqlDbType.NVarChar).Value = item.SoPhieu;
                        command.Parameters.Add("@SoXe", sqlDbType: SqlDbType.NVarChar).Value = item.SoXe;
                        command.Parameters.Add("@KLXe", sqlDbType: SqlDbType.Float).Value = item.KLXe;
                        command.Parameters.Add("@SoRomooc", sqlDbType: SqlDbType.NVarChar).Value = item.SoRomooc;
                        command.Parameters.Add("@KLRomooc", sqlDbType: SqlDbType.Float).Value = item.KLRomooc;
                        command.Parameters.Add("@LoaiHang", sqlDbType: SqlDbType.NVarChar).Value = item.LoaiHang;
                        command.Parameters.Add("@CongTy", sqlDbType: SqlDbType.NVarChar).Value = item.CongTy;
                        command.Parameters.Add("@SoLo", sqlDbType: SqlDbType.NVarChar).Value = item.SoLo;
                        command.Parameters.Add("@SoNiem", sqlDbType: SqlDbType.NVarChar).Value = item.SoNiem;
                        command.Parameters.Add("@KLVao", sqlDbType: SqlDbType.Float).Value = item.KLVao;
                        command.Parameters.Add("@ThoiGianVao", sqlDbType: SqlDbType.DateTime).Value = item.ThoiGianVao;
                        command.Parameters.Add("@idCanVao", sqlDbType: SqlDbType.Int).Value = item.idCanVao;
                        command.Parameters.Add("@KLRa", sqlDbType: SqlDbType.Float).Value = item.KLRa;
                        command.Parameters.Add("@ThoiGianRa", sqlDbType: SqlDbType.DateTime).Value = item.ThoiGianRa;
                        command.Parameters.Add("@idCanRa", sqlDbType: SqlDbType.Int).Value = item.idCanRa;
                        command.Parameters.Add("@IdDelete", sqlDbType: SqlDbType.Int).Value = item.IdDelete;
                        command.Parameters.Add("@TimeDelete", sqlDbType: SqlDbType.DateTime).Value = item.TimeDelete != null ? item.TimeDelete : DateTime.Now;
                        command.Parameters.Add("@IdEdit", sqlDbType: SqlDbType.Int).Value = item.IdEdit;
                        command.Parameters.Add("@TimeEdit", sqlDbType: SqlDbType.DateTime).Value = item.TimeEdit != null ? item.TimeDelete : DateTime.Now;
                        command.Parameters.Add("@isDelete", sqlDbType: SqlDbType.Bit).Value = item.isDelete;
                        command.Parameters.Add("@KLHang", sqlDbType: SqlDbType.Float).Value = item.KLHang;
                        command.Parameters.Add("@MACAN", sqlDbType: SqlDbType.NVarChar).Value = item.MACAN;
                        command.Parameters.Add("@NoiXuat", sqlDbType: SqlDbType.NVarChar).Value = item.NoiXuat;
                        command.Parameters.Add("@TramCan", sqlDbType: SqlDbType.NVarChar).Value = item.TramCan;
                        command.Parameters.Add("@CongTrinh", sqlDbType: SqlDbType.Int).Value = item.CongTrinh;
                        command.Parameters.Add("@IdNhapHT", sqlDbType: SqlDbType.Int).Value = item.IdNhapHT;
                        command.Parameters.Add("@TimeNhapHT", sqlDbType: SqlDbType.DateTime).Value = item.TimeNhapHT != null ? item.TimeDelete : DateTime.Now;
                        command.Parameters.Add("@MaBarCode", sqlDbType: SqlDbType.NVarChar).Value = item.MaBarCode;
                        command.Parameters.Add("@IdNhap", sqlDbType: SqlDbType.Int).Value = 0;
                        command.Parameters.Add("@UpdateServer", sqlDbType: SqlDbType.DateTime).Value = DateTime.Now;
                        command.Parameters.Add("@IsUpdateServer", sqlDbType: SqlDbType.Bit).Value = true;
                        //command.CommandTimeout = 1000;
                        command.ExecuteNonQuery();

                    }
                    conn.Close();
                    result = true;
                }
            }
            catch
            {
                "Vui lòng thông báo với quản trị viên lỗi kết nối!".Show(string.Empty, MessageType.Information);
            }
            return result;
        }
    }
}
