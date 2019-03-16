using SampleBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProofBLL;

namespace SampleApi.Controllers.Public
{
    public class PublicController : ApiController
    {
        [HttpGet]
        public object GetSelectList()
        {
            object ColorList = CodeOper.GetColorList();
            object SizeList = CodeOper.GetSizeList();
            object GaugeList = CodeOper.GetGaugeList();
            object MaterialList = CodeOper.GetMaterialList();
            object TagList = CodeOper.GetTagList();
            object KindsList = CodeOper.GetKindsList();
            object ProofTypeList = new ProofTypeOper().GetProofTypeList().Select(t => new { t.Id, t.TypeName });
            return Ok(new { ColorList, SizeList, GaugeList, MaterialList, TagList, KindsList, ProofTypeList });
        }
    }
}
