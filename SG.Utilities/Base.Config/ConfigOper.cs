using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace SG.Utilities.Config
{
    public static class ConfigOper
    {
        //企业CorpID
        private static string _ECorpId;

        //企业CorpSecret
        private static string _ECorpSecret;

        //具体应用的appId
        private static string _EAgentID;


        //当前网站的weburl
        private static string _webUrl;


        //isv参数
        private static string _SUITE_KEY;



        private static string _SUITE_KEY_SECRET;


        private static string _Token;

        private static string _Ycolor;

        private static string _Ysize;

        public static string ECorpId
        {
            get { return ConfigOper._ECorpId; }
            set { ConfigOper._ECorpId = value; }
        }

        public static string ECorpSecret
        {
            get { return ConfigOper._ECorpSecret; }
            set { ConfigOper._ECorpSecret = value; }
        }


        public static string EAgentID
        {
            get { return ConfigOper._EAgentID; }
            set { ConfigOper._EAgentID = value; }
        }

        public static string WebUrl
        {
            get { return ConfigOper._webUrl; }
            set { ConfigOper._webUrl = value; }
        }

        public static string SUITE_KEY
        {
            get { return ConfigOper._SUITE_KEY; }
            set { ConfigOper._SUITE_KEY = value; }
        }

        public static string SUITE_KEY_SECRET
        {
            get { return ConfigOper._SUITE_KEY_SECRET; }
            set { ConfigOper._SUITE_KEY_SECRET = value; }
        }

        public static string Token
        {
            get { return ConfigOper._Token; }
            set { ConfigOper._Token = value; }
        }
        public static string Color
        {
            get { return ConfigOper._Ycolor; }
            set { ConfigOper._Ycolor = value; }
        }

        public static string Size
        {
            get { return ConfigOper._Ysize; }
            set { ConfigOper._Ysize = value; }
        }


        static ConfigOper()
        {
            _ECorpId = ConfigurationManager.AppSettings[ConfigurationKeys.ECorpId];
            _ECorpSecret = ConfigurationManager.AppSettings[ConfigurationKeys.ECorpSecret];
            _EAgentID = ConfigurationManager.AppSettings[ConfigurationKeys.EAgentID];
            _webUrl = ConfigurationManager.AppSettings[ConfigurationKeys.WebUrl];
            _SUITE_KEY = ConfigurationManager.AppSettings[ConfigurationKeys.SUITE_KEY];
            _SUITE_KEY_SECRET = ConfigurationManager.AppSettings[ConfigurationKeys.SUITE_KEY_SECRET];
            _Token = ConfigurationManager.AppSettings[ConfigurationKeys.Token];
            _Ycolor = ConfigurationManager.AppSettings[ConfigurationKeys.Ycolor];
            _Ysize = ConfigurationManager.AppSettings[ConfigurationKeys.Ysize];
        }


        private static class ConfigurationKeys
        {
            public const string ECorpId = "E.CorpId";
            public const string ECorpSecret = "E.CorpSecret";
            public const string EAgentID = "E.AgentID";
            public const string WebUrl = "webUrl";

            public const string SUITE_KEY = "SUITE_KEY";
            public const string SUITE_KEY_SECRET = "SUITE_KEY_SECRET";
            public const string Token = "Token";
            public const string ENCODING_AES_KEY = "ENCODING_AES_KEY";

            public const string Ycolor = "Y.Color";
            public const string Ysize = "Y.Size";

        }
    }
}
