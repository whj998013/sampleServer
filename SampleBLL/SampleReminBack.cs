using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunginData;
using SG.Model.Sys;
using SG.DdApi.Msg;
using SysBLL;
using SG.Model.Sample;
using SG.DdApi;
using DingTalk.Api.Request;

namespace SampleBLL
{
    public class SampleReminBack
    {
        IDdOper _ddoper;

        public SampleReminBack(IDdOper ddOper)
        {
            _ddoper = ddOper;
        }
        /// <summary>
        /// 发送样衣催提醒
        /// </summary>
        public string SendReminBackMsg()
        {
            string logstr = "";
            using SunginDataContext sdc = new SunginDataContext();
            int ReminDay = Config.GetSampleConfig().SampleRemindBackDay;
            var ddMsgOper = new DdMsgOper(_ddoper);
            var list = sdc.LendOutViews.Where(p => !p.IsDelete && p.State == SG.Interface.Sample.LendRecordStats.已借出).ToList();
            var DdHost = sdc.Settings.FirstOrDefault(p => p.KeyName == "DdHost").KeyValue;
            var DdServerHost = sdc.Settings.FirstOrDefault(p => p.KeyName == "DdServerHost").KeyValue;

            list.ForEach(p =>
            {
                var ld = (DateTime.Now - p.LendOutDate).Value.Days;
                if (ld >= p.LendDay + ReminDay)
                {
                    //超期

                    OapiMessageCorpconversationAsyncsendV2Request.MsgDomain msg = new OapiMessageCorpconversationAsyncsendV2Request.MsgDomain();
                    msg.Msgtype = "link";
                    msg.Link = new OapiMessageCorpconversationAsyncsendV2Request.LinkDomain();
                    msg.Link.MessageUrl = string.Format(@"{0}/lendlist", DdHost);
                    msg.Link.Title = "样衣归还提醒";
                    string id = p.DdId;
#if DEBUG
                    id = "manager2606";
#endif
                    if (ld <= p.LendDay)
                    {
                        msg.Link.Text = string.Format("您借用的样衣{0}还有{1}天到归还日，请及时归还。(请在手机中查看)", p.StyleId, p.LendDay - ld);
                    }
                    else
                    {

                        msg.Link.Text = string.Format("您借用的样衣{0}已超期{1}天，请及时归还。(请在手机中查看)", p.StyleId, ld - p.LendDay);
                    }

                    msg.Link.PicUrl = string.Format(@"{0}/src/sample/pic/minpic/{1}", DdServerHost, p.StylePic);
                    ddMsgOper.SendMsg(id, msg);
                    logstr += "接收人:" + p.UserName + " 信息:" + msg.Link.Text + "\r\n";

                }

            });

            return logstr;
        }
    }
}
