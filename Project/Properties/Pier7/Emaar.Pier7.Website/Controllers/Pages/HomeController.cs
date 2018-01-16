using Emaar.Core;
using Emaar.Pier7.Website.Models.Pages;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emaar.Pier7.Website.Controllers
{
    public class HomeController : GlassController<HomeModel>
    {
        // GET: Home
        public override ActionResult Index()
        {
            CustomPipelineArgs pipelineArgs = new CustomPipelineArgs(PageContext.Current.Item);
            CorePipeline.Run("CustomPipeline", pipelineArgs);
            if (!pipelineArgs.Valid && !string.IsNullOrEmpty(pipelineArgs.Message))
            {
                // Execute code here to deal with failed validation
            }
            var model = SitecoreContext.GetItem<HomeModel>(PageContext.Current.Item.ID.ToGuid());
            return View("~/Views/Pages/Home.cshtml",model);
        }
    }
}