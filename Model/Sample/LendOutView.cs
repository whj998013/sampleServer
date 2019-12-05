using SG.Interface.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Sample
{
    public class LendOutView
    {
        public int Id { get; set; }
        /// <summary>
        /// 样衣ID
        /// </summary>
        public string StyleId { get; set; }
        /// <summary>
        /// 款号
        /// </summary>
        public string StyleNo { get; set; }

        /// <summary>
        /// 针型
        /// </summary>
        public string Gauge { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 尺码
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// 样衣性质 开发样， 外购，  初样， 复办， 推销样留底， 生产样， 合同样
        /// </summary>
        public string Kinds { get; set; }

        /// <summary>
        /// 原料成份
        /// 原料成份
        /// </summary>
        public string Material { get; set; }
        /// <summary>
        /// <summary>
        /// 钉钉ID
        /// </summary>
        public string DdId { get; set; }
        /// <summary>
        /// 借出人姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 借出部门
        /// </summary>
        public string UserDept { get; set; }

        /// <summary>
        /// 入库ID
        /// </summary>
        public string InDdId { get; set; }

        /// <summary>
        /// 入库人姓名
        /// </summary>
        public string InUserName { get; set; }
        /// <summary>
        /// 入库部门
        /// </summary>
        public string InUserDept { get; set; }
        /// <summary>
        /// 借出日期
        /// </summary>
        public DateTime? LendOutDate { get; set; }

        /// <summary>
        /// 借出审批单ID
        /// </summary>
        public string LendOutNo { get; set; }
        /// <summary>
        /// 还回日期
        /// </summary>
        public DateTime? ReturnDate { get; set; }
        /// <summary>
        /// 还回单Id
        /// </summary>
        public string ReturnNo { get; set; }
        /// <summary>
        /// 款式图片
        /// </summary>
        public string StylePic { get; set; }

        public LendRecordStats State { get; set; }
        /// <summary>
        /// 借出天数
        /// </summary>
        public int LendDay { get; set; }
        /// <summary>
        /// 借出用途
        /// </summary>
        public string LendPurpose { get; set; }

        public bool IsDelete { get; set; }
        /// <summary>
        /// 生成时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
    }
}
