using SG.DdApi;
using SG.Utilities;
using SysBLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SampleApi.App_Start
{
    public class DdConfig
    {
        public static void Init()
        {

            //钉钉初始化
            DdOperator ddOper = DdOperator.GetDdApi();
            ddOper.CorpId = ConfigurationManager.AppSettings["CorpId"];
            ddOper.CorpSecret = ConfigurationManager.AppSettings["CorpSecret"];
            ddOper.AgentID = ConfigurationManager.AppSettings["AgentID"];

            //生成部门
            Task.Factory.StartNew(() =>
            {
                ddOper.SetDept(new DeptOper().GetDepts());
            });
            DoHistoryCallBack(ddOper);

        }

        /// <summary>
        /// 处理历史回调
        /// </summary>
        private static void DoHistoryCallBack(IDdOper ddOper)
        {

            bool NeedRegister = true;
#if DEBUG
          //  NeedRegister = false;
#endif

            if (NeedRegister)
            {
                var dbso = DdCallBackSysOper.GetOper();
                dbso.SysPath = HttpContext.Current.Server.MapPath("~");
                Task.Run(async delegate
                {
                    await Task.Delay(5000);
                    //注册回调
                    DdCallbackOper dcb = new DdCallbackOper(ddOper);
                    dcb.CallBackUrl = Config.GetSampleConfig().CallBackUrl;
                    dcb.RegisterCallBack();

                    //处理历吏回调
                    bool hasMore = false;
                    do
                    {
                        var re = dcb.GetFailCallBack();
                        re.FailedList.ForEach(p =>
                        {
                            dynamic robj = JsonHelper.ToObj(p.BpmsInstanceChange);
                            dbso.DdCallBack(robj.bpmsCallBackData);
                        });
                        hasMore = re.HasMore;
                    } while (hasMore);

                });
            }
        }
    }
}