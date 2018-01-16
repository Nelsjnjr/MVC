using Emaar.Pier7.Website.Models.Pages;
using Glass.Mapper.Sc.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emaar.Pier7.Website.Controllers.Component
{
    public class DineDetailsController : GlassController<DineDetails>
    {

        // GET: DineDetails
        public override ActionResult Index()
        {
            var model = SitecoreContext.GetItem<DineDetails>(Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.DataSource);
            return View("~/Views/Pages/DineDetails.cshtml", model);
        }
    }
}