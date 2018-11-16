using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL.Sample;
namespace Model.Sample
{
    public class SampleBaseInfo : BaseModel, ISampleBaseInfo
    {
        public int Id { get; set; }       
        /// <summary>
        /// 款式外链ID(10000000+id).tostring()
        /// </summary>       
        public string StyleId{get; set;}
        /// <summary>
        /// 款号
        /// </summary>
        public string StyleNo { get; set; }
       
        /// <summary>
        /// 原料成份
        /// </summary>
        public string Material { get; set; }
        /// <summary>
        /// 克重
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// 针型
        /// </summary>
        public string Gauge { get; set; }
        /// <summary>
        /// 款式标签
        /// </summary>
        public string StyleTag { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 钉钉id
        /// </summary>
        public string DdId { get; set; }

        /// <summary>
        /// 尺码
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 可否外借
        /// </summary>
        public bool CanLendOut { get; set; } = true;
        /// <summary>
        /// 样衣性质 开发样， 外购，  初样， 复办， 推销样留底， 生产样， 合同样
        /// </summary>
        public string Kinds { get; set; }
        /// <summary>
        /// 入库状态
        /// </summary>
        public SampleState State { get; set; } = SampleState.草拟;
        /// <summary>
        /// 搜索字符串
        /// </summary>
        public string SeachStr { get; set; }
        /// <summary>
        /// 是否有库存
        /// </summary>
        public bool HaveStock { get; set; } = false;
        
        /// <summary>
        /// 成本价
        /// </summary>
        public float CostPrice { get; set; }
        /// <summary>
        /// 出厂价
        /// </summary>
        public float FactoryPrice { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        public float SalePrice { get; set; }

        /// <summary>
        /// 处理价
        /// </summary>
        public float DiscountPrice { get; set; }

        /// <summary>
        /// 纱线支数
        /// </summary>
        public string Counts { get; set; }

    }

 
}
