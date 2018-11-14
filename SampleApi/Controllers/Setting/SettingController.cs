using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleDataOper;
using SampleDataOper.Model;
using SG.DdApi;
using SampleBLL;

namespace SampleApi.Controllers.Setting
{
    [Author]
    public class SettingController : ApiController
    {
        public object GetSetting()
        {
            var obj = new BaseSetting
            {
               IsInputStrageNeedAlow=SampleConfig.GetSampleConfig().IsInputStrageNeedAlow,
               InStrageAlowChange= SampleConfig.GetSampleConfig().InStrageAlowChange,
               EnableLimtView= SampleConfig.GetSampleConfig().EnableLimtView,
               AllSampleCanLend= SampleConfig.GetSampleConfig().AllSampleCanLend,
            };
            return Ok(obj);
        }
        public object SaveSetting(BaseSetting obj)
        {
            try
            {
                SampleConfig.GetSampleConfig().IsInputStrageNeedAlow = obj.IsInputStrageNeedAlow;
                SampleConfig.GetSampleConfig().InStrageAlowChange = obj.InStrageAlowChange;
                SampleConfig.GetSampleConfig().EnableLimtView = obj.EnableLimtView;
                SampleConfig.GetSampleConfig().AllSampleCanLend = obj.AllSampleCanLend;
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        //从钉钉同步用户及管理员
        [HttpGet]
        public object UpUserDataByDd()
        {
            var time = DateTime.Now;
            var ddoper = DdOperator.GetDdApi();
            var adminId = SampleConfig.GetSampleConfig().SampleAdminRoleId;
            var developmentId = SampleConfig.GetSampleConfig().SampleDevelopmentRoleId;
            UserOper.ClearRoleBeforDate();

            //同步工艺人员
            var re = ddoper.GetRoleUserList(developmentId);
            re.Result.List.ForEach(p =>
            {
                if (!UserOper.SetUserRole(p.Userid, UserRoleU.打样开发))
                {
                    var ddUser = ddoper.GetUserInfoById(p.Userid);
                    UserOper.AddUser(new User
                    {
                        DdId = ddUser.Userid,
                        Name = ddUser.Name,
                        DepartName = ddoper.GetDeptName(ddUser.Department[0]),
                        Avatar = ddUser.Avatar,
                        Role = UserRoleU.打样开发,
                    });
                }
            });
            //设置钉钉样衣管理员
            re = ddoper.GetRoleUserList(adminId);
            re.Result.List.ForEach(p =>
            {
                if (!UserOper.SetUserRole(p.Userid, UserRoleU.样衣管理员))
                {
                    var ddUser = ddoper.GetUserInfoById(p.Userid);
                    UserOper.AddUser(new User
                    {
                        DdId = ddUser.Userid,
                        Name = ddUser.Name,
                        DepartName = ddoper.GetDeptName(ddUser.Department[0]),
                        Avatar = ddUser.Avatar,
                        Role = UserRoleU.样衣管理员,
                    });
                }

            });
            return Ok();
        }

    }
   
}
