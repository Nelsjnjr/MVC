using Emaar.Pier7.Website.Models.Common;
using Emaar.Pier7.Website.Models.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emaar.Pier7.Website.Models.Component
{
    public class BreadcrumbViewModel
    {
        public virtual List<Breadcrumb> MainBreadcrumbs { get; set; }
        public virtual List<MenuItem> SubMenus { get; set; }
    }
}