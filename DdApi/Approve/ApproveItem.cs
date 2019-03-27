using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SG.DdApi.Approve
{
    public class ApproveItem
    {
        /// <summary>
        /// 扩展值
        /// </summary>
        public string ExtValue { get; set; }
        /// <summary>
        /// 表单每一栏的名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 表单每一栏的值
        /// </summary>
        public string Value { get; set; }
    }

}
