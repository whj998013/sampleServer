using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DdApi
{
    public class DdMsgOper
    {
        DdOperator myoper;
        string url = "https://oapi.dingtalk.com/message/send?access_token={0}";
        /// <summary>
        /// 初始化消息发送器
        /// </summary>
        /// <param name="oper">钉钉控制器</param>
        public DdMsgOper(DdOperator oper)
        {
            url = string.Format(url, oper.AccessToken);
            myoper = oper;
        }

        public void SendMsg(DdMsg msg)
        {
            msg.agentid = myoper.AgentID;                     
            string result=HttpHelper.Post(url, msg.ToJsonString());            
        }

    }
}
