using Emaar.Models.Base;
using Emaar.Pier7.Website.Models.Common;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emaar.Pier7.Website.ViewModel
{
    public class SitemapViewModel : BaseGlassItem
    {
       public virtual MenuItem SitemapNodes { get; set; }
    }
}