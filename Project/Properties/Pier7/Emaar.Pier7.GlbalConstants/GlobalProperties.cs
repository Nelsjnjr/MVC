using Emaar.Pier7.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emaar.Pier7.GlobalConstants
{
    public static class GlobalProperties
    {
        public static string NavigationTemplatePath = "";
        public static string FooterItemPath
        {
            get
            {
                return ConfigManager.GetContextSite().ContentStartPath + "/Data/Footer/FooterItem";
            }
        }
        public static string HeaderItemPath
        {
            get
            {
                return ConfigManager.GetContextSite().ContentStartPath + "/Data/Header/HeaderItem";
            }
        }
        public static string SubMenuPath
        {
            get
            {
                return ConfigManager.GetContextSite().ContentStartPath + "/Data/SubMenu/SubMenuNavLinks";
            }
        }
        public static string CMDatabase
        {
            get
            {
                return "master";
            }
        }
        public static string CDDatabase
        {
            get
            {
                return "web";
            }
        }
        public const string SitecoreContentRoot = "/sitecore/content";
        public static string NavigationRootFolder
        {
            get
            {
                return ConfigManager.GetContextSite().ContentStartPath + "/Navigation/";
            }
        }
        public const string EmailCampaignMangerRoot = "/sitecore/content/Email Campaign";
       

    }
}
