using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.DdApi.Approve;
using SG.DdApi.Interface;
using SG.DdApi;
using SunginData;
using SG.Model.Proof;

namespace ProofBLL
{
    public class ProofFileDownloadApprove : DdApprove
    {

        public static ApproveItems ToApprove(ProofStyle pf)
        {

            ApproveItems items = new ApproveItems()
            {
                   new ApproveItem() {
                       Name ="款式ID",
                       Value=pf.ProofStyleId
                   },
                   new ApproveItem() {
                       Name ="款号",
                       Value=pf.ProofStyleNo
                   },
                    new ApproveItem() {
                       Name ="工艺数量",
                       Value=pf.ProofFiles.Count(p=>p.FileType==SG.Interface.Sys.FileType.TechnologyFile&&!p.IsDelete).ToString()
                   },
                     new ApproveItem() {
                       Name ="制版数量",
                       Value=pf.ProofFiles.Count(p=>p.FileType==SG.Interface.Sys.FileType.PlatemakingFile&&!p.IsDelete).ToString()
                   }
            };
            items.ApproveName = "文件下载申请";
            items.ObjId = pf.ProofOrderId;
            return items;
        }
        

        /// <summary>
        /// 同意
        /// </summary>
        /// <param name="DdApprovalCode"></param>
        protected override void AgreeApprove(string DdApprovalCode)
        {
            string oid = GetApproveRecrod(DdApprovalCode).ObjId;
            using SunginDataContext sdc = new SunginDataContext();
            var po = sdc.ProofOrders.SingleOrDefault(p => p.ProofOrderId == oid);
            if (po == null) throw new Exception("错误的返回审批申请单号:" + oid);
            po.AlowDownloadFile = true;
            sdc.SaveChanges();

        }
        /// <summary>
        /// 不同意
        /// </summary>
        /// <param name="DdApprovalCode"></param>
        protected override void RefuseApprove(string DdApprovalCode)
        {
           
        }
    }
}
