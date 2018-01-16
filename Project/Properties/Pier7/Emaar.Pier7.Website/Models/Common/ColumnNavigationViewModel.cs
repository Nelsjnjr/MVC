using Emaar.Pier7.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Emaar.Models.Base;
namespace Emaar.Pier7.Website.Models.Common
{
    public class ColumnNavigationViewModel: BaseGlassItem
    {
        public virtual List<ColumnNavigationItem> ColumnNavigationItems { get; set; }
    }
}