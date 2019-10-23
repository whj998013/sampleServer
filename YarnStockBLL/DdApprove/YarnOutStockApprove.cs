using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.DdApi;
using SG.DdApi.Approve;
using SG.DdApi.Interface;
using StorageData;
using SunginData;
namespace YarnStockBLL
{
    public class YarnOutStockApprove : DdApprove
    {
        private IDdOper _oper { get; set; }


        public YarnOutStockApprove(IDdOper ddOper)
        {
            _oper = ddOper;
        }
        protected override void AgreeApprove(string DdApprovalCode)
        {
            var ar = GetApproveRecrod(DdApprovalCode);
            using SunginDataContext sdc = new SunginDataContext();
            var yoa = sdc.YarnOutApplies.FirstOrDefault(p => p.NO == ar.ObjId);
            yoa.Stats = SG.Model.ApplyState.通过;
            using YarnStockContext ysc = new YarnStockContext();
            ApproveOper ao = new ApproveOper(_oper);
            var re = ao.GetApprove(DdApprovalCode);
            if (re != null)
            {
                re.FormComponentValues.ForEach(p =>
                {
                    if (p.Name == "实际出库数量")
                    {
                        double rNum = double.Parse(p.Value);
                        if (rNum <= 0 || rNum > yoa.LocalNum) rNum = yoa.MinNum;
                        yoa.Num = rNum;


                    }
                    if (p.Name == "出库价")
                    {
                        double price = double.Parse(p.Value);
                        yoa.OutPrice = price;
                    }
                });
                yoa.Stats = SG.Model.ApplyState.通过;
                yoa.Amount = Math.Round(yoa.OutPrice * yoa.Num, 1);
            }

            //生成出库单
            NewYarnOutStock nyos = new NewYarnOutStock();
            nyos.AddYarnOutStock(yoa);
            sdc.SaveChanges();
        }

        protected override void RefuseApprove(string DdApprovalCode)
        {
            var ar = GetApproveRecrod(DdApprovalCode);
            using SunginDataContext sdc = new SunginDataContext();
            var yoa = sdc.YarnOutApplies.FirstOrDefault(p => p.NO == ar.ObjId);
            yoa.Stats = SG.Model.ApplyState.拒绝;
            sdc.SaveChanges();

        }

        public static ApproveItems ToApprove(SG.Model.Yarn.YarnOutApply yoa,string publicOwerId)
        {
            string ddid;
            if (yoa.YarnOwerEmpName == "李圣锦") ddid = publicOwerId;
            else ddid = yoa.YarnOwerEmpDdid;

            List<string> idlist = new List<string>();
            idlist.Add(ddid);
            ApproveItems items = new ApproveItems()
            {
                new ApproveItem() {
                       Name ="毛纱所有人",
                       Value=FastJSON.JSON.ToJSON(idlist),
                   },
                  new ApproveItem() {
                       Name ="纱名",
                       Value=yoa.ProductName
                   },
                   new ApproveItem() {
                       Name ="缸号",
                       Value=yoa.BatchNum
                   },
                    new ApproveItem() {
                       Name ="成份",
                       Value=yoa.Size
                   },
                     new ApproveItem() {
                       Name ="颜色",
                       Value=yoa.Color
                   },
                      new ApproveItem() {
                       Name ="支数",
                       Value=yoa.Count
                   },
                     new ApproveItem() {
                       Name ="查询码",
                       Value=yoa.BarCode
                   },
                     new ApproveItem() {
                       Name ="库存数",
                       Value=yoa.LocalNum.ToString()
                   },
                      new ApproveItem() {
                       Name ="入库价",
                       Value=yoa.InPrice.ToString()
                   },
                      new ApproveItem() {
                       Name ="出库价",
                       Value=yoa.InPrice.ToString()
                   },
                      new ApproveItem() {
                       Name ="申请数量",
                       Value=yoa.MinNum.ToString()
                   },
                     new ApproveItem() {
                       Name ="是否代寄快递",
                       Value=yoa.NeedSending?"是":"否"
                   },
                    new ApproveItem() {
                       Name ="收货单位",
                       Value=yoa.CusName
                   },
                      new ApproveItem() {
                       Name ="收货信息",
                       Value=yoa.ReceivingInfo
                   }
            };
            items.ApproveName = "样纱出库申请";
            items.ObjId = yoa.NO;
            return items;

        }

    }
}
