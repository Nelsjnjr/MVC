using Emaar.Models.Base;
using Emaar.Pier7.Data;
using Emaar.Pier7.Website.Models.Common;
using Emaar.Pier7.Website.ViewModel;
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
    public class SitemapController : GlassController<Emaar.Models.Base.BaseGlassItem>
    {
        // GET: Sitemap
        public override  ActionResult Index()
        {
            Item homePage = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.RootPath + Sitecore.Context.Site.StartItem);
            var sitemap = SitecoreHelper.GetItem<MenuItem>(homePage.ID.ToGuid());
         
            SitemapViewModel model = new SitemapViewModel()
            {                
                SitemapNodes = sitemap
                 
            };        
            return View("~/Views/Pages/Sitemap.cshtml", model);
        }
       
    }
}
