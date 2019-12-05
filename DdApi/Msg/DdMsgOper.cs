using DingTalk.Api;
using DingTalk.Api.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DdApi.Msg
{
    public class DdMsgOper
    {

        IDdOper _ddoper;
        public DdMsgOper(IDdOper ddOper)
        {
            _ddoper = ddOper;
        }

        public void SendMsg(string userid,OapiMessageCorpconversationAsyncsendV2Request.MsgDomain msg)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/message/corpconversation/asyncsend_v2");

            OapiMessageCorpconversationAsyncsendV2Request request = new OapiMessageCorpconversationAsyncsendV2Request();
            //("manager2606")
            request.UseridList = userid;
            request.AgentId = 132907517;
            request.ToAllUser = false;

            //OapiMessageCorpconversationAsyncsendV2Request.MsgDomain msg = new OapiMessageCorpconversationAsyncsendV2Request.MsgDomain();
            //msg.Msgtype = "link";
            //msg.Link = new OapiMessageCorpconversationAsyncsendV2Request.LinkDomain();
            //msg.Link.MessageUrl = @"https://app.sungingroup.com:8181/lendlist";
            //msg.Link.Title = "样衣归还提醒";
            //msg.Link.Text = "你借用的款号为--SI001212--的样衣已经或接进还样日期，请及时归还。";
            //msg.Link.PicUrl = @"https://app.sungingroup.com:8180/file/src/sample/pic/minpic/SI10001638_WZ81909003.jpg";

            request.Msg_ = msg;
            var re = client.Execute(request, _ddoper.AccessToken);

        }


    }
}
