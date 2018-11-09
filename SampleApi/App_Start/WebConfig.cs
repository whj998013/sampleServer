using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SampleApi
{
    public static class Config
    {
        public static string CorpId
        {
            get
            {
                return ConfigurationManager.AppSettings["CorpId"];
            }
        }
        public static string CorpSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["CorpSecret"];
            }
        }
        public static string AgentID
        {
            get
            {
                return ConfigurationManager.AppSettings["AgentID"];
            }
        }

        public static string MinPicPath
        {
            get
            {
                return ConfigurationManager.AppSettings["MinPicPath"];
            }
        }

        public static string PicPath
        {
            get
            {
                return ConfigurationManager.AppSettings["PicPath"];
            }
        }
        public static string FilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["FilePath"];
            }
        }
    }

}

