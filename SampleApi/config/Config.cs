﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Utilities;
namespace SampleApi
{

    /// <summary>
    /// 系统配置项
    /// </summary>
    public class Config
    {

        private string _ProofFilePath;
        private bool _IsInputStrageNeedAlow;
        private bool _InStrageAlowChange;
        private bool _EnableLimtView;
        private bool _AllSampleCanLend;
        private long _SampleAdminRoleId;
        private long _SampleDevelopmentRoleId;
        private string _SampleFilePath;
        private string _FinshProofProcessCode;
        private string _ProofProcessCode;
        private string _CallBackUrl;
        private static Config _instance = null; //单列对象
        public static Config GetSampleConfig()
        {
            if (_instance == null) _instance = new Config();
            return _instance;
        }
        private Config()
        {
            _IsInputStrageNeedAlow = ConfigHelper.GetValue("IsInputStrageNeedAlow") == "true" ? true : false;
            _InStrageAlowChange = ConfigHelper.GetValue("InStrageAlowChange") == "true" ? true : false;
            _EnableLimtView = ConfigHelper.GetValue("EnableLimtView") == "true" ? true : false;
            _AllSampleCanLend = ConfigHelper.GetValue("AllSampleCanLend") == "true" ? true : false;
            _SampleFilePath = ConfigHelper.GetValue("SampleFilePath");
            _SampleAdminRoleId = long.Parse(ConfigHelper.GetValue("SampleAdminRoleId"));
            _SampleDevelopmentRoleId = long.Parse(ConfigHelper.GetValue("SampleDevelopmentRoleId"));
            _ProofFilePath = ConfigHelper.GetValue("ProofFilePath");
            _ProofProcessCode = ConfigHelper.GetValue("ProofProcessCode");
            _FinshProofProcessCode = ConfigHelper.GetValue("FinshProofProcessCode");
            _CallBackUrl = ConfigHelper.GetValue("CallBackUrl");

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
                ConfigHelper.SetValue("SampleAdminRoleId", value.ToString());

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
                ConfigHelper.SetValue("SampleDevelopmentRoleId", value.ToString());
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
                if (value) ConfigHelper.SetValue("IsInputStrageNeedAlow", "true");
                else ConfigHelper.SetValue("IsInputStrageNeedAlow", "false");
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
                if (value) ConfigHelper.SetValue("InStrageAlowChange", "true");
                else ConfigHelper.SetValue("InStrageAlowChange", "false");
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
                if (value) ConfigHelper.SetValue("EnableLimtView", "true");
                else ConfigHelper.SetValue("EnableLimtView", "false");
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
                if (value) ConfigHelper.SetValue("AllSampleCanLend", "true");
                else ConfigHelper.SetValue("AllSampleCanLend", "false");
            }
        }
    }
    public class BaseSetting
    {
        public bool IsInputStrageNeedAlow { get; set; }
        public bool InStrageAlowChange { get; set; }
        public bool EnableLimtView { get; set; }
        public bool AllSampleCanLend { get; set; }

    }
}
