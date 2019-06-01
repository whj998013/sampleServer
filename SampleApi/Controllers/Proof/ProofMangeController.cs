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

    
        public IHttpActionResult GetClients()
        {
            var clist = new ProofClient().GetClients();


            return Ok(clist);
        }
    }
}
