using ProofBLL;
using SG.Model.Sys;
using SG.SessionManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProofData.Bll;
using SG.DdApi;
using SG.DdApi.Approve;
using SysBLL;
using SunginData;
using SG.Model.Proof;

namespace SampleApi.Controllers.Proof
{
    [Author]
    public class ProofMangeController : ApiController
    {

        public IHttpActionResult GetProofPlanList()
        {
            User u = SessionManage.CurrentUser;
            ProofOrderOper poo = new ProofOrderOper(u);
            var po = new PvmOper(SessionManage.CurrentUser);
            var pvm = po.GetPvm("P020200", PvmType.PM);
            var exp = PredicateBuilder.True<ProofOrder>().And(p => (p.ProofStatus == ProofStatus.排单 || p.ProofStatus == ProofStatus.打样中 || p.ProofStatus == ProofStatus.交样) && !p.IsDelete);
            if (pvm != Prange.全部)
            {
                var idlist = po.GetDeptsByPermissionKey("P020200", PvmType.PM).ToDeptIdList();
                exp = exp.And(p => idlist.Contains(p.ProofDeptId));
            };
            var list = poo.GetProofListDesc(out int count,exp.Compile(),p=>p.CreateDate,1,65535);
            return Ok(list);
        }

        public IHttpActionResult GetFinshPlanList()
        {
            User u = SessionManage.CurrentUser;
            ProofOrderOper poo = new ProofOrderOper(u);
            var po = new PvmOper(SessionManage.CurrentUser);
            var pvm = po.GetPvm("P020200", PvmType.PM);
            var exp = PredicateBuilder.True<ProofOrder>().And(p => (p.ProofStatus == ProofStatus.完成) && !p.IsDelete);
            if (pvm != Prange.全部)
            {
                var idlist = po.GetDeptsByPermissionKey("P020200", PvmType.PM).ToDeptIdList();
                exp = exp.And(p => idlist.Contains(p.ProofDeptId));
            };
            var list = poo.GetProofListDesc(out int count, exp.Compile(), p => p.CreateDate, 1, 65535);
            return Ok(list);
        }
        /// <summary>
        /// 完成打样并交样
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult FinshProof(string id)
        {
            User u = SessionManage.CurrentUser;
            ProofOrderOper poo = new ProofOrderOper(u);
            var result = poo.FinshProof(id);
            if (result != null)
            {
                //发送交样申请 
                string ddid = result.ProofApplyUserDdId;
                User applyUser = SunginData.DataQuery.GetSingle<User>(p => p.DdId == ddid);
                NewApprove na = new NewApprove(DdOperator.GetDdApi())
                {
                    User = applyUser,
                    ProcessCode = Config.GetSampleConfig().FinshProofProcessCode
                };

                List<ApproveItem> items = new List<ApproveItem>()
                {
                   new ApproveItem()
                   {
                       Name ="单号",
                       Value=result.ProofOrderId
                   },
                   new ApproveItem()
                   {
                       Name ="款号",
                       Value=result.ProofStyle.ClientNo
                   },
                    new ApproveItem()
                   {
                       Name ="客户",
                       Value=result.ProofStyle.ClentName
                   },
                   new  ApproveItem{
                       Name ="打样部门",
                       Value="打样中心"
                   },
                };
                string DdApprovalCode = na.SendApprove(items);
                if (DdApprovalCode != "")
                {
                    poo.SetFinshApprove(result, DdApprovalCode);
                    poo.SaveChange();
                    return Ok();
                };
                
            }
            return BadRequest("订单号错误。");
        }


        public IHttpActionResult GetClients()
        {
            var clist = new ProofClient().GetClients();


            return Ok(clist);
        }
    }
}
