using Emaar.Pier7.Website.Models.Component;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emaar.Pier7.Website.Models.common
{
    public class RightContainerModel
    {

        public virtual IEnumerable<Breadcrumb> BreadcrumbItems { get; set; }
        public virtual bool IsSubMenuAvailable { get; set; }

        public virtual IEnumerable<Breadcrumb> SubMenuItems { get; set; }
    }
}