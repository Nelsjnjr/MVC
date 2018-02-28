using Emaar.Pier7.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Emaar.Models.Base;
using Emaar.Pier7.Website.Models.Common;

namespace Emaar.Pier7.Website.ViewModel
{
    public class ColumnNavigationViewModel: BaseGlassItem
    {
        public virtual List<ColumnNavigationItem> ColumnNavigationItems { get; set; }
    }
}