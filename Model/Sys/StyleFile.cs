using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interface.Sys;
namespace SG.Model.Sys
{
    public class StyleFile : BaseModel, IStyleFile
    {
        public int Id { get; set; }
        /// <summary>
        /// 款式ID
        /// </summary>
        public string StyleId { get; set; }
        /// <summary>
        /// 文件类型,0为样衣图片，1为文件
        /// </summary>
        public FileType FileType { get; set; }
        /// <summary>
        /// web地址
        /// </summary>
        public string FileUrl { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 原上传显示名称
        /// </summary>
        public string DisplayName { get; set; }

    }
    
    
}
