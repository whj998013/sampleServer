using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sample;

namespace Model.Sample
{

    public  class Material : BaseModel, IMaterial
    {
        public int Id { get; set; }

        /// <summary>
        /// 中文名
        /// </summary>
        public string CnName { get; set; }
        /// <summary>
        /// 英文名
        /// </summary>
        public string EnName { get; set; }
        /// <summary>
        /// 使用次数
        /// </summary>
        public int UseCount { get; set; }


    }
}
