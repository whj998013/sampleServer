using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SG.Utilities
{
    public class ColorHelper
    {

        public static string GetRgb16Color(int[] rgb)
        {
            string r = Convert.ToString(rgb[0], 16);
            string g = Convert.ToString(rgb[1], 16);
            string b = Convert.ToString(rgb[2], 16);
            if (r.Length == 1) r = "0" + r;
            if (g.Length == 1) g = "0" + g;
            if (b.Length == 1) b = "0" + b;
            return "#" + r + g + b;
        }

        public static int[] GetRgbColor(string rgb)
        {
            int r = Convert.ToInt32("0x" + rgb.Substring(1, 2), 16);
            int g = Convert.ToInt32("0x" + rgb.Substring(3, 2), 16);
            int b = Convert.ToInt32("0x" + rgb.Substring(5, 2), 16);
            return new int[] { r, g, b };
        }
    }

}
