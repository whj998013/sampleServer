using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SysBLL
{

    /// <summary>
    /// 系统配置项
    /// </summary>
    public class Config
    {

        private readonly string _ProofFilePath;
        private bool _IsInputStrageNeedAlow;
        private bool _InStrageAlowChange;
        private bool _EnableLimtView;
        private bool _AllSampleCanLend;
        private long _SampleAdminRoleId;
        private long _SampleDevelopmentRoleId;
        private readonly string _SampleFilePath;
        private readonly string _PublicOwerId;
        private readonly string _FinshProofProcessCode;
        private readonly string _ProofProcessCode;
        private readonly string _CallBackUrl;
        private readonly string _ApplyDownloadProcessCode;
        private readonly string _ApplyYarnOutStockProcessCode;
        private  int _SampleLendOutDay;
        private  int _SampleRemindBackDay;

        private static Config _instance = null; //单列对象
        public static Config GetSampleConfig()
        {
            if (_instance == null) _instance = new Config();
            return _instance;
        }
        private Config()
        {
            _IsInputStrageNeedAlow = SettingOper.GetValue("IsInputStrageNeedAlow") == "true" ? true : false;
            _InStrageAlowChange = SettingOper.GetValue("InStrageAlowChange") == "true" ? true : false;
            _EnableLimtView = SettingOper.GetValue("EnableLimtView") == "true" ? true : false;
            _AllSampleCanLend = SettingOper.GetValue("AllSampleCanLend") == "true" ? true : false;
            _SampleFilePath = SettingOper.GetValue("SampleFilePath");
            _SampleAdminRoleId = long.Parse(SettingOper.GetValue("SampleAdminRoleId"));
            _SampleDevelopmentRoleId = long.Parse(SettingOper.GetValue("SampleDevelopmentRoleId"));
            _ProofFilePath = SettingOper.GetValue("ProofFilePath");
            _ProofProcessCode = SettingOper.GetValue("ProofProcessCode");
            _FinshProofProcessCode = SettingOper.GetValue("FinshProofProcessCode");
            _CallBackUrl = SettingOper.GetValue("CallBackUrl");
            _ApplyDownloadProcessCode = SettingOper.GetValue("ApplyDownloadProcessCode");
            _ApplyYarnOutStockProcessCode = SettingOper.GetValue("ApplyYarnOutStockProcessCode");
            _PublicOwerId = SettingOper.GetValue("PublicOwerId");
            _SampleLendOutDay = int.Parse(SettingOper.GetValue("SampleLendOutDay"));
            _SampleRemindBackDay = int.Parse(SettingOper.GetValue("SampleRemindBackDay"));


        }

        public string CorpId
        {
            get
            {
                return SettingOper.GetValue("CorpId");
            }
        }

        public string AgentID
        {
            get
            {
                return SettingOper.GetValue("AgentID");
            }
        }

        public string CorpSecret
        {
            get
            {
                return SettingOper.GetValue("CorpSecret");
            }
        }

        public string PublicOwerId
        {
            get
            {
                return _PublicOwerId;
            }
        }
        public string ApplyYarnOutStockProcessCode
        {
            get
            {
                return _ApplyYarnOutStockProcessCode;
            }
        }

        public string ProofProcessCode
        {
            get
            {
                return _ProofProcessCode;
            }
        }
        public string CallBackUrl
        {
            get
            {
                return _CallBackUrl;
            }
        }
        public string FinshProofProcessCode
        {
            get
            {
                return _FinshProofProcessCode;
            }
        }

        public string ApplyDownloadProcessCode
        {
            get
            {
                return _ApplyDownloadProcessCode;
            }
        }
        public string ProofFilePath
        {
            get
            {
                return _ProofFilePath;
            }
        }
        public string SampleFilePath
        {
            get
            {
                return _SampleFilePath;
            }
        }
        /// <summary>
        /// 最大借用天数
        /// </summary>
        public int SampleLendOutDay
        {
            get
                {
                return _SampleLendOutDay;
            }
            set
            {
                _SampleLendOutDay = value;
                SettingOper.SetValue("SampleLendOutDay", value.ToString());
            }

        }
        /// <summary>
        /// 自动催还天数
        /// </summary>
        public int SampleRemindBackDay
        {
            get
            {
                return _SampleRemindBackDay;
            }
            set
            {
                _SampleRemindBackDay = value;
                SettingOper.SetValue("SampleRemindBackDay", value.ToString());
            }
        }

        /// <summary>
        /// 管理员角色ID
        /// </summary>
        public long SampleAdminRoleId
        {
            get
            {
                return _SampleAdminRoleId;
            }
            set
            {
                _SampleAdminRoleId = value;
                SettingOper.SetValue("SampleAdminRoleId", value.ToString());

            }
        }
        /// <summary>
        /// 工艺开发人员角色ID
        /// </summary>
        public long SampleDevelopmentRoleId
        {
            get
            {
                return _SampleDevelopmentRoleId;
            }
            set
            {
                _SampleDevelopmentRoleId = value;
                SettingOper.SetValue("SampleDevelopmentRoleId", value.ToString());
            }
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
                if (value) SettingOper.SetValue("IsInputStrageNeedAlow", "true");
                else SettingOper.SetValue("IsInputStrageNeedAlow", "false");
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
                if (value) SettingOper.SetValue("InStrageAlowChange", "true");
                else SettingOper.SetValue("InStrageAlowChange", "false");
            }
        }
        /// <summary>
        /// 启用受限视图sss
        /// </summary>
        public bool EnableLimtView
        {
            get
            {
                return _EnableLimtView;
            }
            set
            {
                _EnableLimtView = value;
                if (value) SettingOper.SetValue("EnableLimtView", "true");
                else SettingOper.SetValue("EnableLimtView", "false");
            }
        }

        /// <summary>
        /// 允许所有样衣外借，含不可外借样衣
        /// </summary>
        public bool AllSampleCanLend
        {
            get
            {
                return _AllSampleCanLend;
            }
            set
            {
                _AllSampleCanLend = value;
                if (value) SettingOper.SetValue("AllSampleCanLend", "true");
                else SettingOper.SetValue("AllSampleCanLend", "false");
            }
        }
    }
    public class BaseSetting
    {
        public bool IsInputStrageNeedAlow { get; set; }
        public bool InStrageAlowChange { get; set; }
        public bool EnableLimtView { get; set; }
        public bool AllSampleCanLend { get; set; }

        public int SampleRemindBackDay { get; set; }

        public int SampleLendOutDay { get; set; }

    }
}
