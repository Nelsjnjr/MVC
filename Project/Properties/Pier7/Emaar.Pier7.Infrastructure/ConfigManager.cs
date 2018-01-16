using Sitecore.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emaar.Pier7.Data
{
    public static class ConfigManager
    {
        public static Sitecore.Sites.SiteContext GetContextSite()
        {
            if (Sitecore.Context.PageMode.IsExperienceEditor || Sitecore.Context.PageMode.IsPreview)
            {
                // item ID for page editor and front-end preview mode
                string id = Sitecore.Web.WebUtil.GetQueryString("sc_itemid");

                // by default, get the item assuming Presentation Preview tool (embedded preview in shell)
                var item = Sitecore.Context.Item;

                // if a query string ID was found, get the item for page editor and front-end preview mode
                if (!string.IsNullOrEmpty(id))
                {
                    item = Sitecore.Context.Database.GetItem(id);
                }

                if (item != null)
                {
                    // loop through all configured sites
                    foreach (var site in Factory.GetSiteInfoList())
                    {
                        // get this site's home page item
                        var homePage = Sitecore.Context.Database.GetItem(site.RootPath + site.StartItem);

                        // if the item lives within this site, this is our context site
                        if (homePage != null && homePage.Axes.IsAncestorOf(item))
                        {
                            return Factory.GetSite(site.Name);
                        }
                    }
                }

                // fallback and assume context site
                return Sitecore.Context.Site;
            }
            else
            {
                // standard context site resolution via hostname, virtual/physical path, and port number
                return Sitecore.Context.Site;
            }
        }
    }
}
