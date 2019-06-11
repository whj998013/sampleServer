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
using System.Web.Security;
using System.Security.Cryptography;
using SampleBLL.Bll;
using StorageData;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StorageDataContext sdc = new StorageDataContext();
            var l = sdc.Color.ToList();
            l.ForEach(p =>
            {
                Console.WriteLine("开始转化,颜色:" + p.Name + "  RGB:" + p.RGB);
                string c = p.Name.Substring(p.Name.Length - 1, 1);
                if (c != "色") p.Name += "色";
                

            });
            sdc.SaveChanges();
            Console.WriteLine("全部转换完成。");

            Console.ReadKey();

        }

        public static void BuildColorLab()
        {
            StorageDataContext sdc = new StorageDataContext();
            var l = sdc.Color.ToList();
            l.ForEach(p =>
            {
                Console.WriteLine("开始转化,颜色:" + p.Name + "  RGB:" + p.RGB);
                int r = System.Convert.ToInt32(p.RGB.Substring(1, 2), 16);
                int b = System.Convert.ToInt32(p.RGB.Substring(3, 2), 16);
                int g = System.Convert.ToInt32(p.RGB.Substring(5, 2), 16);
                var lab = LabRgb.RgbToLab(new int[] { r, b, g });
                p.Lab_L = lab[0];
                p.Lab_a = lab[1];
                p.Lab_b = lab[2];

            });
            sdc.SaveChanges();
            Console.WriteLine("全部转换完成。");

            Console.ReadKey();

        }
        public static string GetSwcSH1(string value)
        {
            SHA1 algorithm = SHA1.Create();
            byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
            string sh1 = "";
            for (int i = 0; i < data.Length; i++)
            {
                sh1 += data[i].ToString("x2").ToUpperInvariant();
            }
            return sh1;
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
