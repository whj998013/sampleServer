using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.corp.conference.details.query
    /// </summary>
    public class CorpConferenceDetailsQueryRequest : BaseDingTalkRequest<DingTalk.Api.Response.CorpConferenceDetailsQueryResponse>
    {
        /// <summary>
        /// 主叫userId
        /// </summary>
        public string CallerUserId { get; set; }

        /// <summary>
        /// 查询个数，上限100
        /// </summary>
        public Nullable<long> Limit { get; set; }

        /// <summary>
        /// 成员userId
        /// </summary>
        public string MemberUserId { get; set; }

        /// <summary>
        /// 查询起始时间
        /// </summary>
        public Nullable<DateTime> SinceTime { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.corp.conference.details.query";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_TOP;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("caller_user_id", this.CallerUserId);
            parameters.Add("limit", this.Limit);
            parameters.Add("member_user_id", this.MemberUserId);
            parameters.Add("since_time", this.SinceTime);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
        }

        #endregion
    }
}
