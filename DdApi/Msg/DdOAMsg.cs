using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.DdApi.OAMsg;
namespace SG.DdApi
{
    public class DdOAMsg:DdMsg 
    {
        public DdOAMsg()
        {
            base.msgtype = "oa";
            oa = new DdOAmsgContent();
        }
        public DdOAmsgContent oa { get; set; }

        public void Add(string key,string value)
        {
            OaMsgKey newKey = new OAMsg.OaMsgKey
            {
                key = key,
                value = value
            };
            this.oa.body.form.Add(newKey);
        }
    }

   
    
}


namespace SG.DdApi.OAMsg
{
    public class DdOAmsgContent
    {
        public DdOAmsgContent()
        {
            head = new OaMsgHead();
            body = new OaMsgBody();
          
        }
        public string message_url { get; set; }
        public string pc_message_url { get; set; }
        public OaMsgHead head { get; set; }

        public OaMsgBody body { get; set; }

        

    }
    public class OaMsgBody
    {
        public OaMsgBody() {
            form = new List<OaMsgKey>();
            rich = new OaMsgRich();
        }

        public string title { get; set; }
        public List<OaMsgKey> form { get; set; }
        public OaMsgRich rich { get; set; }

        public string content { get; set; }

        public string image { get; set; }

        public string file_count { get; set; }

        public string author { get; set; }
    }

   public class OaMsgHead
    {
        public string bgcolor { get; set; }
        public string text { get; set; }
    }

    public class OaMsgRich
    {
        public string num { get; set; }
        public string unit { get; set; }
    }

    public class OaMsgKey
    {
        public OaMsgKey(string _key,string _value)
        {
            key = _key;
            value = _value;
        }
        public OaMsgKey()
        {

        }
        public string key { get; set; }
        public string value { get; set; }
    }

}
