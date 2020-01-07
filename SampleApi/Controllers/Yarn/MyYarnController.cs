using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SunginData;
using SG.Model.Sys;
using SG.SessionManage;
using StorageData;
using YarnStockBLL;
using SysBLL;

namespace SampleApi.Controllers.Yarn
{
    [Author]
    public class MyYarnController : ApiController
    {

        [HttpPost]
        public IHttpActionResult GetMyYarnInStock(SeachObjDept obj)
        {
            if (obj == null) return BadRequest();

            var exp = PredicateBuilder.True<InOrderView>().And(t => t.Num > 0);
            if (obj.Key != null && obj.Key != "")
            {
                obj.Key.Split(' ').ToList().ForEach(p =>
                {
                    exp = exp.And(e => e.SeachKey.Contains(p));
                });
            }
            else obj.Key = "";

            //日期范围
            if(obj.BeginDate!=null && obj.EndDate != null)
            {
                exp = exp.And(e => e.CreateTime >= obj.BeginDate && e.CreateTime <= obj.EndDate.Value.AddDays(1));
            }
            
            var user = SessionManage.CurrentUser;
            if (obj.DeptIdList.Count > 0)
            {
                //根据部门返回
                var namelist = new PvmOper(user).GetDeptNameList(obj.DeptIdList, PvmType.PV);
                exp = exp.And(e => namelist.Contains(e.DeptName));

            }
            else
            {
                //只返回个人数据
                exp = exp.And(e => e.UserID == user.DdId);

            }


            SeachReturnObj sr = new SeachReturnObj
            {
                Result = new MyYarn(SessionManage.CurrentUser).GetMyInStockYarnListDesc(out int count, exp.Compile(), p => p.CreateTime, obj.PageId, obj.PageSize)
            };
            obj.Total = count;
            sr.SeachObj = obj;
            return Ok(sr);
        }
        [HttpPost]
        public IHttpActionResult GetMyYarnOutStock(SeachObjDept obj)
        {
            if (obj == null) return BadRequest();
            var exp = PredicateBuilder.True<OutStorageView>().And(t => t.Num > 0&&t.Status==2);
            var user = SessionManage.CurrentUser;
            if (obj.DeptIdList.Count > 0)
            {
                //根据部门返回
                var namelist = new PvmOper(user).GetDeptNameList(obj.DeptIdList, PvmType.PV);
                exp = exp.And(e => namelist.Contains(e.OutDName));

            }
            else
            {
                //只返回个人数据
                exp = exp.And(e => e.OutUid == user.DdId);
            }
            //日期范围
            if (obj.BeginDate != null && obj.EndDate != null)
            {
                exp = exp.And(e => e.CreateTime >= obj.BeginDate && e.CreateTime <= obj.EndDate.Value.AddDays(1));
            }

            SeachReturnObj sr = new SeachReturnObj
            {
                Result = new MyYarn(SessionManage.CurrentUser).GetMyOutStockYarnListDesc(out int count, exp.Compile(), p => p.CreateTime, obj.PageId, obj.PageSize)
            };
            obj.Total = count;
            sr.SeachObj = obj;
            return Ok(sr);

        }
        
    }
}
