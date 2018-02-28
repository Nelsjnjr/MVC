using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emaar.Models.Base
{
    [SitecoreType(TemplateId = "{5103F6EA-DA81-4760-BAB1-E6329BE496AD}", AutoMap = true)]
    public class ExternalMetadata : BaseGlassItem
    {
        [SitecoreField("Meta Desscription")]
        public virtual string MetaDescription { get; set; }

        [SitecoreField("Meta Title")]
        public virtual string MetaTitle { get; set; }

        [SitecoreField("Meta Keywords")]
        public virtual string MetaKeywords { get; set; }

        [SitecoreField("No index")]
        public virtual bool NoIndex { get; set; }

        [SitecoreField("OpenGraphDescription")]
        public virtual string OpenGraphDescription { get; set; }

        [SitecoreField("OpenGraphImage")]
        public virtual Image OpenGraphImage { get; set; }

        [SitecoreField("OpenGraphSiteName")]
        public virtual string OpenGraphSiteName { get; set; }

        [SitecoreField("OpenGraphTitle")]
        public virtual string OpenGraphTitle { get; set; }

        [SitecoreField("OpenGraphType")]
        public virtual string OpenGraphType { get; set; }

        [SitecoreField("OpenGraphUrl")]
        public virtual string OpenGraphUrl { get; set; }
        
        [SitecoreField("CanonicalUrl")]
        public virtual string CanonicalUrl { get; set; }

        [SitecoreField("IncludeInSitemap")]
        public virtual bool IncludeInSitemap { get; set; }
    }
}
