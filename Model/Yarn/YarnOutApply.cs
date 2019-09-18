using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Yarn
{
    /// <summary>
    /// 毛纱出库申请
    /// </summary>
    public class YarnOutApply : BaseModel
    {
        public int Id { get; set; }
        public string NO { get; set; }
        public string ApplyEmpName { get; set; }
        public string ApplyEmpDdid { get; set; }
        public string ApplyDeptName { get; set; }
        public string YarnOwerEmpName { get; set; }
        public string YarnOwerEmpDdid { get; set; }
        public string YarnOwerDeptName { get; set; }

        /// <summary>
        /// 毛纱库存ID
        /// </summary>
        public int YarnId { get; set; }
        /// <summary>
        /// 品名
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 缸号
        /// </summary>
        public string BatchNum { get; set; }
        /// <summary>
        /// 产品码
        /// </summary>
        public string ProductNum { get; set; }

        /// <summary>
        /// 查询码
        /// </summary>
        public string BarCode { get; set; }
        /// <summary>
        /// 支数
        /// </summary>
        public string Count { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 成份
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string RGB { get; set; }

        /// <summary>
        /// 库存数
        /// </summary>
        public double LocalNum { get; set; }

        /// <summary>
        /// 申请最小出库数
        /// </summary>
        public double MinNum { get; set; }

        /// <summary>
        /// 申请最高出库数
        /// </summary>
        public double MaxNum { get; set; }

        /// <summary>
        /// 实际出库数
        /// </summary>
        public double Num { get; set; }

        /// <summary>
        /// 申请状态
        /// </summary>
        public ApplyState Stats { get; set; }

        /// <summary>
        /// 收货单位
        /// </summary>
        public string CusName { get; set; }
        /// <summary>
        /// 收货单位编号
        /// </summary>
        public string CusNum { get; set; }
        /// <summary>
        /// 出库编号
        /// </summary>
        public string OrderNum { get; set; }

        /// <summary>
        /// 是否需发快递 
        /// </summary>
        public bool NeedSending { get; set; }
        /// <summary>
        /// 收货方信息
        /// </summary>
        public string ReceivingInfo { get; set; }
        /// <summary>
        /// 进货价
        /// </summary>
        public double InPrice { get; set; }
        /// <summary>
        /// 出库价
        /// </summary>
        public double OutPrice { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// 搜索关键词
        /// </summary>
        public string  SeachKey { get; set; }

        public DateTime? ApplyDate
        {
            get
            {
                return CreateDate;
            }
        }
    }



}
