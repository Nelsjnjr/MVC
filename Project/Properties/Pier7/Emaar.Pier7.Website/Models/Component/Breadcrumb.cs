using Emaar.Models.Base;
using Emaar.Pier7.Website.Models.Component;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emaar.Pier7.Website.Models.Component
{
    public class Breadcrumb:BaseGlassItem
    {
        public  override string Url { get; set; }
        public virtual string Text { get; set; }
        public virtual bool IsLastItem { get; set; }
      

    }
}