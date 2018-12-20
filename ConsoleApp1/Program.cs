using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Utilities;
using SampleDataOper;
using System.IO;
using SG.DdApi;
using SG.DdApi.Sys;
using DingTalk.Api;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using DingTalk;
using SG.Interface.Sys;
using SG.Model.Sys;
using SysBLL;
using EntityFramework.Extensions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // DdApi();
            DdApi();
           

        }
        public static void Test2()
        {

            SampleContext sc = new SampleContext();
            var re = sc.UserRolePermissions.Join(sc.Permissions, e => e.Key, o => o.Key, (e, o) => new { e.Key, o.Name, o.CnName }).Distinct();
            Console.WriteLine(re.ToList());
            re.ToList().ForEach(p =>
            {
                Console.WriteLine(p.Key + "  " + p.CnName + "  " + p.Name);
            });
            Console.ReadKey();
        }

        public static void DdApi()
        {
            IDdOper ddOper = DdOperator.GetDdApi();
            ddOper.CorpId = "ding99dd341fc99a25eb";
            ddOper.CorpSecret = "szdxoAP2Wp2knwzsDcsDYvd_qLAjvx0YANa1RH4hOU-O8VxENo5hYE5glb_CsQg0";
            ddOper.AgentID = "132907517";
            var re= SyncFromDd.SyncUserDept(ddOper);
            int i = 0;
            //var dept= new DeptProvider(ddOper).GetDepts();
            // var uprd = new DeptProvider(ddOper);
            re.ForEach(p =>
            {
                Console.WriteLine("姓名:"+p.UserName + "  部们：" + p.DepartName+"部们ID："+p.DeptId);
                i++;
            });
            Console.Write("运行完成,共有"+i+"名员工.");
            Console.ReadLine();

        }
    }
}
