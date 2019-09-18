using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SG.SessionManage;
using StorageData;
using YarnStockBLL;
using SG.DdApi.Approve;
using SG.DdApi;
using SG.Model.Yarn;
using SunginData;
using SysBLL;

namespace SampleApi.Controllers.Yarn
{
    [Author]
    public class YarnOutStockController : ApiController
    {
        [HttpPost]
        public IHttpActionResult GetMyYarnOutApplyList(SeachObj  obj)
        {
            if (obj == null) return BadRequest();

            var exp = PredicateBuilder.True<YarnOutApply>().And(t => (t.Stats==SG.Model.ApplyState.审批中||t.Stats==SG.Model.ApplyState.通过||t.Stats==SG.Model.ApplyState.已出库));

            if (obj.Key != null && obj.Key != "")
            {
                obj.Key.Split(' ').ToList().ForEach(p =>
                {
                    exp = exp.And(e => e.SeachKey.Contains(p));
                });
            }
            else obj.Key = "";

            SeachReturnObj sr = new SeachReturnObj();
            sr.Result = new MyYarn(SessionManage.CurrentUser).GetMyOutApplyListDesc(out int count, exp.Compile(), p => p.Id, obj.PageId, obj.PageSize);
            obj.Total = count;
            sr.SeachObj = obj;
            return Ok(sr);
        }

        [HttpPost]
        public IHttpActionResult GetYarnOutApplyList(SeachObjDept obj)
        {
            if (obj == null) return BadRequest();

            var exp = PredicateBuilder.True<YarnOutApply>().And(t => true);
            if (obj.Key != null && obj.Key != "")
            {
                obj.Key.Split(' ').ToList().ForEach(p =>
                {
                    exp = exp.And(e => e.SeachKey.Contains(p));
                });
            }
            else obj.Key = "";

            //日期范围
            if (obj.BeginDate != null && obj.EndDate != null)
            {
                exp = exp.And(p => p.CreateDate >= obj.BeginDate && p.CreateDate <= obj.EndDate.Value.AddDays(1));
            }
            var user = SessionManage.CurrentUser;

            if (obj.DeptIdList.Count > 0)
            {
                //根据部门返回
                var namelist = new PvmOper(user).GetDeptNameList(obj.DeptIdList, PvmType.PV);
                exp = exp.And(e => namelist.Contains(e.ApplyDeptName));

            }
            else
            {
                //只返回个人数据
                exp = exp.And(e => e.ApplyEmpDdid == user.DdId);
            }


            SeachReturnObj sr = new SeachReturnObj();
            sr.Result = new MyYarn(SessionManage.CurrentUser).GetMyOutApplyListDesc(out int count, exp.Compile(), p => p.Id, obj.PageId, obj.PageSize);
            obj.Total = count;
            sr.SeachObj = obj;
            return Ok(sr);


        }


        /// <summary>
        /// 新的毛纱出库申请
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult NewYarnOutApply(dynamic noa)
        {
            var current = SessionManage.CurrentUser;
            string deptname = current.DepartName.Split(',')[1];
            string batchNum = noa.BatchNum;
            string cusName = noa.CusName;
            string receivingInfo = noa.ReceivingInfo;
            bool sending = noa.Sending;
            double applyNum = noa.Num;
            using (YarnStockContext ysc = new YarnStockContext())
            {
                var lp = ysc.LocalProductView.FirstOrDefault(p => p.BatchNum == batchNum);
                if (lp == null) return BadRequest("找不到在库毛纱。");
                var cus = ysc.Customer.FirstOrDefault(p => p.CusName == cusName);

                SunginDataContext sdc = new SunginDataContext();

                YarnOutApply yoa = new YarnOutApply
                {
                    NO = KeyMange.GetKey("YarnApply"),
                    ApplyDeptName = deptname,
                    ApplyEmpDdid = current.DdId,
                    ApplyEmpName = current.UserName,
                    YarnOwerDeptName = lp.DName,
                    YarnOwerEmpName = lp.UName,
                    YarnOwerEmpDdid = lp.UserId,

                    YarnId = lp.ID,
                    ProductName = lp.ProductName,
                    BatchNum = lp.BatchNum,
                    ProductNum = lp.ProductNum,
                    BarCode = lp.BarCode,
                    Count = lp.Count,
                    Color = lp.Color,
                    Size = lp.Size,
                    RGB = lp.RGB,
                    LocalNum = lp.Num,
                    InPrice = lp.InPrice,
                    MinNum = applyNum,
                    CusName = cusName,
                    CusNum = cus == null ? "" : cus.CusNum,
                    NeedSending = sending,
                    ReceivingInfo = receivingInfo,
                    Stats = SG.Model.ApplyState.审批中,
                    
                };
                yoa.SeachKey = yoa.NO +"_" +yoa.ApplyEmpName + "_" + yoa.ProductName + "_" + yoa.BatchNum + "_" + yoa.Color + "_"+yoa.Size;
                yoa.SetCreateUser(current.UserName);
                //发送申请
                var approve = YarnOutStockApprove.ToApprove(yoa);
                NewApprove na = new NewApprove(DdOperator.GetDdApi())
                {
                    User = current,
                    ProcessCode = Config.GetSampleConfig().ApplyYarnOutStockProcessCode
                };
                string re = YarnOutStockApprove.SendApprove(na, approve);
                if (re != "")
                {
                    sdc.YarnOutApplies.Add(yoa);
                    sdc.SaveChanges();
                }

                return Ok();
            }

        }
    }
}
