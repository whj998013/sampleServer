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
using SunginData;
using SG.Model.Sys;
using SampleApi.Models;
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

        public IHttpActionResult GetPurpose()
        {
            var plist = DataQuery.GetAllRecords<Purpose>().Select(P => P.Name).ToList();
            return Ok(plist);

        }
        [HttpGet]
        public IHttpActionResult GetMenuItem()
        {
            var menulit = DataQuery.GetAllRecords<Permission>(p => p.Type == PermissionType.Menu || p.Type == PermissionType.Item).ToList().OrderBy(p => p.Px);
            List<MenuObj> menu = new List<MenuObj>();
            menulit.Where(p => p.Type == PermissionType.Menu).ToList().ForEach(p =>
            {
                var m = new MenuObj
                {
                    Cname = p.CnName,
                    Icon = p.Icon,
                    Key = p.Key,
                    Name = p.Name
                };
                menulit.Where(i => i.UpKey == m.Key).ToList().ForEach(i =>
                {
                    m.Items.Add(new ItmeObj
                    {
                        Cname=i.CnName,
                        Name=i.Name,
                        Key=i.Key,
                        Url=i.Url
                    });
                });
                menu.Add(m);
            });
            return Ok(menu);
        }

    }
}
