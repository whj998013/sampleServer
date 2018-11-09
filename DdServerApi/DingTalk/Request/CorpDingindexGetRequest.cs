using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.corp.dingindex.get
    /// </summary>
    public class CorpDingindexGetRequest : BaseDingTalkRequest<DingTalk.Api.Response.CorpDingindexGetResponse>
    {
        /// <summary>
        /// 统计日期
        /// </summary>
        public string StatDates { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.corp.dingindex.get";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_TOP;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("stat_dates", this.StatDates);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("stat_dates", this.StatDates);
            RequestValidator.ValidateMaxListSize("stat_dates", this.StatDates, 5);
        }

        #endregion
    }
}
