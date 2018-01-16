using Emaar.Models.Base;
using Emaar.Pier7.Data;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emaar.Pier7.Website.Models.Common
{
    [SitecoreType(TemplateId = "{18A7E80E-5A5A-49CD-9EF2-DF63FE0C0BA6}", AutoMap = true)]
    public class ColumnNavigationItem : BaseGlassItem
    {
        [SitecoreField("ExternalLink")]
        public virtual string ExternalLink { get; set; }

        [SitecoreField("InternalLink")]
        public virtual Link InternalLink { get; set; }

        [SitecoreField("Navigation Title")]
        public virtual string NavigationTitle { get; set; }

        [SitecoreField("MenuLogo")]
        public virtual Image MenuLogo { get; set; }

        [SitecoreField("MenuLogoUrl")]
        public virtual Link MenuLogoUrl { get; set; }

        [SitecoreField("PierOne")]
        public virtual IEnumerable<MenuItem> PierOne { get; set; }

        [SitecoreField("PierTwo")]
        public virtual IEnumerable<MenuItem> PierTwo { get; set; }

        [SitecoreField("PierThree")]
        public virtual IEnumerable<MenuItem> PierThree { get; set; }

        [SitecoreField("PierFour")]
        public virtual IEnumerable<MenuItem> PierFour { get; set; }

        [SitecoreChildren]
        public virtual IEnumerable<MenuItem> NavigationItems { get; set; }
    }
}