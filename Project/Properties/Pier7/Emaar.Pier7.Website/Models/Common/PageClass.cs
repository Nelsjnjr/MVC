using Emaar.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emaar.Pier7.Website.Models.Common
{
    [SitecoreType(TemplateId = "{D1B04FD0-09F4-4CB4-806C-6EC8694DC704}", AutoMap = true)]
    public class PageClass:BaseGlassItem
    {
        [SitecoreField("ClassName")]
        public virtual Settings Setting { get; set; }    
       
    }
}