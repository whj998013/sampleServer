using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProofBLL;
using SG.Model.Sys;
using SG.SessionManage;

namespace SampleApi.Controllers.Proof
{
    [Author]

    public class MyProofController : ApiController
    {
        public IHttpActionResult GetMyProofs()
        {
            User u = SessionManage.CurrentUser;
            var list=ProofOrderOper.GetProofOrderList(u);

            return Ok(list);
        }
        public IHttpActionResult GetMyFinshProofs()
        {

            return Ok();
        }
    }
}
