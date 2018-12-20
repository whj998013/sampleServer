using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Stock
{
    /// <summary>
    /// 仓库
    /// </summary>
    public class Warehouse
    {
        public int Id { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        public string WarehouseId { get; set; }
        /// <summary>
        /// 仓库名字
        /// </summary>
        public string WarehouseName { get; set; }
        /// <summary>
        /// 仓库地址
        /// </summary>
        public string WarehouseAddress { get; set; }
        /// <summary>
        /// 仓库电话
        /// </summary>
        public string WarehouseTel { get; set; }
        /// <summary>
        /// 仓库说明
        /// </summary>
        public string WarehouseComments { get; set; }
        /// <summary>
        /// 仓库类别
        /// </summary>
        public WarehouseType WarehouseType { get; set; }

    }

    public enum WarehouseType
    {
        Yarn=0,
        Garment=1,
        General= 2,
    }
}
