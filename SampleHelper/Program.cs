using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBLL;
using SG.DdApi;

namespace SampleHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            var ar = args.ToList();
            ar.Add("SendRemindBack");

            foreach (var p in ar)
            {
                if (p == "SendRemindBack")
                {
                    SendRemindBack();
                }
                else
                {

                }

            }
            Console.ReadKey();
        }

        public static void SendRemindBack()
        {
            IDdOper ddOper = DdOperator.GetDdApi();
            ddOper.CorpId = "ding99dd341fc99a25eb";
            ddOper.CorpSecret = "szdxoAP2Wp2knwzsDcsDYvd_qLAjvx0YANa1RH4hOU-O8VxENo5hYE5glb_CsQg0";
            ddOper.AgentID = "132907517";
            SampleReminBack srb = new SampleReminBack(ddOper);
            string str = srb.SendReminBackMsg();
            log4net.ILog sendLog = log4net.LogManager.GetLogger("sungin.Info");
            sendLog.Info(string.Format("发送样衣催还信息:\r\n" + str));
            Console.WriteLine("SendRemindBack");

        }


    }
}
