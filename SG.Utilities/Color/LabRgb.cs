using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SG.Utilities
{
    public class LabRgb
    {
        public static int[] LabToRgb(double[] Lab)
        {
            var xyz = Lab2XYZ(Lab);
            var rgb = XYZ2RGB(xyz);
            return rgb;
        }

        public static double[] RgbToLab(int[] rgb)
        {
            double[] drgb = new double[3];
            drgb[0] = rgb[0];
            drgb[1] = rgb[1];
            drgb[2] = rgb[2];
            var xyz = RGB2XYZ(drgb);
            var lab = XYZ2Lab(xyz);
            return lab;
        }

        private static double[] Lab2XYZ(double[] Lab)
        {
            double[] XYZ = new double[3];
            double L, a, b;
            double fx, fy, fz;
            double Xn, Yn, Zn;
            Xn = 95.04;
            Yn = 100;
            Zn = 108.89;

            L = Lab[0];
            a = Lab[1];
            b = Lab[2];

            fy = (L + 16) / 116;
            fx = a / 500 + fy;
            fz = fy - b / 200;

            if (fx > 0.2069)
            {
                XYZ[0] = Xn * Math.Pow(fx, 3);
            }
            else
            {
                XYZ[0] = Xn * (fx - 0.1379) * 0.1284;
            }

            if ((fy > 0.2069) || (L > 8))
            {
                XYZ[1] = Yn * Math.Pow(fy, 3);
            }
            else
            {
                XYZ[1] = Yn * (fy - 0.1379) * 0.1284;
            }

            if (fz > 0.2069)
            {
                XYZ[2] = Zn * Math.Pow(fz, 3);
            }
            else
            {
                XYZ[2] = Zn * (fz - 0.1379) * 0.1284;
            }

            return XYZ;
        }



        private static double[] XYZ2Lab(double[] XYZ)
        {
            double[] Lab = new double[3];
            double X, Y, Z;
            X = XYZ[0];
            Y = XYZ[1];
            Z = XYZ[2];
            double Xn, Yn, Zn;
            Xn = 95.04;
            Yn = 100;
            Zn = 108.89;
            double XXn, YYn, ZZn;
            XXn = X / Xn;
            YYn = Y / Yn;
            ZZn = Z / Zn;

            double fx, fy, fz;

            if (XXn > 0.008856)
            {
                fx = Math.Pow(XXn, 0.333333);
            }
            else
            {
                fx = 7.787 * XXn + 0.137931;
            }

            if (YYn > 0.008856)
            {
                fy = Math.Pow(YYn, 0.333333);
            }
            else
            {
                fy = 7.787 * YYn + 0.137931;
            }

            if (ZZn > 0.008856)
            {
                fz = Math.Pow(ZZn, 0.333333);
            }
            else
            {
                fz = 7.787 * ZZn + 0.137931;
            }

            Lab[0] = 116 * fy - 16;
            Lab[1] = 500 * (fx - fy);
            Lab[2] = 200 * (fy - fz);

            return Lab;
        }



        private static double[] RGB2XYZ(double[] sRGB)
        {
            double[] XYZ = new double[3];
            double sR, sG, sB;
            sR = sRGB[0];
            sG = sRGB[1];
            sB = sRGB[2];
            sR /= 255;
            sG /= 255;
            sB /= 255;

            if (sR <= 0.04045)
            {
                sR = sR / 12.92;
            }
            else
            {
                sR = Math.Pow(((sR + 0.055) / 1.055), 2.4);
            }

            if (sG <= 0.04045)
            {
                sG = sG / 12.92;
            }
            else
            {
                sG = Math.Pow(((sG + 0.055) / 1.055), 2.4);
            }

            if (sB <= 0.04045)
            {
                sB = sB / 12.92;
            }
            else
            {
                sB = Math.Pow(((sB + 0.055) / 1.055), 2.4);
            }

            XYZ[0] = 41.24 * sR + 35.76 * sG + 18.05 * sB;
            XYZ[1] = 21.26 * sR + 71.52 * sG + 7.2 * sB;
            XYZ[2] = 1.93 * sR + 11.92 * sG + 95.05 * sB;

            return XYZ;
        }


        private static int[] XYZ2RGB(double[] XYZ)
        {
            int[] sRGB = new int[3];
            double X, Y, Z;
            double dr, dg, db;
            X = XYZ[0];
            Y = XYZ[1];
            Z = XYZ[2];

            dr = 0.032406 * X - 0.015371 * Y - 0.0049895 * Z;
            dg = -0.0096891 * X + 0.018757 * Y + 0.00041914 * Z;
            db = 0.00055708 * X - 0.0020401 * Y + 0.01057 * Z;

            if (dr <= 0.00313)
            {
                dr = dr * 12.92;
            }
            else
            {
                dr = Math.Exp(Math.Log(dr) / 2.4) * 1.055 - 0.055;
            }

            if (dg <= 0.00313)
            {
                dg = dg * 12.92;
            }
            else
            {
                dg = Math.Exp(Math.Log(dg) / 2.4) * 1.055 - 0.055;
            }

            if (db <= 0.00313)
            {
                db = db * 12.92;
            }
            else
            {
                db = Math.Exp(Math.Log(db) / 2.4) * 1.055 - 0.055;
            }

            dr = dr * 255;
            dg = dg * 255;
            db = db * 255;

            dr = Math.Min(255, dr);
            dg = Math.Min(255, dg);
            db = Math.Min(255, db);

            sRGB[0] = (int)(dr + 0.5) < 0 ? 0 : (int)(dr + 0.5);
            sRGB[1] = (int)(dg + 0.5) < 0 ? 0 : (int)(dg + 0.5);
            sRGB[2] = (int)(db + 0.5) < 0 ? 0 : (int)(db + 0.5);

            return sRGB;
        }

    }
}
