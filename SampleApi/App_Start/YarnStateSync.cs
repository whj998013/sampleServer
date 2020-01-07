using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using YarnStockBLL;
using SG.Model.Yarn;

namespace SampleApi.App_Start
{
    public class YarnStateSync
    {
        public static void BeginSync()
        {
            System.Timers.Timer timer = new System.Timers.Timer
            {
                Enabled = true,
                Interval = 60000 //执行间隔时间,单位为毫秒; 这里实际间隔为1分钟  
            };
            timer.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                MyYarn.YarnOutApplyStatsUpdate();
            };
            timer.Start();
        }
    }
}