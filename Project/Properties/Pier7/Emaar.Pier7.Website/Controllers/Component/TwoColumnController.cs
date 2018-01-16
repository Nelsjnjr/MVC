using Emaar.Pier7.Website.Models.Common;
using Emaar.Pier7.Website.Models.Component;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emaar.Pier7.Website.Controllers.Component
{
    public class TwoColumnController : GlassController<PageClass>
    {
        // GET: TwoColumn
        public override ActionResult Index()
        {
            Settings setting = null;
            var content = Sitecore.Mvc.Presentation.RenderingContext.CurrentOrNull;
            if (content != null)
            {
                Guid ? guid = null;
                var parms = content.Rendering.Parameters;
                if (!String.IsNullOrEmpty(parms["ClassName"]))
                {
                    guid = new Guid(parms["ClassName"]);
                    setting = SitecoreContext.GetItem<Settings>(guid.Value);
                }
            }
            return View("~/Views/Shared/Twocolumn.cshtml", setting);
        }
    }
}