using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleDataOper.Model;
using SampleDataOper;
namespace SampleBLL
{
    public class Manage
    {
        public object GetLendUserList()
        {
            using (SampleContext sc = new SampleContext())
            {



            }

            return null;
        }

        public static object GetInputserList()
        {
            using (SampleContext sc = new SampleContext())
            {

                var re = sc.SampleBaseInfos.Where(p => !p.IsDelete && p.State == SampleState.待入库).Select(p => new { p.DdId, p.CreateUser }).Distinct();
                return re;
            }

        }

    }
}
