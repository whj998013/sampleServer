using System;
using System.Collections.Generic;
using System.Linq;
using SG.DdApi.Suite;
namespace SG.DdApi
{
   public class DdEncrypt
    {
        private IDdOper _oper;
        readonly string AesKey = "99801378901234567890nicky67890123wyy7890whj";
        readonly string Token = "880212";
        public DdEncrypt(IDdOper oper)
        {
            _oper = oper;
        }
        public string DecryptMsg(string sPostData, string sMsgSignature, string sTimeStamp, string sNonce)
        {
            string sMsg = "";
            DingTalkCrypt dtc = new DingTalkCrypt(Token,AesKey,_oper.CorpId);
            int re= dtc.DecryptMsg(sMsgSignature,sTimeStamp,sNonce,sPostData,ref sMsg);
            if (re == 0) return sMsg;
            return "";
          
        }

        public object EncryptMsg(string sReplyMsg)
        {
            DingTalkCrypt dtc = new DingTalkCrypt(Token, AesKey, _oper.CorpId);
            string msg_signature = "128790jkdjkhdfkaue8819823712837912837608";
            string timeStamp = _oper.TimeStamp();
            string nonce = "998013";
            string encrypt = "";
            dtc.EncryptMsg(sReplyMsg,timeStamp,nonce,ref encrypt,ref msg_signature);
            var obj = new { msg_signature, timeStamp, nonce, encrypt };
            return obj;
          
        }


    }
}
