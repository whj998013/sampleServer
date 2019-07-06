using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SG.Utilities
{
    public class LabDelta
    {
        /// <CIE 1976 L*a*b*色差公式>
        /// </summary>
        /// <param name="L1"></param>
        /// <param name="a1"></param>
        /// <param name="b1"></param>
        /// <param name="L2"></param>
        /// <param name="a2"></param>
        /// <param name="b2"></param>
        /// <returns></returns>

        public static double Delta_Eab(double L1, double a1, double b1, double L2, double a2, double b2)
        {
            double Eab = 0;             //  △Eab
            double chafang_L = 0;             //  (L1-L2)*(L1-L2)
            double chafang_a = 0;             //   (a1-a2)*(a1-a2)
            double chafang_b = 0;             //   (b1-b2)*(b1-b2)

            chafang_L = (L1 - L2) * (L1 - L2);      //差-方
            chafang_a = (a1 - a2) * (a1 - a2);
            chafang_b = (b1 - b2) * (b1 - b2);

            Eab = Math.Pow(chafang_L + chafang_a + chafang_b, 0.5);

            return Eab;
        }

        /// <CIE DE 2000色差公式>
        /// </summary>
        /// <param name="L1"></param>
        /// <param name="a1"></param>
        /// <param name="b1"></param>
        /// <param name="L2"></param>
        /// <param name="a2"></param>
        /// <param name="b2"></param>
        /// <returns></returns>

        public static double Delta_E00(double L1, double a1, double b1, double L2, double a2, double b2)
        {
            //参考《现代颜色技术原理及应用》P88数据
            double E00 = 0;               //CIEDE2000色差E00
            double LL1, LL2, aa1, aa2, bb1, bb2; //声明L' a' b' （1,2）
            double delta_LL, delta_CC, delta_hh, delta_HH;        // 第二部的四个量
            double kL, kC, kH;
            double RT = 0;                //旋转函数RT
            double G = 0;                  //G表示CIELab 颜色空间a轴的调整因子,是彩度的函数.
            double mean_Cab = 0;    //两个样品彩度的算术平均值
            double SL, SC, SH, T;
            //------------------------------------------
            //参考实验条件见P88
            kL = 1;
            kC = 1;
            kH = 1;
            //------------------------------------------
            mean_Cab = (CaiDu(a1, b1) + CaiDu(a2, b2)) / 2;
            double mean_Cab_pow7 = Math.Pow(mean_Cab, 7);       //两彩度平均值的7次方
            G = 0.5 * (1 - Math.Pow(mean_Cab_pow7 / (mean_Cab_pow7 + Math.Pow(25, 7)), 0.5));

            LL1 = L1;
            aa1 = a1 * (1 + G);
            bb1 = b1;

            LL2 = L2;
            aa2 = a2 * (1 + G);
            bb2 = b2;

            double CC1, CC2;               //两样本的彩度值
            CC1 = CaiDu(aa1, bb1);
            CC2 = CaiDu(aa2, bb2);
            double hh1, hh2;                  //两样本的色调角
            hh1 = SeDiaoJiao(aa1, bb1);
            hh2 = SeDiaoJiao(aa2, bb2);

            delta_LL = LL1 - LL2;
            delta_CC = CC1 - CC2;
            delta_hh = SeDiaoJiao(aa1, bb1) - SeDiaoJiao(aa2, bb2);
            delta_HH = 2 * Math.Sin(Math.PI * delta_hh / 360) * Math.Pow(CC1 * CC2, 0.5);

            //-------第三步--------------
            //计算公式中的加权函数SL,SC,SH,T
            double mean_LL = (LL1 + LL2) / 2;
            double mean_CC = (CC1 + CC2) / 2;
            double mean_hh = (hh1 + hh2) / 2;

            SL = 1 + 0.015 * Math.Pow(mean_LL - 50, 2) / Math.Pow(20 + Math.Pow(mean_LL - 50, 2), 0.5);
            SC = 1 + 0.045 * mean_CC;
            T = 1 - 0.17 * Math.Cos((mean_hh - 30) * Math.PI / 180) + 0.24 * Math.Cos((2 * mean_hh) * Math.PI / 180)
                  + 0.32 * Math.Cos((3 * mean_hh + 6) * Math.PI / 180) - 0.2 * Math.Cos((4 * mean_hh - 63) * Math.PI / 180);
            SH = 1 + 0.015 * mean_CC * T;

            //------第四步--------
            //计算公式中的RT
            double mean_CC_pow7 = Math.Pow(mean_CC, 7);
            double RC = 2 * Math.Pow(mean_CC_pow7 / (mean_CC_pow7 + Math.Pow(25, 7)), 0.5);
            double delta_xita = 30 * Math.Exp(-Math.Pow((mean_hh - 275) / 25, 2));        //△θ 以°为单位
            RT = -Math.Sin((2 * delta_xita) * Math.PI / 180) * RC;

            double L_item, C_item, H_item;
            L_item = delta_LL / (kL * SL);
            C_item = delta_CC / (kC * SC);
            H_item = delta_HH / (kH * SH);

            E00 = Math.Pow(L_item * L_item + C_item * C_item + H_item * H_item + RT * C_item * H_item, 0.5);

            return E00;
        }
        //彩度计算
        private static double CaiDu(double a, double b)
        {
            double Cab = 0;
            Cab = Math.Pow(a * a + b * b, 0.5);
            return Cab;
        }
        //色调角计算
        private static double SeDiaoJiao(double a, double b)
        {
            double h = 0;
            double hab = 0;
            a = a == 0 ? 0.000001 : a;
            h = (180 / Math.PI) * Math.Atan(b / a);           //有正有负

            if (a > 0 && b > 0)
            {
                hab = h;
            }
            else if (a < 0 && b > 0)
            {
                hab = 180 + h;
            }
            else if (a < 0 && b < 0)
            {
                hab = 180 + h;
            }
            else     //a>0&&b<0
            {
                hab = 360 + h;
            }
            return hab;
        }
    }
}
