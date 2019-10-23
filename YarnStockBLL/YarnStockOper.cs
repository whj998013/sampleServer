using StorageData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarnStockBLL
{
    public class YarnStockOper
    {
        public static void  YarnStockCorrect()
        {
            using YarnStockContext ysc = new YarnStockContext();
            foreach (var p in ysc.LocalProduct)
            {

                p.Num = Math.Round(p.Num, 2);
                if (p.Num < 0.1)
                {
                    ysc.LocalProduct.Remove(p);
                }

            }
            ysc.SaveChanges();
        }
    
    }
}
