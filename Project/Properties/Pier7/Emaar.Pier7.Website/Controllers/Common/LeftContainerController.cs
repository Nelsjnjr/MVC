using Emaar.Pier7.Website.Models.Common;
using Emaar.Pier7.Website.Models.Component;
using Emaar.Pier7.Website.Models.Pages;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Data;
using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emaar.Pier7.Website.Controllers.Common
{
    public class LeftContainerController :  GlassController<LeftContainerModel>
    {
        // GET: LeftContainer
        public override ActionResult Index()
        {
            var model = SitecoreContext.GetItem<LeftContainerModel>(Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.DataSource);
            return View("~/Views/Common/LeftContainer.cshtml", model);
        }
    }
}