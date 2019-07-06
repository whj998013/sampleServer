using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunginData;
namespace SysBLL
{
    public class KeyMange
    {
        public static string GetKey(string keyName)
        {
            string k = "";
            using (SunginDataContext sc = new SunginDataContext())
            {
                var key = sc.KMs.Where(p => p.KeyName == keyName).SingleOrDefault();
                if (key != null)
                {
                    key.KeyValue++;
                    k = key.BeginKey + key.KeyValue.ToString();
                    sc.SaveChanges();
                }
            }
            return k;

        }

      
    }
}
