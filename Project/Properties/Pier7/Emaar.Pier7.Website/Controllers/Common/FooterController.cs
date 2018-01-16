using Emaar.Pier7.Website.Models.Component;
using Glass.Mapper.Sc;
using Sitecore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Mvc.Presentation;
using Glass.Mapper.Sc.Web.Mvc;
using Emaar.Pier7.GlobalConstants;
using Emaar.Pier7.Website.Models.Common;

namespace Emaar.Pier7.Website.Controllers
{
    public class FooterController : GlassController<FooterModel>
    {
        
        // GET: Footer
        public override ActionResult Index()
        {
       
          var model= SitecoreContext.GetItem<FooterModel>(GlobalProperties.FooterItemPath);
           return View("~/Views/Common/Footer.cshtml",model);
        }
    }
}