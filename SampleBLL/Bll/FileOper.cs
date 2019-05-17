using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleDataOper;
using SG.Model.Sys;

namespace SampleBLL.Bll
{
   public class FileOper
    {
       
       public static void RebuildFileStyleId()
        {
            SunginDataContext sdc = new SunginDataContext();
            sdc.StyleFiles.ToList().ForEach(f =>
            {
                string name = f.FileName;
                string id = name.Substring(0, 10);

                f.StyleId = id;


            });
            sdc.SaveChanges();
        }
             

    }
}
