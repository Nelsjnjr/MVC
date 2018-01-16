using Emaar.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emaar.Pier7.Website.Models.Component
{
    [SitecoreType(TemplateId = "{2778F279-1871-4009-9603-35A4DD8C9522}", AutoMap = true)]
    public class TextAndTitle : BaseGlassItem
    {
        [SitecoreField("HeaderTitle")]
        public virtual string HeaderTitle { get; set; }
        [SitecoreField("Description")]
        public virtual string Description { get; set; }
    }
}