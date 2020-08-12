using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Model.Stock
{
    /// <summary>
    /// 商品类别
    /// </summary>
    public class Category
    {
        public int Id { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Comment { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();

    }
}
