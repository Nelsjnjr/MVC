using Emaar.Pier7.Data;
using Emaar.Pier7.Website.Models.Common;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Emaar.Pier7.Website.Controllers.Component
{
    public class SitemapController : Controller
    {
        // GET: Sitemap
        public  ActionResult Index()
        {
            Item homePage = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.RootPath + Sitecore.Context.Site.StartItem);
            var sitemap = SitecoreHelper.GetItem<MenuItem>(homePage.ID.ToGuid());
            return View("~/Views/Pages/Sitemap.cshtml", sitemap);
        }
       
    }
}
