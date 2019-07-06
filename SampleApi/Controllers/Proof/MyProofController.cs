using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProofBLL;
using ProofBLL.Bll;
using SG.Model.Sys;
using SG.SessionManage;
using SG.Model.Proof;
using SG.DdApi;
using SG.DdApi.Approve;
using SunginData;
namespace SampleApi.Controllers.Proof
{

    [Author]
    public class MyProofController : ApiController
    {
        public IHttpActionResult GetMyProofs()
        {
            User u = SessionManage.CurrentUser;
            ProofOrderOper poo = new ProofOrderOper(u);
            var list = poo.GetUserProofOrderList();

            return Ok(list);
        }
        [HttpGet]
        public IHttpActionResult GetProofRecord(string id)
        {
            var tlist = new ProofRecord().GetProofRecord(id);
            return Ok(tlist);
        }
        public IHttpActionResult GetMyFinshProofs()
        {

            User u = SessionManage.CurrentUser;
            ProofOrderOper poo = new ProofOrderOper(u);
            var list = poo.GetUserFineshProofOrderList();

            return Ok(list);

        }
        /// <summary>
        /// 删除打样
        /// </summary>
        /// <param name="proof"></param>
        /// <returns></returns>
        [HttpPost]

        public IHttpActionResult DeleteProof(dynamic proof)
        {
            User u = SessionManage.CurrentUser;
            string proofOrderId = (string)proof.ProofOrderId;
            ProofOrderOper poo = new ProofOrderOper(u);
            poo.DeleteProof(proofOrderId);
            poo.SaveChange();
            return Ok();
        }
        /// <summary>
        /// 提交审批
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult SubmitProof(dynamic proof)
        {
            User u = SessionManage.CurrentUser;
            string proofOrderId = (string)proof.ProofOrderId;
            ProofOrderOper poo = new ProofOrderOper(u);
            ProofOrder po = poo.GetProof(proofOrderId);
            if (po.ProofStatus == ProofStatus.草拟 || po.ProofStatus == ProofStatus.退回)
            {
                NewApprove na = new NewApprove(DdOperator.GetDdApi())
                {
                    User = u,
                    ProcessCode = Config.GetSampleConfig().ProofProcessCode
                };
                var ApproveItems = ProofOrderApprove.ToApprove(po);
                string DdApprovalCode = na.SendApprove(ApproveItems);
                if (DdApprovalCode != "")
                {
                    poo.SetApprove(po, DdApprovalCode);
                    poo.SaveChange();
                }
            }

            return Ok(po);
        }
    }

}
