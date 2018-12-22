using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SG.DdApi
{
    /// <summary>
    ///DD消息正文
    /// </summary>
    public abstract class DdMsg
    {
        public string touser { get; set; }
        public string toparty { get; set; }
        public string agentid { get; set; }
        public string msgtype { get; set; }        
        public string ToJsonString()
        {            
              return   JsonConvert.SerializeObject(this);            
        }

    }
    /// <summary>
    /// 文字消息
    /// </summary>
    public class DdTextMsg : DdMsg
    {
        public DdTextMsg()
        {
            text = new TextMsgContent();
            base.msgtype = "text";
        }
        public TextMsgContent text { get; set; }
    }

    /// <summary>
    /// 文字消息体
    /// </summary>
    public class TextMsgContent
    {
        public string content { get; set; }
    }
    /// <summary>
    /// link消息
    /// </summary>
    public class DdLinkMsg : DdMsg
    {
        public DdLinkMsg()
        {
            base.msgtype = "link";
            link = new LinkMsgContent();
        }
        public LinkMsgContent link { get; set; }
    }
    /// <summary>
    /// link消息体
    /// </summary>
    public class LinkMsgContent
    {
        public string messageUrl { get; set; }
        public string picUrl { get; set; }
        public string title { get; set; }
        public string text { get; set; }
    }
}
