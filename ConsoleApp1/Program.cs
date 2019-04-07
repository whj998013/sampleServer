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
using System.Data.Entity;
using ProofData.Bll;
using ProofData;
using ProofBLL;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                SunginDataContext sdc = new SunginDataContext();
                ProofOrder po = sdc.ProofOrders.Include(t => t.ProofStyle).Include(t => t.ProofStyle.ProofFiles).Include(t => t.ProofStyle.ProofType).Where(p => p.ProofOrderId == "PS10000140").SingleOrDefault();

                YdOper yo = new YdOper();
                string re = yo.AddYd(po);

            }
            catch (Exception e)
            {

                Console.ReadKey();
            }





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

            var dck = new DdCallbackOper(ddOper);
            //var dre = dck.DeleteRegister();
            //var regre = dck.SendRegister();
            var re = dck.GetRegister();




            Console.ReadLine();

        }
    }
}
