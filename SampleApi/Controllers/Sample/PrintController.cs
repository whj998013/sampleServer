using SampleBLL;
using SampleDataOper;
using SG.SessionManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SampleApi.Controllers.Sample
{
    public class PrintController : ApiController
    {

        [HttpGet]
        public object GetSample([FromUri]string styleId)
        {
            if (styleId != "")
            {
                var obj = SampleOper.GetPrintSample(styleId);
                if (obj != null)
                {
                   
                    return Ok(obj);
                }
                else return BadRequest("找到不指定ID的样衣信息");
            }
            return NotFound();
        }
    }
}
