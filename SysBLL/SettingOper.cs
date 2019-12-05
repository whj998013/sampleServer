using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunginData;
namespace SysBLL
{
    public class SettingOper
    {
        public static string GetValue(string KeyName)
        {
            using SunginDataContext sdc = new SunginDataContext();
            var re = sdc.Settings.FirstOrDefault(p => p.KeyName == KeyName);
            if (re != null) return re.KeyValue;
            else return "";
        }
        public static void SetValue(string KeyName, string KeyValue)
        {
            using SunginDataContext sdc = new SunginDataContext();
            var re = sdc.Settings.FirstOrDefault(p => p.KeyName == KeyName);
            if (re != null)
            {
                re.KeyValue = KeyValue;

            }
            else
            {
                sdc.Settings.Add(new SG.Model.Sys.Setting { KeyName = KeyName, KeyValue = KeyValue });
            }
            sdc.SaveChanges();
        }
    }
}
