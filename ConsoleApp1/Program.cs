using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Utilities;
using SampleDataOper;
using System.IO;
using SG.DdApi;
using DingTalk.Api;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using DingTalk;
using IBLL.Sys;
using Model.Sys;
using SysBLL;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var re=DataQuery.GetRecords<Role>(a => a.Id > 0);
            re.ForEach(p =>
            {
                Console.WriteLine(p.Name);
            });
          
            Console.ReadKey();
          
        }

        public void DdApi()
        {
            IDdOper ddOper = DdOperator.GetDdApi();
            ddOper.CorpId = "ding99dd341fc99a25eb";
            ddOper.CorpSecret = "szdxoAP2Wp2knwzsDcsDYvd_qLAjvx0YANa1RH4hOU-O8VxENo5hYE5glb_CsQg0";
            ddOper.AgentID = "132907517";
            RoleOper nr = new RoleOper(ddOper);
            nr.SyncUserRoleFromDd();
            Console.Write("运行完成");
            Console.ReadLine();

        }
    }
}
