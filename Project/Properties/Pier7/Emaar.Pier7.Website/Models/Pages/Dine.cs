using Emaar.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emaar.Pier7.Website.Models.Pages
{
    public class Dine : BaseGlassItem
    {
        [SitecoreField("ImageFile")]
        public virtual Image ImageFile { get; set; }
        [SitecoreField("ImageUrl")]
        public virtual Link ImageUrl { get; set; }
        [SitecoreField("ContentTitle")]
        public virtual string ContentTitle { get; set; }
        [SitecoreField("ContentDescription")]
        public virtual string ContentDescription { get; set; }
        [SitecoreField("CallToAction")]
        public virtual Link CallToAction { get; set; }
        [SitecoreField("CallToActionTitle")]
        public virtual string CallToActionTitle { get; set; }
        [SitecoreField("IsTitleAllowed")]
        public virtual bool IsTitleAllowed { get; set; }
    }

}
