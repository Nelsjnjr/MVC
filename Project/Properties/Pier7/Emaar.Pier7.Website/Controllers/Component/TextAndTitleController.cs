using Emaar.Pier7.Website.Models.Component;
using Glass.Mapper.Sc.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emaar.Pier7.Website.Controllers.Component
{
    public class TextAndTitleController : GlassController<TextAndTitle>
    {
        // GET: TextAndTitle
        public override ActionResult Index()
        {
            var model = SitecoreContext.GetItem<TextAndTitle>(Sitecore.Mvc.Presentation.RenderingContext.Current.Rendering.DataSource);
            return View("~/Views/Components/TextAndTitle.cshtml", model);
        }
    }
}