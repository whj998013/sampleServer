using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Stock
{
    /// <summary>
    /// 仓库区域
    /// </summary>
    public class StockArea
    {
        public int Id { get; set; }
        /// <summary>
        /// 区域ID
        /// </summary>
        public string AreaId { get; set; }
        /// <summary>
        /// 区域名
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 区域说明
        /// </summary>
        public string Comment { get; set; }
    }
}
