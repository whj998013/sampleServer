using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Utilities;
namespace SampleBLL
{
    /// <summary>
    /// 系统配置项
    /// </summary>
    public class SampleConfig
    {
        private bool _IsInputStrageNeedAlow;
        private bool _InStrageAlowChange;

        private static SampleConfig _instance = null; //单列对象
        public static SampleConfig GetSampleConfig()
        {
            if (_instance == null) _instance = new SampleConfig();
            return _instance;
        }
        private SampleConfig()
        {
            _IsInputStrageNeedAlow = ConfigHelper.GetValue("IsInputStrageNeedAlow") == "true" ? true : false;
            _InStrageAlowChange = ConfigHelper.GetValue("InStrageAlowChange") == "true" ? true : false;
        }

        /// <summary>
        /// 入库无需审批，true为需要，false为不需要
        /// </summary>
        public bool IsInputStrageNeedAlow
        {
            get
            {
                return _IsInputStrageNeedAlow;
            }
            set
            {
                _IsInputStrageNeedAlow = value;
                if (value) ConfigHelper.SetValue("InputStrageNotAlow", "true");
                else ConfigHelper.SetValue("InputStrageNotAlow", "false");
            }
        }

        /// <summary>
        /// 入库人入库后人仍可修改
        /// </summary>
        public bool InStrageAlowChange
        {
            get
            {
                return _InStrageAlowChange;
            }
            set
            {
                _InStrageAlowChange = value;
                if (value) ConfigHelper.SetValue("InputStrageNotAlow", "true");
                else ConfigHelper.SetValue("InputStrageNotAlow", "false");
            }
        }

    }
}
