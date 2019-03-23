using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using SG.Utilities;
using SG.Model.Proof;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            ProofStyle ps = new ProofStyle();
            ProofOrder po = new ProofOrder();
            ps.ProofStyleId = "ps1222";
            po.ProofOrderId = "po1";
            po.ProofStatus = ProofStatus.完成;
            po.ProofApplyUserName = "aaa";
            po.ProofStyle = ps;

            SunginDataContext sc = new SunginDataContext();
            //sc.ProofStyles.Add(ps);
            //sc.SaveChanges();
           // sc.ProofOrders.Add(po);
           
            //sc.SaveChanges();
            
            var po2 = sc.ProofOrders.Include("ProofStyle").SingleOrDefault();
          //  var pss = sc.ProofStyles.ToList();

            Console.WriteLine(po2.ProofStyle.ProofStyleId);
            Console.ReadKey();
           

        }

        public static void test3()
        {
            bool re = DirFileHelper.IsExistDirectory(@"//192.168.1.202/sh_erp$/ww2");
            if (re)
            {
                Console.WriteLine("在");
            }
            else
            {
                Console.WriteLine("不在");
                DirFileHelper.CreateDirectory(@"//192.168.1.202/sh_erp$/ww2");
            }
            Console.ReadKey();
        }
        public static void Test2()
        {

            SunginDataContext sc = new SunginDataContext();
            ProofOrder po = new ProofOrder();
            


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
