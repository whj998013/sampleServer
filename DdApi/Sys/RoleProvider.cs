using DingTalk.Api;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;
using SG.Model.Sys;
namespace SG.DdApi.Sys
{
    public class RoleProvider
    {
        private IDdOper DbOper { get; set; }
        public RoleProvider(IDdOper oper)
        {
            DbOper = oper;
        }
        /// <summary>
        /// 取得钉钉角色组
        /// </summary>
        /// <returns></returns>
        public List<IRole> GetRoles(string groupName)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/list");
            OapiRoleListRequest request = new OapiRoleListRequest();
            OapiRoleListResponse response = client.Execute(request, DbOper.AccessToken);
            List<IRole> rList = new List<IRole>();

            if (!response.IsError)
            {
                var group = response.Result.List.SingleOrDefault(p => p.Name == groupName);
                if (group != null)
                {
                    group.Roles.ForEach(role =>
                    {
                        rList.Add(new Role
                        {
                            RoleName = role.Name,
                            RoleId = role.Id
                        });

                    });
                }
            }
            return rList;
        }



        /// <summary>
        /// 返回指定解色的所有用户,已弃用
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<OapiRoleSimplelistResponse.OpenEmpSimpleDomain> GetRoleUserList(long roleId)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/role/simplelist");
            OapiRoleSimplelistRequest request = new OapiRoleSimplelistRequest
            {
                RoleId = roleId,
                Offset = 0L,
                Size = 10L
            };
            OapiRoleSimplelistResponse response = client.Execute(request, DbOper.AccessToken);
            return response.Result.List;
        }


    }


}
