using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunginData;
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
using SG.DdApi.Approve;
using HttpHelper = SG.Utilities.HttpHelper;
using log4net;
using System.Configuration;
using SG.Model;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            PvmDeptOper pdo = PvmDeptOper.GetPvmDeptOper();
        

            var re = pdo.GetDeptList(new List<long> { 1}).First();

            var re2 = re.Clone();
            re2.Items.Clear();
            Console.Write(re);


            Console.ReadKey();

        }
        static void MainYarnStock(string[] args)
        {
            YarnStockContext ysc = new YarnStockContext();
            var inlist = ysc.InStorDetail.GroupBy(p => p.BatchNum).Where(p => p.Count() > 1).ToList();
            inlist.ForEach(p =>
            {
                var l = ysc.InStorDetail.Where(b => b.BatchNum == p.Key).ToList();
                int i = 1;
                l.ForEach(c =>
                {
                    string newnum = c.BatchNum + "_" + i;
                    c.BatchNum = newnum;
                    Console.WriteLine("更改InStorDetail的ID为{0}的bathcnum为{1}", c.ID, c.BatchNum);
                    var lp = ysc.LocalProduct.Where(lpc => lpc.BatchNum == p.Key && lpc.RGB == c.RGB && lpc.Cl == c.Cl).SingleOrDefault();
                    if (lp != null)
                    {
                        lp.BatchNum = newnum;
                        Console.WriteLine("更改LocalProduct的ID为{0}的bathcnum为{1}", lp.ID, lp.BatchNum);

                    }



                    var op = ysc.OutStoDetail.Where(osd => osd.BatchNum == p.Key && osd.Color == c.Color && osd.Count == c.Count).SingleOrDefault();
                    if (op != null)
                    {
                        op.BatchNum = newnum;
                        Console.WriteLine("OutStoDetail的{0}的bathcnum为{1}", op.ID, op.BatchNum);
                    }
                    Console.WriteLine("——————————————————————————————————");
                    i++;
                });


            });

            ysc.SaveChanges();



            Console.ReadKey();

        }

        static void Main4(string[] args)
        {
            SunginDataContext sdc = new SunginDataContext();
            var fl = sdc.StyleFiles.ToList();
            fl.ForEach(p =>
            {
                Console.WriteLine(p.FileName.Substring(0, 10));
                p.StyleId = p.FileName.Substring(0, 10);


            });
            sdc.SaveChanges();
            Console.ReadKey();
        }
        static void Main2(string[] args)
        {
            IDdOper ddOper = DdOperator.GetDdApi();
            ddOper.CorpId = "ding99dd341fc99a25eb";
            ddOper.CorpSecret = "szdxoAP2Wp2knwzsDcsDYvd_qLAjvx0YANa1RH4hOU-O8VxENo5hYE5glb_CsQg0";
            ddOper.AgentID = "132907517";

            ApproveOper ao = new ApproveOper(ddOper);
            var re = ao.GetApprove("7b8ec3ef-f5c3-4ec8-8482-4e7210f7db50");
            re.FormComponentValues.ForEach(p =>
            {
                if (p.Name == "评分")
                {
                    int Rating = 3;
                    if (p.Value != null)
                    {
                        if (p.Value.IndexOf('1') > 0) Rating = 1;
                        else if (p.Value.IndexOf('2') > 0) Rating = 2;
                        else if (p.Value.IndexOf('3') > 0) Rating = 3;
                        else if (p.Value.IndexOf('4') > 0) Rating = 4;
                        else if (p.Value.IndexOf('5') > 0) Rating = 5;
                    };
                    int i = Rating;
                }

                if (p.Name == "样衣图片")
                {
                    var list = JsonHelper.JsonToList<string>(p.Value);
                    var url = list[0];
                    string name = url.Substring(url.LastIndexOf('/') + 1);

                    var f = HttpHelper.DownloadData(list[0]);


                    File.WriteAllBytes("d:\\p1.jpg", f);
                    Console.Write("down finsh");

                }

            });
            Console.Write("ok");



        }
        public static void CrLabToRgb()
        {
            YarnStockContext sdc = new YarnStockContext();
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
            YarnStockContext sdc = new YarnStockContext();
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
