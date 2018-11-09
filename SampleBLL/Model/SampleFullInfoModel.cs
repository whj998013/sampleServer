using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SampleBLL.Model
{
    [DataContract]
    public class MaterialItemModel
    {
        ///<summary>
        /// 羊绒
        /// </summary>
        [DataMember(Name = "materials")]
        public string Materials { get; set; }

        [DataMember(Name = "enName")]
        public string EnName { get; set; }
        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "percent")]
        public int Percent { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "index")]
        public int Index { get; set; }

    }



    [DataContract]
    public class StockDataDataItemModel
    {
        ///<summary>
        /// 红色
        /// </summary>
        [DataMember(Name = "color")]
        public string Color { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "size")]
        public string Size { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "num")]
        public int Num { get; set; }

    }



    [DataContract]
    public class StyleTagItemModel
    {
        ///<summary>
        /// 基本款
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "color")]
        public string Color { get; set; }

    }



    [DataContract]
    public class PicListItemModel
    {
        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; }

    }



    [DataContract]
    public class FileListItemModel
    {
        ///<summary>
        /// 第一轮社会化服务反馈表-商泰.doc
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        ///<summary>
        /// SI10000005第一轮社会化服务反馈表-商泰.doc
        /// </summary>
        [DataMember(Name = "reallyName")]
        public string ReallyName { get; set; }

        ///<summary>
        /// /uploadfile/SI10000005第一轮社会化服务反馈表-商泰.doc
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "status")]
        public string Status { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "percentage")]
        public int Percentage { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "uid")]
        public long Uid { get; set; }

    }



    [DataContract]
    public class SampleFullInfoModel
    {
        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "styleId")]
        public string StyleId { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "styleNo")]
        public string StyleNo { get; set; }

        ///<summary>
        /// 白色
        /// </summary>
        [DataMember(Name = "color")]
        public string Color { get; set; }

        ///<summary>
        /// 开发样
        /// </summary>
        [DataMember(Name = "kinds")]
        public string Kinds { get; set; }


        ///<summary>
        /// 成衣价
        /// </summary>
        [DataMember(Name = "price")]
        public float Price { get; set; }
        ///<summary>
        /// 尺码
        /// </summary>
        [DataMember(Name = "size")]
        public string Size { get; set; }

        ///<summary>
        /// 成份
        /// </summary>
        [DataMember(Name = "material")]
        public List<MaterialItemModel> MaterialItems { get; set; }

        ///<summary>
        /// 针型
        /// </summary>
        [DataMember(Name = "gauge")]
        public string Gauge { get; set; }


        ///<summary>
        /// 针型
        /// </summary>
        [DataMember(Name = "counts")]
        public string Counts { get; set; }
        ///<summary>
        /// 库存信息
        /// </summary>
        [DataMember(Name = "stockData")]
        public List<StockDataDataItemModel> StockDataItems { get; set; }

        ///<summary>
        /// 打样单位
        /// </summary>
        [DataMember(Name = "proofingCompany")]
        public string ProofingCompany { get; set; }

        ///<summary>
        /// 工艺员
        /// </summary>
        [DataMember(Name = "technologyPeople")]
        public string TechnologyPeople { get; set; }

        ///<summary>
        /// 程序员
        /// </summary>
        [DataMember(Name = "progamPeople")]
        public string ProgamPeople { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "proofingDate")]
        public string ProofingDate { get; set; }

        ///<summary>
        /// 客户
        /// </summary>
        [DataMember(Name = "clientName")]
        public string ClientName { get; set; }

        ///<summary>
        /// 大货工厂
        /// </summary>
        [DataMember(Name = "productFactory")]
        public string ProductFactory { get; set; }

        ///<summary>
        /// 出货数量
        /// </summary>
        [DataMember(Name = "productNum")]
        public int ProductNum { get; set; }

        ///<summary>
        /// 出货日期
        /// </summary>
        [DataMember(Name = "productDate")]
        public string ProductDate { get; set; }

        ///<summary>
        /// 克重
        /// </summary>
        [DataMember(Name = "weight")]
        public int Weight { get; set; }

        ///<summary>
        /// 可否外借
        /// </summary>
        [DataMember(Name = "canLendOut")]
        public bool CanLendOut { get; set; }

        ///<summary>
        /// 是否有库存
        /// </summary>
        [DataMember(Name = "haveStock")]
        public bool HaveStock { get; set; }

        ///<summary>
        /// 
        /// </summary>
        [DataMember(Name = "styleTag")]
        public List<StyleTagItemModel> StyleTagItems { get; set; }

        ///<summary>
        /// 样衣图片清单
        /// </summary>
        [DataMember(Name = "picList")]
        public List<PicListItemModel> PicListItems { get; set; }

        ///<summary>
        /// 附件清单
        /// </summary>
        [DataMember(Name = "fileList")]
        public List<FileListItemModel> FileListItems { get; set; }

        /// <summary>
        /// 成本价
        /// </summary>
        [DataMember(Name = "costPrice")]
        public float CostPrice { get; set; }
        /// <summary>
        /// 出厂价
        /// </summary>
        [DataMember(Name = "factoryPrice")]
        public float FactoryPrice { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        [DataMember(Name = "salePrice")]
        public float SalePrice { get; set; }

        /// <summary>
        /// 处理价
        /// </summary>
        [DataMember(Name = "discountPrice")]
        public float DiscountPrice { get; set; }

    }


   
}
