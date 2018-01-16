using Emaar.Pier7.GlobalConstants;
using Emaar.Pier7.Website.Models.Common;
using Emaar.Pier7.Website.Models.Component;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emaar.Pier7.Website.Controllers
{
    public class HeaderController : GlassController
    {
        // GET: Header
        public override ActionResult Index()
        {
            var model = SitecoreContext.GetItem<HeaderModel>(GlobalProperties.HeaderItemPath);
            return View("~/Views/Common/Header.cshtml",model);
        }
        
    }
}
