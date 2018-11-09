using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Utilities;
using SampleDataOper;
using System.IO;
using SampleDataOper.Model;
using SG.DdApi;

using DingTalk.Api;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using DingTalk;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            SampleContext dc = new SampleContext();
            var re = dc.Users.ToList();
            re.ForEach(p =>
            {
                Console.Write(p.Id);
            });
               

            //DdOperator ddOper = DdOperator.GetDdApi();
            //ddOper.CorpId = "ding99dd341fc99a25eb";
            //ddOper.CorpSecret = "szdxoAP2Wp2knwzsDcsDYvd_qLAjvx0YANa1RH4hOU-O8VxENo5hYE5glb_CsQg0";
            //ddOper.AgentID = "132907517";

            //var response = ddOper.GetRoleUserList(338565326);
            //response.Result.List.ForEach(p =>
            //{
            //    Console.WriteLine(p.Name+"--id:"+p.Userid);


            //});

            //Console.Write(response);
            //Console.ReadKey();
        }
    }
}
