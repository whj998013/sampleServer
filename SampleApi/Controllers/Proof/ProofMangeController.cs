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

namespace SampleApi.Controllers.Proof
{
    [Author]
    public class ProofMangeController : ApiController
    {

        public IHttpActionResult GetProofPlanList()
        {
            User u = SessionManage.CurrentUser;
            ProofOrderOper poo = new ProofOrderOper(u);
            var list = poo.GetPlanProofList();

            return Ok(list);
        }

        public IHttpActionResult PoofPlan(dynamic obj)
        {

            string proofOrderId = (string)obj.proofId;
            string gy = (string)obj.gy;
            string jhrq = (string)obj.jhrq;
            DateTime? dt = jhrq == "" ? (DateTime?)null : DateTime.Parse(jhrq).AddHours(8).Date;
            if (gy == "" || proofOrderId == "") return BadRequest("请选择工艺员！");
            else
            {
                ProofTaskOper pfo = new ProofTaskOper(SessionManage.CurrentUser);
                if (gy != "")
                {

                    var re = pfo.DoProofPlan(proofOrderId, gy, "工艺", dt);
                    if (re != null)
                    {
                        new GyOper().AddOrUpdataGlCode(re);
                        pfo.SaveChanges();
                    }
                    else return BadRequest("服务器保存错误！");
                }

            }
            return Ok();
        }

        public IHttpActionResult GetClients()
        {
            var clist = new ProofClient().GetClients();


            return Ok(clist);
        }
    }
}
