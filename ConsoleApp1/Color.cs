using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public class LR
    {
        public double gamma(float x)
        { return x > 0.04045 ? Math.Pow((x + 0.055f) / 1.055f, 2.4f) : x / 12.92; }

        public Lab RGBToLab(RGB rgb)
        {
            Lab lab=new Lab();
            double B = gamma(rgb.B / 255.0f);
            double G = gamma(rgb.G / 255.0f);
            double R = gamma(rgb.R / 255.0f);
            double X = 0.412453 * R + 0.357580 * G + 0.180423 * B;
            double Y = 0.212671 * R + 0.715160 * G + 0.072169 * B;
            double Z = 0.019334 * R + 0.119193 * G + 0.950227 * B;

            X /= 0.95047;
            Y /= 1.0;
            Z /= 1.08883;


            double FX = X > 0.008856f ? Math.Pow(X, 1.0f / 3.0f) : (7.787f * X + 0.137931f);
            double FY = Y > 0.008856f ? Math.Pow(Y, 1.0f / 3.0f) : (7.787f * Y + 0.137931f);
            double FZ = Z > 0.008856f ? Math.Pow(Z, 1.0f / 3.0f) : (7.787f * Z + 0.137931f);
            lab.L = Y > 0.008856f ? (116.0f * FY - 16.0f) : (903.3f * Y);
            lab.a = 500f * (FX - FY);
            lab.b = 200f * (FY - FZ);
            return lab;
        }

     
    }

    public class Lab
    {
        public double L { get; set; }
        public double a { get; set; }
        public double b { get; set; }

    }
    public class RGB
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

    }

}
