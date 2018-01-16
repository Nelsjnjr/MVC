using Emaar.Models.Base;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emaar.Pier7.Website.Models.Common
{
    [SitecoreType(TemplateId = "{55FB5A1B-6278-4B03-B37D-F10C59C29393}", AutoMap = true)]
    public class Settings :BaseGlassItem
    {
        [SitecoreField("Key")]
        public virtual string Key { get; set; }

        [SitecoreField("Value")]
        public virtual string Value { get; set; }
    }
}