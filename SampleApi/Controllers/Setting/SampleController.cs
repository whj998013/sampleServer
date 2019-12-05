using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SunginData;
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
                IsInputStrageNeedAlow = Config.GetSampleConfig().IsInputStrageNeedAlow,
                InStrageAlowChange = Config.GetSampleConfig().InStrageAlowChange,
                EnableLimtView = Config.GetSampleConfig().EnableLimtView,
                AllSampleCanLend = Config.GetSampleConfig().AllSampleCanLend,
                SampleLendOutDay=Config.GetSampleConfig().SampleLendOutDay,
                SampleRemindBackDay = Config.GetSampleConfig().SampleRemindBackDay,

            };
            return Ok(obj);
        }
        public object SaveSampleSetting(BaseSetting obj)
        {
            Config.GetSampleConfig().IsInputStrageNeedAlow = obj.IsInputStrageNeedAlow;
            Config.GetSampleConfig().InStrageAlowChange = obj.InStrageAlowChange;
            Config.GetSampleConfig().EnableLimtView = obj.EnableLimtView;
            Config.GetSampleConfig().AllSampleCanLend = obj.AllSampleCanLend;
            Config.GetSampleConfig().SampleLendOutDay = obj.SampleLendOutDay;
            Config.GetSampleConfig().SampleRemindBackDay = obj.SampleRemindBackDay;
            return Ok();


        }


    }

}
