using SampleBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProofBLL;
using SG.Utilities;
using SysBLL;
using SG.SessionManage;
namespace SampleApi.Controllers.Public
{
    [Author]
    public class PublicController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetSelectList()
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
        [HttpPost]
        public IHttpActionResult ConvertRgbToLab(dynamic val)
        {
            string rgbx = (string)val.rgb;
            var rgb = ColorHelper.GetRgbColor(rgbx);
            var lab = LabRgb.RgbToLab(rgb);

            return Ok(new { l = lab[0].ToString("0.00"), a = lab[1].ToString("0.00"), b = lab[2].ToString("0.00") });
        }
        [HttpGet]
        public IHttpActionResult GetDeptPvList()
        {
            var re = new PvmOper(SessionManage.CurrentUser).GetDeptList(PvmType.PV);
            return Ok(re);
        }


    }
}
