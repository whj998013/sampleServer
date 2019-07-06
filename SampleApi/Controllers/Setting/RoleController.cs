using SG.DdApi;
using SysBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SG.Utilities;
using SampleApi.Models;

namespace SampleApi.Controllers.Setting
{
    [Author]
    public class RoleSettingController : ApiController
    {
        //从钉钉同步用户及管理员aa
        [HttpGet]
        public object UpUserDataByDd()
        {
            var ddoper = DdOperator.GetDdApi();
            SyncFromDd.SyncUserDept(ddoper);
            SyncFromDd.SyncUserRole(ddoper);
          
            return Ok();
        }

        public IHttpActionResult GetUserRoleData()
        {
           
            var urp =new UrpOper().GetList();
            var plist = new PermissionOper().GetList();
            
            return Ok(new { urp, plist });
        }

        public IHttpActionResult SaveRoleData(SaveRolesObj obj)
        {

            if (obj != null)
            {
                new UrpOper().UrpUpData(obj.Role.RoleId, obj.PermissionKey);
                new RoleOper().UpdateRoleRange(obj.Role);
            }
            else return BadRequest("提交了错误的修改数据！");

            return Ok("更新用户权限成功！");
        }
    }
}
