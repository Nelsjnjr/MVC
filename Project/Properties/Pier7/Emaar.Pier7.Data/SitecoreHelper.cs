using System;
using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Layouts;
using Sitecore.Configuration;
using System.Text.RegularExpressions;
using Sitecore.Events;
using Sitecore.Data.Fields;
using System.Linq;
using Sitecore.Links;
using Sitecore.Resources.Media;
using Glass.Mapper.Sc;
using Emaar.Pier7.GlobalConstants;
using Emaar.Models.Base;

namespace Emaar.Pier7.Data
{
    public static class SitecoreHelper
    {

        #region SitecoreService

        public static ISitecoreService SitecoreService
        {
            get
            {
                return new SitecoreService(GetSitecoreDB());
            }
        }

        #endregion

        #region GetSitecoreDB

        public static Database GetSitecoreDB()
        {
            string dbName = Sitecore.Context.PageMode.IsPreview ? GlobalProperties.CMDatabase : GlobalProperties.CDDatabase;
            return Factory.GetDatabase(dbName);
        }

        #endregion

        #region GetItem

        public static T GetItem<T>(string itemPath, Language language = null) where T : class
        {
            if (string.IsNullOrEmpty(itemPath)) return null;
            if (language == null)
            {
                language = Sitecore.Context.Language;
            }

            return SitecoreService.GetItem<T>(itemPath, language);
        }

        public static T GetItem<T>(Guid itemId, Language language = null) where T : class
        {
            if (language == null)
            {
                language = Sitecore.Context.Language;
            }

            return SitecoreService.GetItem<T>(itemId, language);
        }

        public static IEnumerable<T> GetItems<T>(Guid baseTemplate, Guid searchPathStart) where T : BaseGlassItem
        {
            var baseItem = GetItem<T>(searchPathStart);
            if (baseItem == null || string.IsNullOrEmpty(baseItem.ContentPath)) return null;

            string query = (GlobalProperties.SitecoreContentRoot + baseItem.ContentPath + "/*[@@TemplateID='{" + baseTemplate.ToString().ToUpper() + "}']");
            var itemList = SitecoreService.Query<T>(query.Replace(" and ", " #and# ").Replace(" or ", " #or# "));
            return itemList;
        }

        public static IEnumerable<T> GetItems<T>(Guid baseTemplate, string searchPathStart) where T : BaseGlassItem
        {
            var baseItem = GetItem<T>(searchPathStart);
            if (baseItem == null || string.IsNullOrEmpty(baseItem.ContentPath)) return null;

            var itemList = SitecoreService.Query<T>(GlobalProperties.SitecoreContentRoot + baseItem.ContentPath
                + "/*[@@TemplateID='{" + baseTemplate.ToString().ToUpper() + "}']");

            return itemList;
        }

        public static IEnumerable<T> GetItems<T>(Guid baseTemplate, Guid searchPathStart, Language language) where T : BaseGlassItem
        {
            if (language != null)
            {
                using (new LanguageSwitcher(language))
                {
                    return GetItems<T>(baseTemplate, searchPathStart);
                }
            }

            return GetItems<T>(baseTemplate, searchPathStart);
        }

        public static IEnumerable<T> GetItems<T>(Guid baseTemplate, string searchPathStart, Language language) where T : BaseGlassItem
        {
            if (language != null)
            {
                using (new LanguageSwitcher(language))
                {
                    return GetItems<T>(baseTemplate, searchPathStart);
                }
            }

            return GetItems<T>(baseTemplate, searchPathStart);
        }
       
        public static string GetAbsoluteItemUrl(this Item item)
        {
            var urlOptions = Sitecore.Links.UrlOptions.DefaultOptions;
            urlOptions.AlwaysIncludeServerUrl = true;
            urlOptions.SiteResolving = true;

            return LinkManager.GetItemUrl(item, urlOptions);
        }
        #endregion

        #region GetTargetItem



        #endregion

        #region GetStringField

        public static string GetStringField(Item item, string field)
        {
            if (item == null) return null;
            if ((item.Fields.Count > 0) && (item.Fields[field] != null))
            {
                return item.Fields[field].ToString();
            }
            return null;
        }

        #endregion

        #region GetSublayoutItem

        public static Item GetSublayoutItem(Item sitecoreItem)
        {
            return GetSublayoutItem(sitecoreItem, Sitecore.Context.Language);
        }

        public static Item GetSublayoutItem(Item sitecoreItem, Language currentLanguage)
        {
            if (sitecoreItem == null) return null;

            RenderingReference[] allRenderings = sitecoreItem.Visualization.GetRenderings(Sitecore.Context.Device, false);
            if (allRenderings.Length > 0)
            {
                Item sublayoutNode = GetSitecoreDB().GetItem(allRenderings[0].RenderingID, currentLanguage);
                return sublayoutNode;
            }

            return null;
        }

        #endregion

        #region LanguageFallback

       

        #endregion

        #region IsGUID

        /// <summary>
        /// To check the whether the input is valid GUID
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsGUID(string expression)
        {
            if (expression != null)
            {
                Regex guidRegEx = new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$");

                return guidRegEx.IsMatch(expression);
            }
            return false;
        }

        #endregion

    }


}
