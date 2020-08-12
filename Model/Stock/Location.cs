using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Stock
{
    /// <summary>
    /// 库位
    /// </summary>
    public class Location
    {
        public int Id { get; set; }
        
        /// <summary>
        ///  库位ID
        /// </summary>
        public string LocationId { get; set; }
        /// <summary>
        /// 所属区域
        /// </summary>
        public StockArea Area { get; set; } = new StockArea();
        // <summary>
        /// 所属仓库
        /// </summary>
        public Warehouse Warehouse { get; set; } = new Warehouse();
        /// <summary>
        /// 仓库名
        /// </summary>
        [NotMapped]
        public string WarehouseName { get { return Warehouse.WarehouseName; } }
        /// <summary>
        /// 区域名
        /// </summary>
        [NotMapped]
        public string AreaName { get { return Area.AreaName; } }
        /// <summary>
        /// 库位名
        /// </summary>
        public string Name { get; set; }


    }
}
