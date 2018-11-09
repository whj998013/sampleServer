using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.chat.create
    /// </summary>
    public class OapiChatCreateRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiChatCreateResponse>
    {
        /// <summary>
        /// 群类型，2：企业群，0：普通群
        /// </summary>
        public Nullable<long> ConversationTag { get; set; }

        /// <summary>
        /// 外部联系人成员列表
        /// </summary>
        public List<string> Extidlist { get; set; }

        /// <summary>
        /// 群名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 群主的userId
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// 群主类型，emp：企业员工，ext：外部联系人
        /// </summary>
        public string OwnerType { get; set; }

        /// <summary>
        /// 新成员可查看100条聊天历史消息的类型，1：可查看，默认或0：不可查看
        /// </summary>
        public Nullable<long> ShowHistoryType { get; set; }

        /// <summary>
        /// 群成员userId列表
        /// </summary>
        public List<string> Useridlist { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.chat.create";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("conversationTag", this.ConversationTag);
            parameters.Add("extidlist", TopUtils.ObjectToJson(this.Extidlist));
            parameters.Add("name", this.Name);
            parameters.Add("owner", this.Owner);
            parameters.Add("ownerType", this.OwnerType);
            parameters.Add("showHistoryType", this.ShowHistoryType);
            parameters.Add("useridlist", TopUtils.ObjectToJson(this.Useridlist));
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateMaxListSize("extidlist", this.Extidlist, 20);
            RequestValidator.ValidateMaxListSize("useridlist", this.Useridlist, 20);
        }

        #endregion
    }
}
