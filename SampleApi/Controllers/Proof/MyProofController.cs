using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProofBLL;
using SG.Model.Sys;
using SG.SessionManage;
using SG.Model.Proof;

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
        public IHttpActionResult GetMyFinshProofs()
        {

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
            ProofOrder po = new ProofOrderOper(u).GetProof(proofOrderId);


            return Ok();
        }
    }

}
