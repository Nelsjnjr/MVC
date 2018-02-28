using Emaar.Models.Base;
using Emaar.Pier7.Website.Models.Common;
using Emaar.Pier7.Website.Models.Component;
using Emaar.Pier7.Website.ViewModel;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emaar.Pier7.Website.Controllers.Common
{
    public class BreadcrumbController : GlassController<Models.Component.Breadcrumb>
    {
        // GET: Breadcrumb
        public override ActionResult Index()
        {
            List<Models.Component.Breadcrumb> breadcrumbMenu = new List<Models.Component.Breadcrumb>();
            BreadcrumbViewModel breadcrumbViewModel = new BreadcrumbViewModel();
            Item currentItem = Sitecore.Context.Item; // Current sitecore item
            Item homePage = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.RootPath + Sitecore.Context.Site.StartItem);
            bool isLasItem = false; 
            Item MainNavigationItem = null;
          
            while (currentItem.ID != new ID(homePage.ID.ToGuid()))
            {
                if (!isLasItem)
                {
                    MainNavigationItem = currentItem;            
                    // add parent item to breadcrumb object (a list of parent items)
                    breadcrumbMenu.Add(new Breadcrumb
                    {
                        IsLastItem = !isLasItem ? true : false,
                        Url = Sitecore.Links.LinkManager.GetItemUrl(currentItem),
                        Text = currentItem.Fields["Title"].ToString()
                      
                    });
                    currentItem = currentItem.Parent;
                    isLasItem = true;
                    continue;
                }
                breadcrumbMenu.Add(new Breadcrumb
                {
                    IsLastItem = !isLasItem ? true : false,
                    Url = Sitecore.Links.LinkManager.GetItemUrl(currentItem),
                    Text = currentItem.Fields["Title"].ToString()
                });
                currentItem = currentItem.Parent;
            }
            breadcrumbMenu.Add(new Breadcrumb
            {
                IsLastItem = !isLasItem ? true : false,
                Url = Sitecore.Links.LinkManager.GetItemUrl(currentItem),
                Text = currentItem.Fields["Title"].ToString()
            });
            breadcrumbMenu.Reverse();
            breadcrumbViewModel.MainBreadcrumbs = breadcrumbMenu;
            if (MainNavigationItem.Children.Count > 0)
            {
                var model = SitecoreContext.GetItem<MenuItem>(MainNavigationItem.Children.FirstOrDefault().ID.ToGuid());
                breadcrumbViewModel.SubMenus = model.NavigationItems.ToList();
            }
            return View("~/Views/Components/Breadcrumb.cshtml", breadcrumbViewModel);
        }

    }
}

