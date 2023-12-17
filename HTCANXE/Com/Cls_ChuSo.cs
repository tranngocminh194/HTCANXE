﻿using System;
using System.Globalization;

namespace HTCANXE.Com
{
    public static class Cls_ChuSo
    {
        private static string Chu(string gNumber)
        {
            var result = string.Empty;
            switch (gNumber)
            {
                case "0":
                    result = "không";
                    break;
                case "1":
                    result = "một";
                    break;
                case "2":
                    result = "hai";
                    break;
                case "3":
                    result = "ba";
                    break;
                case "4":
                    result = "bốn";
                    break;
                case "5":
                    result = "năm";
                    break;
                case "6":
                    result = "sáu";
                    break;
                case "7":
                    result = "bảy";
                    break;
                case "8":
                    result = "tám";
                    break;
                case "9":
                    result = "chín";
                    break;
            }
            return result;
        }
        private static string Donvi(string so)
        {
            var Kdonvi = string.Empty;

            if (so.Equals("1"))
            {
                Kdonvi = string.Empty;
            }
            if (so.Equals("2"))
            {
                Kdonvi = "nghìn";
            }
            if (so.Equals("3"))
            {
                Kdonvi = "triệu";
            }
            if (so.Equals("4"))
            {
                Kdonvi = "tỷ";
            }
            if (so.Equals("5"))
            {
                Kdonvi = "nghìn tỷ";
            }
            if (so.Equals("6"))
            {
                Kdonvi = "triệu tỷ";
            }
            if (so.Equals("7"))
            {
                Kdonvi = "tỷ tỷ";
            }
            return Kdonvi;
        }
        private static string Tach(string tach3)
        {
            var Ktach = string.Empty;
            if (tach3.Equals("000"))
            {
                return string.Empty;
            }
            if (tach3.Length == 3)
            {
                var tr = tach3.Trim().Substring(0, 1).Trim();
                var ch = tach3.Trim().Substring(1, 1).Trim();
                var dv = tach3.Trim().Substring(2, 1).Trim();
                if (tr.Equals("0") && ch.Equals("0"))
                {
                    Ktach = " không trăm lẻ " + Chu(dv.Trim()) + " ";
                }
                if (!tr.Equals("0") && ch.Equals("0") && dv.Equals("0"))
                {
                    Ktach = Chu(tr.Trim()).Trim() + " trăm ";
                }
                if (!tr.Equals("0") && ch.Equals("0") && !dv.Equals("0"))
                {
                    Ktach = Chu(tr.Trim()).Trim() + " trăm lẻ " + Chu(dv.Trim()).Trim() + " ";
                }
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                {
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                }
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                {
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                }
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                {
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                }
                if (tr.Equals("0") && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                {
                    Ktach = " không trăm mười " + Chu(dv.Trim()).Trim() + " ";
                }
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("0"))
                {
                    Ktach = " không trăm mười ";
                }
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("5"))
                {
                    Ktach = " không trăm mười lăm ";
                }
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                {
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                }
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                {
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                }
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                {
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                }
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                {
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười " + Chu(dv.Trim()).Trim() + " ";
                }
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("0"))
                {
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười ";
                }
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("5"))
                {
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười lăm ";
                }
            }


            return Ktach;
        }
        public static string So_chu(double gNum)
        {
            if (gNum == 0)
            {
                return "Không";
            }
            var lso_chu = string.Empty;
            var tach_mod = string.Empty;
            var tach_conlai = string.Empty;
            var Num = Math.Round(gNum, 0);
            var gN = Convert.ToString(Num, CultureInfo.CurrentCulture);
            var m = Convert.ToInt32(gN.Length / 3);
            var mod = gN.Length - m * 3;
            string dau;


            if (gNum < 0)
            {
                dau = "[-]";
            }
            dau = string.Empty;


            if (mod.Equals(1))
            {
                tach_mod = "00" + Convert.ToString(Num.ToString(CultureInfo.CurrentCulture).Trim().Substring(0, 1)).Trim();
            }
            if (mod.Equals(2))
            {
                tach_mod = "0" + Convert.ToString(Num.ToString(CultureInfo.CurrentCulture).Trim().Substring(0, 2)).Trim();
            }
            if (mod.Equals(0))
            {
                tach_mod = "000";
            }
            if (Num.ToString(CultureInfo.CurrentCulture).Length > 2)
            {
                tach_conlai = Convert.ToString(Num.ToString(CultureInfo.CurrentCulture).Trim().Substring(mod, Num.ToString(CultureInfo.CurrentCulture).Length - mod)).Trim();
            }

            var im = m + 1;
            if (mod > 0)
            {
                lso_chu = Tach(tach_mod).Trim() + " " + Donvi(im.ToString().Trim());
            }

            var i = m;
            var _m = m;
            var j = 1;
            string tach3_;

            while (i > 0)
            {
                var tach3 = tach_conlai.Trim().Substring(0, 3).Trim();
                tach3_ = tach3;
                lso_chu = lso_chu.Trim() + " " + Tach(tach3.Trim()).Trim();
                m = _m + 1 - j;
                if (!tach3_.Equals("000"))
                {
                    lso_chu = lso_chu.Trim() + " " + Donvi(m.ToString().Trim()).Trim();
                }
                tach_conlai = tach_conlai.Trim().Substring(3, tach_conlai.Trim().Length - 3);

                i = i - 1;
                j = j + 1;
            }
            if (lso_chu.Trim().Substring(0, 1).Equals("k"))
            {
                lso_chu = lso_chu.Trim().Substring(10, lso_chu.Trim().Length - 10).Trim();
            }
            if (lso_chu.Trim().Substring(0, 1).Equals("l"))
            {
                lso_chu = lso_chu.Trim().Substring(2, lso_chu.Trim().Length - 2).Trim();
            }
            if (lso_chu.Trim().Length > 0)
            {
                lso_chu = dau.Trim() + " " + lso_chu.Trim().Substring(0, 1).Trim().ToUpper() + lso_chu.Trim().Substring(1, lso_chu.Trim().Length - 1).Trim() + " kg";
            }
            return lso_chu.Trim();
        }
    }
}
