using Emaar.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emaar.Pier7.Website.Models.Component
{
    [SitecoreType(TemplateId = "{73A5A096-5632-422E-93D4-DEFA8E15070E}", AutoMap = true)]
    public class ImageComponent : BaseGlassItem
    {
        [SitecoreField("ImageFile")]
        public virtual Image ImageFile { get; set; }
    }
}