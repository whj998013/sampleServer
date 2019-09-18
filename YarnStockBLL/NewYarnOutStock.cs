using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageData;
using SG.Model.Yarn;

namespace YarnStockBLL
{
    public class NewYarnOutStock
    {
        YarnStockContext Ysc { get; set; } = new YarnStockContext();

        /// <summary>
        /// 生成出库单
        /// </summary>
        /// <param name="yoa"></param>
        public void AddYarnOutStock(YarnOutApply yoa)
        {
            var lp = Ysc.LocalProduct.FirstOrDefault(p => p.ID == yoa.YarnId);

            if (lp == null || lp.Num < yoa.Num) throw new Exception("生成出库单错误，库存不足或不存在.出库申请单号:" + yoa.NO);

            OutStorage os = new OutStorage
            {
                OrderNum = GetOrderNum(),
                OutType = 3,
                ProductType = 2,
                StorageNum = lp.StorageNum,
                CusNum = yoa.CusNum,
                CusName = yoa.CusName,
                ContractOrder = yoa.NO, //关联钉单
                Num = yoa.Num,
                SendDate = DateTime.Now,
                Status = 1,
                IsDelete = 0,
                CreateTime = DateTime.Now,
                CreateUser = GetDingDingAdmin().UserCode,
                OperateType = 1,
                UserID = yoa.ApplyEmpDdid,
                UserName = yoa.ApplyEmpName,
                DeptName = yoa.ApplyEmpName,
                Amount=yoa.Amount,
                Remark = yoa.NeedSending ? yoa.ReceivingInfo : "",
                EquipmentNum="a",
                EquipmentCode="a",
                Address = yoa.NeedSending ? yoa.ReceivingInfo : "",
            };

            OutStoDetail osd = new OutStoDetail
            {
                SnNum = GetSnNum(),
                OrderNum = os.OrderNum,
                ProductName = lp.ProductName,
                BarCode = lp.BarCode,
                ProductNum =lp.ProductNum,
                BatchNum=lp.BatchNum,
                LocalNum=lp.LocalNum,
                StorageNum=lp.StorageNum,
                Num=yoa.Num,
                IsPick=1,
                RealNum=0,
                OutPrice=yoa.OutPrice,
                Amount=yoa.Amount,
                CreateTime=DateTime.Now,
                Count=lp.Count,
                Color=lp.Color,
                Size=lp.Size,
            };
            Ysc.OutStorage.Add(os);
            Ysc.OutStoDetail.Add(osd);
            Ysc.SaveChanges();
            yoa.OrderNum = os.OrderNum;
           
        }

        public Admin GetDingDingAdmin()
        {
            var u = Ysc.Admin.FirstOrDefault(p => p.UserName == "DingDingSystem");
            if (u == null)
            {
                u = new Admin
                {
                    UserName = "DingDingSystem",
                    PassWord = "DingDingSystem",
                    RealName="钉钉系统",

                    UserCode = "DD_001",
                    CreateTime = DateTime.Now,
                    LoginCount = 0,
                    UpdateTime = DateTime.Now,
                    IsDelete = 0,
                    Status = 0,
                    ParentCode="a",
                    RoleNum = "DR_0000",
                };
                Ysc.Admin.Add(u);

            }
            Ysc.SaveChanges();
            return u;

        }
        public string GetOrderNum()
        {
            string num = Ysc.OutStorage.Select(p => p.OrderNum).Max(p => p);
            string newNum = (int.Parse(num) + 1).ToString("d6");
            return newNum;
        }
        public string GetSnNum()
        {
            string num = Ysc.OutStoDetail.Select(p => p.SnNum).Max(p => p);
            string newNum = (int.Parse(num) + 1).ToString("d6");
            return newNum;
        }
    }
}
