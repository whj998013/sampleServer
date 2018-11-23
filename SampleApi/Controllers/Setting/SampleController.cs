using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleDataOper;
using SG.DdApi;
using SG.DdApi.Sys;
using SampleBLL;
using SG.Interface.Sys;
using SG.Model.Sys;
using SysBLL;

namespace SampleApi.Controllers.Setting
{
    [Author]
    public class SampleSettingController : ApiController
    {
        public object GetSampleSetting()
        {
            var obj = new BaseSetting
            {
               IsInputStrageNeedAlow=SampleConfig.GetSampleConfig().IsInputStrageNeedAlow,
               InStrageAlowChange= SampleConfig.GetSampleConfig().InStrageAlowChange,
               EnableLimtView= SampleConfig.GetSampleConfig().EnableLimtView,
               AllSampleCanLend= SampleConfig.GetSampleConfig().AllSampleCanLend,
            };
            return Ok(obj);
        }
        public object SaveSampleSetting(BaseSetting obj)
        {
            try
            {
                SampleConfig.GetSampleConfig().IsInputStrageNeedAlow = obj.IsInputStrageNeedAlow;
                SampleConfig.GetSampleConfig().InStrageAlowChange = obj.InStrageAlowChange;
                SampleConfig.GetSampleConfig().EnableLimtView = obj.EnableLimtView;
                SampleConfig.GetSampleConfig().AllSampleCanLend = obj.AllSampleCanLend;
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    

    }
   
}
