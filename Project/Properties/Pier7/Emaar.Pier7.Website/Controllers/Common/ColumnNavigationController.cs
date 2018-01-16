using Emaar.Core;
using Emaar.Pier7.Data;
using Emaar.Pier7.GlobalConstants;
using Emaar.Pier7.Website.Models.Common;
using Emaar.Pier7.Website.Models.Component;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emaar.Pier7.Website.Controllers.Common
{
    public class ColumnNavigationController : Controller
    {
        // GET: ColumnNavigation
        public ActionResult Index()
        {
            CustomPipelineArgs pipelineArgs = new CustomPipelineArgs(PageContext.Current.Item);
            CorePipeline.Run("CustomPipeline", pipelineArgs);
            if (!pipelineArgs.Valid && !string.IsNullOrEmpty(pipelineArgs.Message))
            {
                // Execute code here to deal with failed validation
            }
            List<ColumnNavigationItem> navigation = new List<ColumnNavigationItem>();
            var data = SitecoreHelper.GetItems<ColumnNavigationItem>(new Guid(GlobalGuids.ColumnNavigationItem),
                                                       String.Format("{0}{1}", GlobalProperties.NavigationRootFolder, RenderingContext.CurrentOrNull.Rendering.Item.Name));
            foreach (var item in data)
            {
                Item checkItem = SitecoreHelper.GetSitecoreDB().GetItem(new Sitecore.Data.ID(item.Id), Sitecore.Context.Language);
                if (checkItem != null && checkItem.Versions.Count > 0)
                    navigation.Add(item);
            }
            ColumnNavigationViewModel Navigation = new ColumnNavigationViewModel() { ColumnNavigationItems = navigation };            
            return View("~/Views/Common/ColumnNavigation.cshtml", Navigation);
        }
    }
}