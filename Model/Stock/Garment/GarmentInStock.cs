using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Stock
{
    public class GarmentInStock
    {
        public int Id { get; set; }
        /// <summary>
        /// 入库ID
        /// </summary>
        public string InStockId { get; set; }
        /// <summary>
        /// 库存ID
        /// </summary>
        public string StockId { get; set; }
        /// <summary>
        /// 款式ID
        /// </summary>
        public string StyleId { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public string GoodsId { get; set; }
        /// <summary>
        /// 尺码
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 入库价
        /// </summary>
        public double InStockPrice { get; set; }
        /// <summary>
        /// 商品信息
        /// </summary>
        public Garment Garment { get; set; }
        /// <summary>
        /// 入库仓库
        /// </summary>
        public Warehouse Warehouse { get; set; }
        /// <summary>
        /// 库位
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 搜索关键词
        /// </summary>
        public string SeachKey { get; set; }
        /// <summary>
        /// 入库员工姓名
        /// </summary>
        public string InStockStaffName { get; set; }
        /// <summary>
        /// 入库员工部部门
        /// </summary>
        public string InStockStaffDept { get; set; }
        /// <summary>
        /// 入库员工
        /// </summary>
        public Sys.User InStockStaff { get; set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime InStockDate { get; set; }

    }
}
