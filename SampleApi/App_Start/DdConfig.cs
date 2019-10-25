using ProofBLL;
using SG.DdApi;
using SG.Utilities;
using SysBLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YarnStockBLL;

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

            InitDdCallBack();

            //生成部门
            Task.Factory.StartNew(() =>
            {
                ddOper.SetDept(new DeptOper().GetDepts());
            });
            DoHistoryCallBack(ddOper);

        }



        /// <summary>
        /// 初始化回调组件，并注册回调插件
        /// </summary>
        public static void InitDdCallBack()
        {
            string SysPath = HttpContext.Current.Server.MapPath("~");
            string ProofProcessCode = Config.GetSampleConfig().ProofProcessCode;
            string FinshProofProcessCode = Config.GetSampleConfig().FinshProofProcessCode;
            string ApplyDownloadProcessCode = Config.GetSampleConfig().ApplyDownloadProcessCode;
            string ApplyYarnOutStockProcessCode = Config.GetSampleConfig().ApplyYarnOutStockProcessCode;
            //初始化回调组件
            var ddCallBack = DdCallBackSysOper.GetOper();
            ddCallBack.EventTypes.Add("bpms_task_change");
            ddCallBack.EventTypes.Add("bpms_instance_change");

            //钉钉样衣申请回调
            ddCallBack.AddCallBack(new ProofOrderApprove
            {
                ProcessCode = ProofProcessCode
            });


            //钉钉样衣交样回调
            ddCallBack.AddCallBack(new ProofOrderFinshApprove(DdOperator.GetDdApi())
            {
                SysPath = SysPath,
                ProcessCode = FinshProofProcessCode,
            });


            //文件下载申请回调
            ddCallBack.AddCallBack(new ProofFileDownloadApprove
            {
                ProcessCode = ApplyDownloadProcessCode
            });

            //样纱出库回调
            ddCallBack.AddCallBack(new YarnOutStockApprove(DdOperator.GetDdApi())
            {
                ProcessCode = ApplyYarnOutStockProcessCode

            });

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
                System.Threading.Tasks.Task.Run(async delegate
                {
                    await System.Threading.Tasks.Task.Delay(5000);
                    //注册回调
                    DdCallbackOper dcb = new DdCallbackOper(ddOper)
                    {
                        CallBackUrl = Config.GetSampleConfig().CallBackUrl
                    };
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