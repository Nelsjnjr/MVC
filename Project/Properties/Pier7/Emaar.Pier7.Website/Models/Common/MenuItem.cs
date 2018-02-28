using Emaar.Pier7.Data;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System.Collections.Generic;
using System.Web;
using Emaar.Models.Base;
using Glass.Mapper.Sc.Configuration;

namespace Emaar.Pier7.Website.Models.Common
{
    [SitecoreType(TemplateId = "{DFB6FCBA-3F55-497E-BD1A-54AF77385BE0}", AutoMap = true)]
    public class MenuItem:BaseGlassItem
    {
        [SitecoreField("Navigation Url")]
        public virtual Link NavigationUrl { get; set; }
        [SitecoreField("Navigation Title")]
        public virtual string Text { get; set; }
        [SitecoreField("CssClass")]
        public virtual string CssClass { get; set; }
        [SitecoreChildren]
        public virtual IEnumerable<MenuItem> NavigationItems { get; set; }
    }
}

